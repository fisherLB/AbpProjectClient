using System.Threading.Tasks;

namespace AbpProject.Data;

public interface IAbpProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
