using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using X.FileSaver.Stores;
using X.FileSaver.Stores.Local;

namespace X.FileSaver.DemoApp
{

    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(XFileSaverStoreModule)
        )]
    public class XFileSaverDemoModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.BuildConfiguration();

            Configure<LocalFileOptions>(options =>
            {
                options.LocalFolder = Path.Combine(hostingEnvironment.WebRootPath, "files/Data/{0}");
            });

            Configure<StaticFileOptions>(options =>
            {

            });

            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new Info { Title = "Files API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    //options.CustomSchemaIds(type => type.FullName);
                });

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();


            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");
            //});

            app.UseRouting();
            app.UseMvcWithDefaultRouteAndArea();
        }

    }
}
