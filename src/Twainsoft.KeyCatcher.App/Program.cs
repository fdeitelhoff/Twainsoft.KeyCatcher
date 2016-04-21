using System;
using System.Threading;
using System.Windows.Forms;
using Ninject;
using Twainsoft.KeyCatcher.Core.Keyboard;
using Twainsoft.KeyCatcher.Core.Model.Persistence;
using Twainsoft.KeyCatcher.Core.Model.Repositories;
using Twainsoft.KeyCatcher.Core.Win32;
using Twainsoft.KeyCatcher.DB.Firebird;
using Twainsoft.KeyCatcher.GUI.App;

namespace Twainsoft.KeyCatcher.App
{
    internal static class Program
    {
        private static readonly Mutex ApplicationMutex = new Mutex(true, "{543AE34C-96B7-4A9D-8747-9F2EF5200875}");

        [STAThread]
        private static void Main()
        {
            if (ApplicationMutex.WaitOne(TimeSpan.Zero, true))
            {
                // TODO: Maybe decouple this into an NinjectModule?
                // Initialize the DI-Container.
                var kernel = new StandardKernel();

                // TODO: Maybe bind to an interface?! Not sure because of a win form class.
                kernel.Bind<Main>().ToSelf();
                    
                kernel.Bind<IPersistence>().To<FirebirdSql>().InSingletonScope();
                kernel.Bind<KeyboardCatcher>().ToSelf(); // TODO: Bind to an interface!
                kernel.Bind<IKeyboardSessions>().To<KeyboardSessions>();

                // If there's no database we need one first.
                var firebirdSql = kernel.Get<IPersistence>();
                // TODO: Maybe move this into the constructor to call the method the first time automatically?
                firebirdSql.CopyDatabaseTemplate();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(kernel.Get<Main>());

                ApplicationMutex.ReleaseMutex();
            }
            else
            {
                // Send our Win32 message to inform the currently running instance.
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HwndBroadcast,
                    NativeMethods.WmShowme,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }
    }
}
