using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperProduct.DatabaseProvider
{
    public class OracleProvider : IDatabaseProvider
    {
        public DbConnection GetDbConnection()
        {
           
            var host = "BCDAI.ldap.cmcglobal.com.vn";
            var port = 1521;
            var sid = "localhost";
            var user = "buidai";
            var password = "1234";

            var connString =
                $"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = tcp)(HOST = {host})(PORT = {port}))(CONNECT_DATA = (SERVICE_NAME = {sid})));Password={password};User ID={user}";
            var dbConnection = new OracleConnection
            {
                ConnectionString = connString
            };
            return dbConnection;
        }
    }
}
