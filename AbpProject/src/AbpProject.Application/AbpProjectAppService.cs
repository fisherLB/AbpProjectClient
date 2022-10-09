using System;
using System.Collections.Generic;
using System.Text;
using AbpProject.Localization;
using Volo.Abp.Application.Services;

namespace AbpProject;

/* Inherit your application services from this class.
 */
public abstract class AbpProjectAppService : ApplicationService
{
    protected AbpProjectAppService()
    {
        LocalizationResource = typeof(AbpProjectResource);
    }
}
