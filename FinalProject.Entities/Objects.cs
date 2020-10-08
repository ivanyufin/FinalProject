using System.Configuration;
using System.Data.SqlClient;

namespace FinalProject.Entities
{
    public static class Objects
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public static SqlConnection Connection = new SqlConnection(_connectionString);

        static Objects()
        {
            Connection.Open();
        }
    }
}
