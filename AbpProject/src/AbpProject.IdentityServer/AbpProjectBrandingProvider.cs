using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AbpProject;

[Dependency(ReplaceServices = true)]
public class AbpProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpProject";
}
