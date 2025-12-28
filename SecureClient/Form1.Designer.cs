namespace SecureClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlConnect = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtTargetPort = new System.Windows.Forms.TextBox();
            this.lblTargetPort = new System.Windows.Forms.Label();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.txtTargetUser = new System.Windows.Forms.TextBox();
            this.lblTargetUser = new System.Windows.Forms.Label();
            this.lblSection3 = new System.Windows.Forms.Label();
            this.pnlListen = new System.Windows.Forms.Panel();
            this.btnListen = new System.Windows.Forms.Button();
            this.txtMyPort = new System.Windows.Forms.TextBox();
            this.lblMyPort = new System.Windows.Forms.Label();
            this.lblSection2 = new System.Windows.Forms.Label();
            this.pnlCA = new System.Windows.Forms.Panel();
            this.btnGetCert = new System.Windows.Forms.Button();
            this.txtCAIP = new System.Windows.Forms.TextBox();
            this.btnFindCA = new System.Windows.Forms.Button();
            this.lblSection1 = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.pnlSidebar.SuspendLayout();
            this.pnlConnect.SuspendLayout();
            this.pnlListen.SuspendLayout();
            this.pnlCA.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlChat.SuspendLayout();
            this.SuspendLayout();


            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlSidebar.Controls.Add(this.pnlConnect);
            this.pnlSidebar.Controls.Add(this.lblSection3);
            this.pnlSidebar.Controls.Add(this.pnlListen);
            this.pnlSidebar.Controls.Add(this.lblSection2);
            this.pnlSidebar.Controls.Add(this.pnlCA);
            this.pnlSidebar.Controls.Add(this.lblSection1);
            this.pnlSidebar.Controls.Add(this.pnlUser);
            this.pnlSidebar.Controls.Add(this.pnlHeader);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 661);
            this.pnlSidebar.TabIndex = 0;


            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(250, 50);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "🛡️ SECURE CHAT tobeshko";


            this.pnlUser.Controls.Add(this.txtName);
            this.pnlUser.Controls.Add(this.lblUsername);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUser.Padding = new System.Windows.Forms.Padding(10);
            this.pnlUser.Size = new System.Drawing.Size(250, 60);

            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.Silver;
            this.lblUsername.Location = new System.Drawing.Point(13, 3);
            this.lblUsername.Text = "Username";

            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(16, 25);
            this.txtName.Size = new System.Drawing.Size(215, 20);
            this.txtName.Text = "your username";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.lblSection1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSection1.ForeColor = System.Drawing.Color.White;
            this.lblSection1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.lblSection1.Text = "SETUP & CERTIFICATE";
            this.lblSection1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSection1.Size = new System.Drawing.Size(250, 30);

            this.pnlCA.Controls.Add(this.btnGetCert);
            this.pnlCA.Controls.Add(this.txtCAIP);
            this.pnlCA.Controls.Add(this.btnFindCA);
            this.pnlCA.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCA.Size = new System.Drawing.Size(250, 110);
            this.pnlCA.Padding = new System.Windows.Forms.Padding(15);

            this.btnFindCA.BackColor = System.Drawing.Color.DarkOrange;
            this.btnFindCA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindCA.ForeColor = System.Drawing.Color.White;
            this.btnFindCA.Location = new System.Drawing.Point(15, 10);
            this.btnFindCA.Size = new System.Drawing.Size(100, 30);
            this.btnFindCA.Text = "📡 Find CA";
            this.btnFindCA.Click += new System.EventHandler(this.btnFindCA_Click);

            this.txtCAIP.BackColor = System.Drawing.Color.Black;
            this.txtCAIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCAIP.ForeColor = System.Drawing.Color.Cyan;
            this.txtCAIP.Location = new System.Drawing.Point(125, 15);
            this.txtCAIP.Size = new System.Drawing.Size(105, 23);
            this.txtCAIP.ReadOnly = true;
            this.txtCAIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCAIP.Text = "...";

            this.btnGetCert.BackColor = System.Drawing.Color.Brown;
            this.btnGetCert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetCert.ForeColor = System.Drawing.Color.White;
            this.btnGetCert.Location = new System.Drawing.Point(15, 50);
            this.btnGetCert.Size = new System.Drawing.Size(215, 40);
            this.btnGetCert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGetCert.Text = "GET CERTIFICATE";
            this.btnGetCert.Click += new System.EventHandler(this.btnGetCert_Click);

            this.lblSection2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSection2.ForeColor = System.Drawing.Color.White;
            this.lblSection2.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.lblSection2.Text = "LISTEN";
            this.lblSection2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSection2.Size = new System.Drawing.Size(250, 30);

            this.pnlListen.Controls.Add(this.btnListen);
            this.pnlListen.Controls.Add(this.txtMyPort);
            this.pnlListen.Controls.Add(this.lblMyPort);
            this.pnlListen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListen.Size = new System.Drawing.Size(250, 90);

            this.lblMyPort.AutoSize = true; this.lblMyPort.ForeColor = System.Drawing.Color.Silver;
            this.lblMyPort.Location = new System.Drawing.Point(15, 10); this.lblMyPort.Text = "My Port:";

            this.txtMyPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtMyPort.ForeColor = System.Drawing.Color.White;
            this.txtMyPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMyPort.Location = new System.Drawing.Point(70, 8);
            this.txtMyPort.Size = new System.Drawing.Size(160, 23);

            this.btnListen.BackColor = System.Drawing.Color.DarkBlue; 
            this.btnListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListen.ForeColor = System.Drawing.Color.White;
            this.btnListen.Location = new System.Drawing.Point(15, 40);
            this.btnListen.Size = new System.Drawing.Size(215, 35);
            this.btnListen.Text = "LISTEN & REGISTER";
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);

            this.lblSection3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSection3.ForeColor = System.Drawing.Color.White;
            this.lblSection3.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.lblSection3.Text = "CONNECT";
            this.lblSection3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSection3.Size = new System.Drawing.Size(250, 30);

            this.pnlConnect.Controls.Add(this.btnConnect);
            this.pnlConnect.Controls.Add(this.txtTargetPort);
            this.pnlConnect.Controls.Add(this.lblTargetPort);
            this.pnlConnect.Controls.Add(this.btnFindUser);
            this.pnlConnect.Controls.Add(this.txtTargetUser);
            this.pnlConnect.Controls.Add(this.lblTargetUser);
            this.pnlConnect.Dock = System.Windows.Forms.DockStyle.Fill; 
            this.pnlConnect.Size = new System.Drawing.Size(250, 200);

            this.lblTargetUser.AutoSize = true; this.lblTargetUser.ForeColor = System.Drawing.Color.Silver;
            this.lblTargetUser.Location = new System.Drawing.Point(15, 10); this.lblTargetUser.Text = "Chat with:";

            this.txtTargetUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtTargetUser.ForeColor = System.Drawing.Color.White;
            this.txtTargetUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetUser.Location = new System.Drawing.Point(15, 30);
            this.txtTargetUser.Size = new System.Drawing.Size(130, 23);

            this.btnFindUser.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFindUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindUser.ForeColor = System.Drawing.Color.White;
            this.btnFindUser.Location = new System.Drawing.Point(150, 29);
            this.btnFindUser.Size = new System.Drawing.Size(80, 25);
            this.btnFindUser.Text = "🔍 Find";
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);

            this.lblTargetPort.AutoSize = true; this.lblTargetPort.ForeColor = System.Drawing.Color.Silver;
            this.lblTargetPort.Location = new System.Drawing.Point(15, 70); this.lblTargetPort.Text = "Target Port:";

            this.txtTargetPort.BackColor = System.Drawing.Color.Black;
            this.txtTargetPort.ForeColor = System.Drawing.Color.Yellow;
            this.txtTargetPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetPort.Location = new System.Drawing.Point(90, 68);
            this.txtTargetPort.Size = new System.Drawing.Size(140, 23);

            this.btnConnect.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(15, 105);
            this.btnConnect.Size = new System.Drawing.Size(215, 40);
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConnect.Text = "CONNECT NOW";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            this.pnlMain.Controls.Add(this.rtbLog);
            this.pnlMain.Controls.Add(this.pnlChat);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(250, 0);
            this.pnlMain.Size = new System.Drawing.Size(534, 661);

            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Size = new System.Drawing.Size(534, 591);
            this.rtbLog.Text = "";
            this.rtbLog.Padding = new System.Windows.Forms.Padding(10);

            this.pnlChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnlChat.Controls.Add(this.btnSend);
            this.pnlChat.Controls.Add(this.txtMsg);
            this.pnlChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChat.Size = new System.Drawing.Size(534, 70);
            this.pnlChat.Padding = new System.Windows.Forms.Padding(10);

            this.txtMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMsg.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMsg.ForeColor = System.Drawing.Color.White;
            this.txtMsg.Location = new System.Drawing.Point(15, 20);
            this.txtMsg.Size = new System.Drawing.Size(400, 29);
            this.txtMsg.PlaceholderText = "Type your secure message...";

            this.btnSend.BackColor = System.Drawing.Color.MediumPurple;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(425, 18);
            this.btnSend.Size = new System.Drawing.Size(90, 33);
            this.btnSend.Text = "SEND";
            this.btnSend.Enabled = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "Form1";
            this.Text = "Secure Messenger Pro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.pnlSidebar.ResumeLayout(false);
            this.pnlConnect.ResumeLayout(false); this.pnlConnect.PerformLayout();
            this.pnlListen.ResumeLayout(false); this.pnlListen.PerformLayout();
            this.pnlCA.ResumeLayout(false); this.pnlCA.PerformLayout();
            this.pnlUser.ResumeLayout(false); this.pnlUser.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlChat.ResumeLayout(false); this.pnlChat.PerformLayout();
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.TextBox txtName, txtCAIP, txtMyPort, txtTargetPort, txtTargetUser, txtMsg;
        private System.Windows.Forms.Button btnFindCA, btnGetCert, btnListen, btnFindUser, btnConnect, btnSend;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Panel pnlSidebar, pnlHeader, pnlUser, pnlCA, pnlListen, pnlConnect, pnlMain, pnlChat;
        private System.Windows.Forms.Label lblTitle, lblUsername, lblSection1, lblSection2, lblSection3, lblMyPort, lblTargetUser, lblTargetPort;
    }
}