using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Until;

namespace DeveloperProduct.DatabaseProvider
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private IDatabaseProvider _databaseProvider;
        public DbConnection GetDatabaseProviderConnection(DatabaseProviderName databaseProviderName)
        {
            switch (databaseProviderName)
            {
                case DatabaseProviderName.ORACLE:
                    _databaseProvider = new OracleProvider();
                    break;
                default:
                    _databaseProvider = new OracleProvider();
                    break;
            }

            return _databaseProvider.GetDbConnection();
        }
    }
}
