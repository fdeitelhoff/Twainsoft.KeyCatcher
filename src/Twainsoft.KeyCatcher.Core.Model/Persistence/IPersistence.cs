namespace Twainsoft.KeyCatcher.Core.Model.Persistence
{
    public interface IPersistence
    {
        string ConnectionString { get; }

        void CopyDatabaseTemplate();
    }
}
