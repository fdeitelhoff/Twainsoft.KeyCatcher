using System;
using Twainsoft.KeyCatcher.Core.Keyboard.Sessions;

namespace Twainsoft.KeyCatcher.Core.Keyboard.EventsArgs
{
    public class SessionStatusChangingEventArgs : EventArgs
    {
        public string SessionName { get; private set; }
        public bool ExitApplication { get; private set; }
        public KeyboardSession KeyboardSession { get; private set; }

        public SessionStatusChangingEventArgs(string sessionName, bool exitApplication, KeyboardSession keyboardSession)
        {
            SessionName = sessionName;
            ExitApplication = exitApplication;
            KeyboardSession = keyboardSession;
        }
    }
}
