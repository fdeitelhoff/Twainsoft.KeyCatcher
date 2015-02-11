using FirebirdSql.Data.FirebirdClient;

namespace Twainsoft.KeyCatcher.DB.Firebird
{
    public static class Database
    {
        public static void CreateDatabase()
        {
            FbConnection.CreateDatabase("ServerType=1;User=SYSDBA;" +
                 "Password=test;Dialect=3;Database=Twainsoft.KeyCatcher.fdb");
        }
    }
}
