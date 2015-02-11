using System;
using System.Windows.Forms;
using Twainsoft.KeyCatcher.DB.Firebird;

namespace Twainsoft.KeyCatcher.GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Database.CreateDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
