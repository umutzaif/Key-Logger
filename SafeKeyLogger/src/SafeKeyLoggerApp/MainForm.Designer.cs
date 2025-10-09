/*
Legal Notice/Yasal Uyarı
EN
This app should not be used to violate personal data. 
Logging and sharing keystrokes without permission is unethical. 
This repo was created solely for educational purposes to answer the question "How Does a Key Logger Work?" 
Any illegal use is at the user's risk.

TR
Bu uygulama kişisel verileri ihlal etmek için kullanılmamalıdır. 
Tuş vuruşlarını izinsiz kaydetmek ve paylaşmak etik dışıdır. 
Bu repo, "Key Logger Nasıl Çalışır?" sorusuna yanıt vermek amacıyla yalnızca eğitim amaçlı oluşturulmuştur.
Herhangi bir yasa dışı kullanım kullanıcının sorumluluğundadır.

*/
namespace SafeKeyLoggerApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // textBoxLogs
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Location = new System.Drawing.Point(12,12);
            this.textBoxLogs.Size = new System.Drawing.Size(560,340);
            // btnStart
            this.btnStart.Location = new System.Drawing.Point(12,360);
            this.btnStart.Size = new System.Drawing.Size(100,30);
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // btnStop
            this.btnStop.Location = new System.Drawing.Point(118,360);
            this.btnStop.Size = new System.Drawing.Size(100,30);
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // btnExport
            this.btnExport.Location = new System.Drawing.Point(224,360);
            this.btnExport.Size = new System.Drawing.Size(140,30);
            this.btnExport.Text = "Export (Outbox)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(584,401);
            this.Controls.Add(this.textBoxLogs);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnExport);
            this.Name = "MainForm";
            this.Text = "SafeKeyLogger - Demo";
            this.KeyPreview = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
