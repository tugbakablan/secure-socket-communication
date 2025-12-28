namespace CertificateAuthority
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            labelIP = new Label();
            txtIP = new TextBox();
            labelPort = new Label();
            txtPort = new TextBox();
            btnStart = new Button();
            rtbLog = new RichTextBox();
            SuspendLayout();

            labelIP.AutoSize = true;
            labelIP.Font = new Font("Consolas", 10F, FontStyle.Bold);
            labelIP.Location = new Point(20, 25);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(171, 20);
            labelIP.TabIndex = 0;
            labelIP.Text = "SERVER IP ADDRESS:";

            txtIP.BackColor = Color.FromArgb(40, 40, 40);
            txtIP.BorderStyle = BorderStyle.FixedSingle;
            txtIP.ForeColor = Color.Cyan;
            txtIP.Location = new Point(194, 22);
            txtIP.Name = "txtIP";
            txtIP.PlaceholderText = "e.g. 192.168.1.10";
            txtIP.Size = new Size(150, 27);
            txtIP.TabIndex = 1;

            labelPort.AutoSize = true;
            labelPort.Font = new Font("Consolas", 10F, FontStyle.Bold);
            labelPort.Location = new Point(350, 25);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(54, 20);
            labelPort.TabIndex = 2;
            labelPort.Text = "PORT:";

            txtPort.BackColor = Color.FromArgb(40, 40, 40);
            txtPort.BorderStyle = BorderStyle.FixedSingle;
            txtPort.ForeColor = Color.Yellow;
            txtPort.Location = new Point(400, 23);
            txtPort.Name = "txtPort";
            txtPort.ReadOnly = true;
            txtPort.Size = new Size(60, 27);
            txtPort.TabIndex = 3;
            txtPort.Text = "5560";

            btnStart.BackColor = Color.DarkGreen;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Location = new Point(480, 20);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(138, 28);
            btnStart.TabIndex = 4;
            btnStart.Text = "START SERVER & BROADCAST";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
 
            rtbLog.BackColor = Color.Black;
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Font = new Font("Consolas", 9F);
            rtbLog.ForeColor = Color.LimeGreen;
            rtbLog.Location = new Point(20, 70);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(610, 400);
            rtbLog.TabIndex = 5;
            rtbLog.Text = "";

            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(650, 500);
            Controls.Add(labelIP);
            Controls.Add(txtIP);
            Controls.Add(labelPort);
            Controls.Add(txtPort);
            Controls.Add(btnStart);
            Controls.Add(rtbLog);
            ForeColor = Color.White;
            Name = "Form1";
            Text = "SERVER CA";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelIP, labelPort;
        public System.Windows.Forms.TextBox txtIP, txtPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}