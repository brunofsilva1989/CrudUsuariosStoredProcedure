using CrudUsuariosStoredProcedure.Models;
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

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "PR_LISTAR_USUARIOS";

                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader["ID"]);
                    usuario.Nome = reader["Name"].ToString();
                    usuario.Email = reader["Email"].ToString();
                    usuario.Cargo = reader["Cargo"].ToString();
                    usuario.Sobrenome = reader["Sobrenome"].ToString();

                    usuarios.Add(usuario);
                }

                _connection.Close();
            }

            return usuarios;
        }
        
    }

    
}
