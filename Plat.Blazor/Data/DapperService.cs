using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Plat.Blazor.Data
{
    public class DapperService
    {
        private string connectionString;
        public DapperService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("PlatConnection");
        }

        public  List<dynamic> QueryPu()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var sql = "select * from SUF_PROGRAMUNIT_TB";
                //参数类型是Array的时候，dappper会自动将其转化
                return connection.Query<dynamic>(sql).ToList();
            }
        }
    }
}
