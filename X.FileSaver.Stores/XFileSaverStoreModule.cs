using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using X.FileSaver.Store;
using X.FileSaver.Stores.Local;

namespace X.FileSaver.Stores
{

    [DependsOn(typeof(XFileSaverModule))]
    public class XFileSaverStoreModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            //Configure<LocalFileOptions>(options => {
            //    options.LocalFolder = "C:\\Users\\Default\\Downloads";
            //});

            Configure<FileStoreOptions>(options => {
                options.AddStore<LocalFileStore>();
            });
        }
    }
}
