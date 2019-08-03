using System.Data.Common;
using Until;

namespace DeveloperProduct.DatabaseProvider
{
    public interface IDatabaseFactory
    {
        DbConnection GetDatabaseProviderConnection(DatabaseProviderName databaseProviderName);
    }
}