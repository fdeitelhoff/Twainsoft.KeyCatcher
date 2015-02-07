using System.Data.Entity;
using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.DB.Firebird
{
    public class KeyboardSessionContext : DbContext
    {
        public DbSet<KeyboardSession> KeyboardSessions { get; set; }

        public KeyboardSessionContext() : base()
        { }
    }
}
