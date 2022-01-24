using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Plat.Blazor.Data
{
    public class PuService
    {
        private readonly static  string connectionString= "server=192.168.0.4;database=platsql;uid=sa;pwd=82354699";
        public static List<dynamic> QueryIn()
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
