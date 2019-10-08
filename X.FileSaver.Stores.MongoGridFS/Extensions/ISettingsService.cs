using System;
using System.Collections.Generic;
using System.Text;
using X.FileSaver.Stores.MongoGridFS.Settings;
using Volo.Abp.DependencyInjection;

namespace X.FileSaver.Stores.MongoGridFS.Extensions
{
    public interface ISettingsService : ITransientDependency
    {
        MongoDBAppSettings GetMongoDBAppSettings();
    }
}
