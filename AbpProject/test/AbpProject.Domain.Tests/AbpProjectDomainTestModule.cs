using AbpProject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpProject;

[DependsOn(
    typeof(AbpProjectEntityFrameworkCoreTestModule)
    )]
public class AbpProjectDomainTestModule : AbpModule
{

}
