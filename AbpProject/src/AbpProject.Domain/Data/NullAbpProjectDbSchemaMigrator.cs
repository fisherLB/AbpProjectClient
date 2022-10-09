using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpProject.Data;

/* This is used if database provider does't define
 * IAbpProjectDbSchemaMigrator implementation.
 */
public class NullAbpProjectDbSchemaMigrator : IAbpProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
