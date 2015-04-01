using System.IO;
using FirebirdSql.Data.FirebirdClient;
using Twainsoft.KeyCatcher.Core.Model.Persistence;
using Twainsoft.KeyCatcher.DB.Firebird.Properties;

namespace Twainsoft.KeyCatcher.DB.Firebird
{
    public class FirebirdSql : IPersistence
    {
        private string DatabasePath { get; set; }
        private string DatabaseFile { get; set; }

        private FbConnectionStringBuilder ConnectionBuilder { get; set; }

        public string ConnectionString
        {
            get { return ConnectionBuilder.ConnectionString; }
        }

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
                Pooling = true,
                Role = "Admin",
                Database = Path.Combine(DatabasePath, DatabaseFile)
            };
        }

        public void CopyDatabaseTemplate()
        {
            // Check if the path and or file already exists.
            if (!Directory.Exists(DatabasePath))
            {
                Directory.CreateDirectory(DatabasePath);
            }

            var databaseFile = Path.Combine(DatabasePath, DatabaseFile);

            if (!File.Exists(databaseFile))
            {
                File.WriteAllBytes(Path.Combine(DatabasePath, DatabaseFile), Resources.Database_Template);
            }
        }
    }
}
