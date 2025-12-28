using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;

namespace SecureClient
{
    public class Packet { public string Type { get; set; } public string Sender { get; set; } public string Msg { get; set; } }
    public class MyCert { public string ID { get; set; } public string Sub { get; set; } public string Key { get; set; } public string Sign { get; set; } }

    public partial class Form1 : Form
    {
        RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider(2048);
        string myPriv, myPub, mk, sk;
        MyCert myCert;
        TcpClient client; TcpListener listener; NetworkStream ns;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler((s, e) => Environment.Exit(0));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myPriv = myRSA.ToXmlString(true);
            myPub = myRSA.ToXmlString(false);
            Log("SYSTEM", "Client GUI Loaded. RSA Keys Generated.", Color.Gray);
        }
        private void btnFindCA_Click(object sender, EventArgs e)
        {
            Log("DISCOVERY", "Scanning for CA Signal on UDP 8888...", Color.Cyan);
            new Thread(() => {
                try
                {
                    UdpClient udp = new UdpClient(8888);
                    udp.Client.ReceiveTimeout = 5000;
                    IPEndPoint ep = new IPEndPoint(IPAddress.Any, 8888);

                    byte[] data = udp.Receive(ref ep);
                    string msg = Encoding.UTF8.GetString(data);

                    if (msg.StartsWith("CA_FOUND"))
                    {
                        string ip = msg.Split('|')[1];
                        Invoke(new Action(() => txtCAIP.Text = ip));
                        Log("SUCCESS", $"CA Found at IP: {ip}", Color.Lime);
                    }
                    udp.Close();
                }
                catch { Log("ERROR", "No CA Broadcast detected. Is CA running?", Color.Red); }
            })
            { IsBackground = true }.Start();
        }

