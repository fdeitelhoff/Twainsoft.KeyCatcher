using System;
using System.Windows.Forms;
using Twainsoft.KeyCatcher.DB.Firebird;
using Twainsoft.KeyCatcher.GUI;

namespace Twainsoft.KeyCatcher.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // If there's no database we need one first.
            var firebirdSql = new FirebirdSql();
            firebirdSql.CreateDatabase("Data", "Twainsoft.KeyCatcher.fdb");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
