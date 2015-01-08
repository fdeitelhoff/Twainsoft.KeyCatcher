namespace Twainsoft.KeyCatcher.Core.Keyboard
{
    public class SessionStartedEventArgs
    {
        public KeyboardSession KeyboardSession { get; set; }

        public SessionStartedEventArgs(KeyboardSession keyboardSession)
        {
            KeyboardSession = keyboardSession;
        }
    }
}
