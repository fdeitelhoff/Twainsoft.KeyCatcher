using System;

namespace Twainsoft.KeyCatcher.Core.Keyboard
{
    public class KeyStrokeEventArgs : EventArgs
    {
        public long KeyStrokes { get; set; }

        public KeyStrokeEventArgs(long keyStroke)
        {
            KeyStrokes = keyStroke;
        }
    }
}
