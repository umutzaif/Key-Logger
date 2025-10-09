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
using System.Windows.Forms;

namespace SafeKeyLoggerApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
