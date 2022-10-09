using Volo.Abp.Modularity;

namespace AbpProject;

[DependsOn(
    typeof(AbpProjectApplicationModule),
    typeof(AbpProjectDomainTestModule)
    )]
public class AbpProjectApplicationTestModule : AbpModule
{

}