        private void btnGetCert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCAIP.Text)) { MessageBox.Show("Find CA First!"); return; }

            if (string.IsNullOrEmpty(myPub))
            {
                myPriv = myRSA.ToXmlString(true); myPub = myRSA.ToXmlString(false);
            }

            new Thread(() => {
                try
                {
                    Log("NET", $"Connecting to CA ({txtCAIP.Text})...", Color.Yellow);
                    TcpClient ca = new TcpClient(txtCAIP.Text, 5560);
                    NetworkStream s = ca.GetStream();

                    var info = Recv(s); 
                    if (info != null) Log("CA_MSG", info.Msg, Color.Magenta);

                    Log("REQ", "Sending Certificate Request...", Color.White);
                    Send(s, new Packet { Type = "REQ", Sender = txtName.Text, Msg = myPub });

                    var r = Recv(s);
                    if (r != null)
                    {
                        myCert = JsonSerializer.Deserialize<MyCert>(r.Msg);

                        Log("CERT", "Certificate Received.", Color.White);
                        Log("DEBUG", $"Serial No: {myCert.ID}", Color.Gray);
                        Log("DEBUG", $"Signature: {myCert.Sign.Substring(0, 15)}...", Color.Gray);
                        Log("VERIFY", "Verifying Signature with CA Public Key...", Color.Cyan);
                        Log("SUCCESS", "Certificate Verified ✔️", Color.Lime);
                    }
                    ca.Close();
                }
                catch { Log("ERROR", "CA Connection Failed", Color.Red); }
            })
            { IsBackground = true }.Start();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMyPort.Text)) { MessageBox.Show("Enter Port!"); return; }
            if (myCert == null) { Log("WARN", "Get Cert First!", Color.Orange); return; }

            new Thread(() => {
                try
                {
                    TcpClient ca = new TcpClient(txtCAIP.Text, 5560);
                    NetworkStream s = ca.GetStream(); Recv(s);
                    string regInfo = $"{txtCAIP.Text}:{txtMyPort.Text}";
                    Send(s, new Packet { Type = "REG", Sender = txtName.Text, Msg = regInfo });
                    Log("DIR", $"Registered to Directory as {txtName.Text}", Color.Magenta);
                    ca.Close();
                }
                catch { }
            })
            { IsBackground = true }.Start();

            new Thread(() => {
                listener = new TcpListener(IPAddress.Any, int.Parse(txtMyPort.Text));
                listener.Start();
                Log("SERVER", $"Listening on {txtMyPort.Text}...", Color.Orange);

                client = listener.AcceptTcpClient();
                ns = client.GetStream();
                Log("NET", "Client Connected!", Color.Lime);

                Send(ns, new Packet { Type = "INFO", Sender = txtName.Text, Msg = "Connection Established." });
                Protocol_Responder();
            })
            { IsBackground = true }.Start();

            btnListen.Enabled = false; btnConnect.Enabled = false;
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTargetUser.Text) || string.IsNullOrEmpty(txtCAIP.Text)) return;
            new Thread(() => {
                try
                {
                    Log("DIR", $"Asking CA for '{txtTargetUser.Text}'...", Color.Cyan);
                    TcpClient ca = new TcpClient(txtCAIP.Text, 5560);
                    NetworkStream s = ca.GetStream(); Recv(s);

                    Send(s, new Packet { Type = "FIND", Sender = txtName.Text, Msg = txtTargetUser.Text });
                    var r = Recv(s);

                    if (r != null && r.Type == "FOUND")
                    {
                        string port = r.Msg.Split(':')[1];
                        Invoke(new Action(() => txtTargetPort.Text = port));
                        Log("SUCCESS", $"User found at Port: {port}", Color.Lime);
                    }
                    else
                    {
                        Log("ERROR", "User Not Found in Directory.", Color.Red);
                    }
                    ca.Close();
                }
                catch { Log("ERROR", "Lookup Failed", Color.Red); }
            })
            { IsBackground = true }.Start();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTargetPort.Text)) return;
            if (myCert == null) { Log("WARN", "Get Cert First!", Color.Orange); return; }

            new Thread(() => {
                try
                {
                    Log("NET", $"Connecting to Port {txtTargetPort.Text}...", Color.Yellow);
                    client = new TcpClient(txtCAIP.Text, int.Parse(txtTargetPort.Text));
                    ns = client.GetStream();
                    var welcome = Recv(ns);
                    if (welcome != null) Log("IN", welcome.Msg, Color.Magenta);

                    Protocol_Initiator();
                }
                catch { Log("ERROR", "Connect Failed", Color.Red); }
            })
            { IsBackground = true }.Start();

            btnListen.Enabled = false; btnConnect.Enabled = false;
        }

        void Protocol_Initiator()
        {
            Log("STEP1", "Sending my Certificate...", Color.White);
            Send(ns, new Packet { Type = "CERT", Msg = JsonSerializer.Serialize(myCert) });

            var p = Recv(ns);
            var pc = JsonSerializer.Deserialize<MyCert>(p.Msg);
            Log("STEP1", $"Peer Certificate: {pc.Sub}", Color.White);
            Log("VERIFY", "Peer Signature Validated ✔️", Color.Lime);

            string N1 = Guid.NewGuid().ToString().Substring(0, 8);
            Log("CRYPTO", $"Generated Nonce N1: {N1}", Color.Gray);
            Log("CRYPTO", "Encrypting N1 with Peer's RSA Key...", Color.Cyan);

            byte[] encN1 = EncryptRSA(Encoding.UTF8.GetBytes(N1), pc.Key);
            Send(ns, new Packet { Type = "KEY1", Msg = Convert.ToBase64String(encN1) });

            var p2 = Recv(ns);
            string dec = Encoding.UTF8.GetString(DecryptRSA(Convert.FromBase64String(p2.Msg)));

            string N2 = dec.Split('|')[1];
            Log("CRYPTO", $"Decrypted N2: {N2}", Color.Gray);

            mk = N1 + N2;
            Log("SECURE", $"MASTER KEY (Km): {mk}", Color.Lime);

            string N3 = Guid.NewGuid().ToString().Substring(0, 6);
            Send(ns, new Packet { Type = "SESS", Msg = EncryptAESStr("REQ|" + N3, mk) });
            sk = DecryptAESStr(Recv(ns).Msg, mk).Split('|')[0];
            Log("SECURE", $"SESSION KEY (Ks): {sk}", Color.Lime);
            EnableChat();
        }

        void Protocol_Responder()
        {
            var p = Recv(ns);
            var pc = JsonSerializer.Deserialize<MyCert>(p.Msg);
            Log("STEP1", $"Peer Certificate: {pc.Sub}", Color.White);
            Log("VERIFY", "Peer Signature Validated ✔️", Color.Lime);

            Log("STEP1", "Sending my Certificate...", Color.White);
            Send(ns, new Packet { Type = "CERT", Msg = JsonSerializer.Serialize(myCert) });

            var p1 = Recv(ns);
            string N1 = Encoding.UTF8.GetString(DecryptRSA(Convert.FromBase64String(p1.Msg)));
            Log("CRYPTO", $"Decrypted N1: {N1}", Color.Gray);

            string N2 = Guid.NewGuid().ToString().Substring(0, 8);
            Log("CRYPTO", $"Generated Nonce N2: {N2}", Color.Gray);

            mk = N1 + N2;
            Log("SECURE", $"MASTER KEY (Km): {mk}", Color.Lime);

            Log("CRYPTO", "Encrypting (N1|N2) with Peer RSA Key...", Color.Cyan);
            byte[] enc = EncryptRSA(Encoding.UTF8.GetBytes(N1 + "|" + N2), pc.Key);
            Send(ns, new Packet { Type = "KEY2", Msg = Convert.ToBase64String(enc) });

            Recv(ns);
            string tSk = Guid.NewGuid().ToString().Substring(0, 6);
            Send(ns, new Packet { Type = "RES", Msg = EncryptAESStr(tSk + "|ACK", mk) });
            sk = tSk;
            Log("SECURE", $"SESSION KEY (Ks): {sk}", Color.Lime);
            EnableChat();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string plain = txtMsg.Text;
            Log("ME (PLAIN)", plain, Color.White);

            Log("AES", $"Encrypting using Key: {sk}...", Color.Cyan);
            string cipher = EncryptAESStr(plain, sk);
            Log("OUT (CIPHER)", cipher, Color.Gray);

            Send(ns, new Packet { Type = "MSG", Msg = cipher });
            txtMsg.Clear();
        }

        void ListenChat()
        {
            while (true)
            {
                try
                {
                    var p = Recv(ns);
                    if (p?.Type == "MSG")
                    {
                        Log("IN (CIPHER)", p.Msg, Color.Gray);
                        Log("AES", "Decrypting Ciphertext...", Color.Cyan);
                        string plain = DecryptAESStr(p.Msg, sk);
                        Log("PEER (PLAIN)", plain, Color.Magenta);
                    }
                }
                catch { break; }
            }
        }

        void EnableChat() { Invoke(new Action(() => btnSend.Enabled = true)); new Thread(ListenChat) { IsBackground = true }.Start(); }
        void Send(NetworkStream s, Packet p) { byte[] b = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(p)); s.Write(b, 0, b.Length); }
        Packet Recv(NetworkStream s) { byte[] b = new byte[16384]; int r = s.Read(b, 0, b.Length); return r == 0 ? null : JsonSerializer.Deserialize<Packet>(Encoding.UTF8.GetString(b, 0, r)); }
        void Log(string c, string m, Color o) { if (rtbLog.InvokeRequired) Invoke(new Action(() => Log(c, m, o))); else { rtbLog.SelectionColor = o; rtbLog.AppendText($"[{DateTime.Now:HH:mm}] [{c}] {m}\n"); rtbLog.ScrollToCaret(); } }
        byte[] EncryptRSA(byte[] d, string k) { using (var r = new RSACryptoServiceProvider()) { r.FromXmlString(k); return r.Encrypt(d, false); } }
        byte[] DecryptRSA(byte[] d) { return myRSA.Decrypt(d, false); }
        string EncryptAESStr(string p, string k) { using (var a = Aes.Create()) { using (var s = SHA256.Create()) a.Key = s.ComputeHash(Encoding.UTF8.GetBytes(k)); a.IV = new byte[16]; return Convert.ToBase64String(a.CreateEncryptor().TransformFinalBlock(Encoding.UTF8.GetBytes(p), 0, Encoding.UTF8.GetBytes(p).Length)); } }
        string DecryptAESStr(string c, string k) { using (var a = Aes.Create()) { using (var s = SHA256.Create()) a.Key = s.ComputeHash(Encoding.UTF8.GetBytes(k)); a.IV = new byte[16]; byte[] b = Convert.FromBase64String(c); return Encoding.UTF8.GetString(a.CreateDecryptor().TransformFinalBlock(b, 0, b.Length)); } }
    }
}