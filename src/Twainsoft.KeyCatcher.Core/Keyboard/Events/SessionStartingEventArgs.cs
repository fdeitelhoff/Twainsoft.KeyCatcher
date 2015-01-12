using System;

namespace Twainsoft.KeyCatcher.Core.Keyboard.Events
{
    public class SessionStartingEventArgs : EventArgs
    {
        public bool SessionStart { get; set; }

        public SessionStartingEventArgs(bool sessionStart)
        {
            SessionStart = sessionStart;
        }
    }
}
