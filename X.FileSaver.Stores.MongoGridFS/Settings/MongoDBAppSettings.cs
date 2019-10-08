using System;
using System.Collections.Generic;
using System.Text;

namespace X.FileSaver.Stores.MongoGridFS.Settings
{
    public class MongoDBAppSettings
    {
        public MongoDBAppSettings()
        {
            ConnectionString = "mongodb://localhost:27017";
        }
        public string ConnectionString { get; set; }
    }
}
