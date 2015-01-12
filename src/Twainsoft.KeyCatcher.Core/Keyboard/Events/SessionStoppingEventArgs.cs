using System;

namespace Twainsoft.KeyCatcher.Core.Keyboard.Events
{
    public class SessionStoppingEventArgs : EventArgs
    {
        public string SessionName { get; set; }

        public SessionStoppingEventArgs(string sessionName)
        {
            SessionName = sessionName;
        }
    }
}
