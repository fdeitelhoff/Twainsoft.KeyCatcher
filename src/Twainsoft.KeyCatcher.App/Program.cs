using System;
using System.Windows.Forms;
using Ninject;
using Twainsoft.KeyCatcher.Core.Keyboard;
using Twainsoft.KeyCatcher.Core.Model.Persistence;
using Twainsoft.KeyCatcher.Core.Model.Repositories;
using Twainsoft.KeyCatcher.DB.Firebird;
using Twainsoft.KeyCatcher.GUI;
using Twainsoft.KeyCatcher.GUI.Session;

namespace Twainsoft.KeyCatcher.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // TODO: Maybe decouple this into an NinjectModule?
            // Initialize the DI-Container.
            var kernel = new StandardKernel();
            kernel.Bind<Main>().ToSelf();                                           // TODO: Maybe bind to an interface?! Not sure because of a win form class.
            kernel.Bind<SessionsOverview>().ToSelf();                               // TODO: And again: Bind to an interface?
            kernel.Bind<IPersistence>().To<FirebirdSql>().InSingletonScope();
            kernel.Bind<KeyboardCatcher>().ToSelf();                                // TODO: Bind to an interface!
            kernel.Bind<IKeyboardSessions>().To<KeyboardSessions>();

            // If there's no database we need one first.
            var firebirdSql = kernel.Get<IPersistence>();
            firebirdSql.CopyDatabaseTemplate();                                     // TODO: Maybe move this into the constructor to call the method the first time automatically?

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(kernel.Get<Main>());
        }
    }
}
