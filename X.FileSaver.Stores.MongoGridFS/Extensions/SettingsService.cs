using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using X.FileSaver.Stores.MongoGridFS.Settings;

namespace X.FileSaver.Stores.MongoGridFS.Extensions
{
    public class SettingsService : ISettingsService
    {
        private readonly MongoDBAppSettings _mongoDBAppSettings;

        public SettingsService(IOptions<MongoDBAppSettings> mongoDBAppSettings)
        {
            _mongoDBAppSettings = mongoDBAppSettings.Value;
        }
        public MongoDBAppSettings GetMongoDBAppSettings()
        {
            return _mongoDBAppSettings;
        }
    }
}
