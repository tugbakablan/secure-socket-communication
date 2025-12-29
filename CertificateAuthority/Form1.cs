using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;
using System.Collections.Generic; 

namespace CertificateAuthority
{
    public partial class Form1 : Form
    {
        RSACryptoServiceProvider caRSA = new RSACryptoServiceProvider(2048);
        bool broadcasting = false;

        static Dictionary<string, string> UserDirectory = new Dictionary<string, string>();

        public Form1() { InitializeComponent(); CheckForIllegalCrossThreadCalls = false; }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIP.Text)) { MessageBox.Show("Please enter a valid IP!"); return; }
            int port = 5560;
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            Log("SYSTEM", $"CA Server Started on Port {port}.", Color.Lime);
            Log("DIRECTORY", "User Directory Service Active.", Color.Cyan);

            broadcasting = true;
            new Thread(BroadcastLoop) { IsBackground = true }.Start();

            new Thread(() => {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        new Thread(() => HandleClient(client)).Start();
                    }
                    catch { }
                }
            })
            { IsBackground = true }.Start();
            btnStart.Enabled = false; txtIP.ReadOnly = true;
        }

        void BroadcastLoop()
        {
            UdpClient udp = new UdpClient();
            udp.EnableBroadcast = true;

            // CA IP ve subnet mask al
            IPAddress localIP = IPAddress.Parse(txtIP.Text);
            IPAddress subnetMask = IPAddress.Parse("255.255.255.240"); // kendi subnet mask’in
            IPAddress broadcastIP = GetBroadcastAddress(localIP, subnetMask);

            IPEndPoint groupEP = new IPEndPoint(broadcastIP, 8888);

            while (broadcasting)
            {
                try
                {
                    string msg = $"CA_FOUND|{txtIP.Text}";
                    byte[] bytes = Encoding.UTF8.GetBytes(msg);
                    udp.Send(bytes, bytes.Length, groupEP);
                    Thread.Sleep(3000);
                }
                catch { }
            }
        }

        // Broadcast adresi hesaplama
        public static IPAddress GetBroadcastAddress(IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Length mismatch between IP and subnet mask");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }


        void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                var pkt = new Packet { Type = "INFO", Sender = "CA", Msg = "CA Ready." };
                byte[] b = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(pkt));
                ns.Write(b, 0, b.Length);

                byte[] buf = new byte[8192];
                int read = ns.Read(buf, 0, buf.Length);
                if (read > 0)
                {
                    var p = JsonSerializer.Deserialize<Packet>(Encoding.UTF8.GetString(buf, 0, read));

                    if (p.Type == "REQ")
                    {
                        Log("REQ", $"{p.Sender} requesting certificate...", Color.Yellow);
                        var cert = new MyCert { ID = Guid.NewGuid().ToString().Substring(0, 8), Sub = p.Sender, Key = p.Msg };
                        byte[] dataToSign = Encoding.UTF8.GetBytes(cert.Sub + cert.Key);
                        cert.Sign = Convert.ToBase64String(caRSA.SignData(dataToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));

                        var res = new Packet { Type = "RES", Msg = JsonSerializer.Serialize(cert) };
                        byte[] rb = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(res));
                        ns.Write(rb, 0, rb.Length);
                        Log("SUCCESS", $"Certificate issued to {p.Sender}.", Color.Lime);
                    }

                    else if (p.Type == "REG")
                    {
                        if (UserDirectory.ContainsKey(p.Sender)) UserDirectory[p.Sender] = p.Msg;
                        else UserDirectory.Add(p.Sender, p.Msg);

                        Log("DIRECTORY", $"User Registered: {p.Sender} @ {p.Msg}", Color.Magenta);
                    }

                    else if (p.Type == "FIND")
                    {
                        string targetUser = p.Msg; 
                        Log("DIRECTORY", $"{p.Sender} is looking for {targetUser}...", Color.Orange);

                        if (UserDirectory.ContainsKey(targetUser))
                        {
                            string address = UserDirectory[targetUser]; 
                            var res = new Packet { Type = "FOUND", Msg = address };
                            byte[] rb = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(res));
                            ns.Write(rb, 0, rb.Length);
                            Log("DIRECTORY", $"Sent {targetUser}'s address to {p.Sender}.", Color.Lime);
                        }
                        else
                        {
                            var res = new Packet { Type = "NOT_FOUND", Msg = "" };
                            byte[] rb = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(res));
                            ns.Write(rb, 0, rb.Length);
                            Log("DIRECTORY", $"{targetUser} not found.", Color.Red);
                        }
                    }
                }
            }
            catch { }
            finally { client.Close(); }
        }

        void Log(string c, string m, Color o) { if (rtbLog.InvokeRequired) Invoke(new Action(() => Log(c, m, o))); else { rtbLog.SelectionColor = o; rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] [{c}] {m}\n"); rtbLog.ScrollToCaret(); } }
    }
    public class Packet { public string Type { get; set; } public string Sender { get; set; } public string Msg { get; set; } }
    public class MyCert { public string ID { get; set; } public string Sub { get; set; } public string Key { get; set; } public string Sign { get; set; } }
}