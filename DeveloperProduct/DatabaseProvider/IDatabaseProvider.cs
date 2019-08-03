using System.Data.Common;

namespace DeveloperProduct.DatabaseProvider
{
    public interface IDatabaseProvider
    {
        DbConnection GetDbConnection();
    }
}