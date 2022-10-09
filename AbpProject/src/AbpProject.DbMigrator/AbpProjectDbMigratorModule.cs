using AbpProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpProjectEntityFrameworkCoreModule),
    typeof(AbpProjectApplicationContractsModule)
    )]
public class AbpProjectDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
