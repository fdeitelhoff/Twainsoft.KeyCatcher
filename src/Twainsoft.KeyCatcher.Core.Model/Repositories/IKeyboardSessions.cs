using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.Core.Model.Repositories
{
    public interface IKeyboardSessions
    {
        void Create(KeyboardSession keyboardSession);
    }
}
