using System;
using Volo.Abp.Modularity;
using X.FileSaver.Store;
using X.FileSaver.Stores.MongoGridFS.Settings;

namespace X.FileSaver.Stores.MongoGridFS
{

    [DependsOn(typeof(XFileSaverStoreModule))]
    public class FileSaverStoreMongoGridFSModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            //Configure<MongoDBAppSettings>(options =>
            //{

            //});
            Configure<FileStoreOptions>(options => {
                options.AddStore<MongoGridStore>();
            });
        }


    }
}
