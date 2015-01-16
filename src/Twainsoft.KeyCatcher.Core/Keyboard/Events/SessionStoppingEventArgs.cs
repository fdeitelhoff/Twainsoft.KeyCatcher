using System;

namespace Twainsoft.KeyCatcher.Core.Keyboard.Events
{
    public class SessionStoppingEventArgs : EventArgs
    {
        public string SessionName { get; private set; }

        public SessionStoppingEventArgs(string sessionName)
        {
            SessionName = sessionName;
        }
    }
}
