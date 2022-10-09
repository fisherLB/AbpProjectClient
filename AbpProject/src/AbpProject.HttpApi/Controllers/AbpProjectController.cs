using AbpProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpProjectController : AbpControllerBase
{
    protected AbpProjectController()
    {
        LocalizationResource = typeof(AbpProjectResource);
    }
}
