using System.Data.SqlClient;

namespace CrudUsuariosStoredProcedure.Data
{
    public class DataAccess
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public static IConfiguration Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");
        }
        
    }
}
