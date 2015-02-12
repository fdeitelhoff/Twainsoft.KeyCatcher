namespace Twainsoft.KeyCatcher.Core.Model.Persistence
{
    public interface IPersistence
    {
        void CreateDatabase(string path, string file);
    }
}
