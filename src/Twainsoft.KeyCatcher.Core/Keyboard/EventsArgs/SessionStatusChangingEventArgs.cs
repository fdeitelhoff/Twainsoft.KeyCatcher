using System;

namespace Twainsoft.KeyCatcher.Core.Keyboard.EventsArgs
{
    public class SessionStatusChangingEventArgs : EventArgs
    {
        public string SessionName { get; private set; }
        public bool ExitApplication { get; private set; }

        public SessionStatusChangingEventArgs(string sessionName, bool exitApplication)
        {
            SessionName = sessionName;
            ExitApplication = exitApplication;
        }
    }
}
