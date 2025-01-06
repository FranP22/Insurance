using Microsoft.Data.SqlClient;

namespace Insurance.Service
{
    public interface IDbConnection
    {
        SqlConnection GetConnection();
    }
}
