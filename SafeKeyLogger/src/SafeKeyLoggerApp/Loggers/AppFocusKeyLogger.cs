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
using System;
using SafeKeyLoggerApp.Interfaces;
using SafeKeyLoggerApp.Models;

namespace SafeKeyLoggerApp.Loggers
{
    public class AppFocusKeyLogger : IKeyLogger
    {
        private readonly IStorage storage;
        private bool running = false;
        public event Action<LogEntry>? OnLog;

        public AppFocusKeyLogger(IStorage storage)
        {
            this.storage = storage;
        }

        public void Start() => running = true;
        public void Stop() => running = false;

        // Called by the Form's key events
        public void AppendLocal(string description)
        {
            if (!running) return;
            var entry = new LogEntry { Timestamp = DateTime.Now, Description = description };
            storage.Append(entry);
            OnLog?.Invoke(entry);
        }
    }
}
