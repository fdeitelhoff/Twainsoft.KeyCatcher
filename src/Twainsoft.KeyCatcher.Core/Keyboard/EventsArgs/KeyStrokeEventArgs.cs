using System;
using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.Core.Keyboard.EventsArgs
{
    public class KeyStrokeEventArgs : EventArgs
    {
        public KeyboardSession KeyboardSession { get; private set; }

        public KeyStrokeEventArgs(KeyboardSession keyboardSession)
        {
            KeyboardSession = keyboardSession;
        }
    }
}
