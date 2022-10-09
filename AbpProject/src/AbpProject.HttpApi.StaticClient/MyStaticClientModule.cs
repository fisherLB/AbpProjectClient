using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace AbpProject.HttpApi.StaticClient
{
    [DependsOn(typeof(AbpHttpClientModule),
        typeof(AbpProjectApplicationContractsModule))]
    public class MyStaticClientModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //prepare for static client proxy generation 
            context.Services.AddStaticHttpClientProxies(typeof(AbpProjectApplicationContractsModule).Assembly);
        }
    }
}