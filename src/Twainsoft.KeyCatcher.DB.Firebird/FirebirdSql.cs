using System.IO;
using FirebirdSql.Data.FirebirdClient;
using Twainsoft.KeyCatcher.Core.Model.Persistence;

namespace Twainsoft.KeyCatcher.DB.Firebird
{
    public class FirebirdSql : IPersistence
    {
        private string DatabasePath { get; set; }
        private string DatabaseFile { get; set; }

        public FbConnectionStringBuilder ConnectionBuilder { get; private set; }

        public FirebirdSql()
        {
            DatabasePath = "Data";
            DatabaseFile = "Twainsoft.KeyCatcher.fdb";

            ConnectionBuilder = new FbConnectionStringBuilder
            {
                ServerType = FbServerType.Embedded,
                UserID = "Twainsoft.KeyCatcher",
                Password = "test",
                Dialect = 3,
                Database = Path.Combine(DatabasePath, DatabaseFile)
            };
        }

        public void CreateDatabase()
        {
            // Check if the path and or file already exists.
            if (!Directory.Exists(DatabasePath))
            {
                Directory.CreateDirectory(DatabasePath);
            }

            var databaseFile = Path.Combine(DatabasePath, DatabaseFile);

            if (!File.Exists(databaseFile))
            {
                FbConnection.CreateDatabase(ConnectionBuilder.ConnectionString);

                CreateDatabaseSchema();
            }
        }

        private void CreateDatabaseSchema()
        {
            
        }
    }
}
