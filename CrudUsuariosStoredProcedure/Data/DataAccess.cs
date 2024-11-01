using CrudUsuariosStoredProcedure.Models;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace CrudUsuariosStoredProcedure.Data
{
    public class DataAccess
    {
        #region Constantes
        const string LISTAR_USUARIO = "[dbo].[PR_LISTAR_USUARIOS]";
        const string CADASTRAR_USUARIO = "[dbo].[PR_INSERIR_USUARIOS]";
        const string LISTAR_USUARIO_ID = "[dbo].[PR_LISTAR_USUARIO_ID]";
        const string EDITAR_USUARIO = "[dbo].[PR_EDITAR_USUARIOS]";
        const string REMOVER_USUARIO = "[dbo].[PR_REMOVER_USUARIO]";
        #endregion

        #region Conexão com o banco de dados
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public static IConfiguration? Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Método responsável por listar os usuários interagindo com o banco de dados
        /// </summary>
        /// <returns></returns>
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = LISTAR_USUARIO;

                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader["ID"]);
                    usuario.Nome = reader["NOME"].ToString();
                    usuario.Email = reader["EMAIL"].ToString();
                    usuario.Cargo = reader["CARGO"].ToString();
                    usuario.Sobrenome = reader["SOBRENOME"].ToString();

                    usuarios.Add(usuario);
                }

                _connection.Close();
            }

            return usuarios;
        }

        /// <summary>
        /// Método responsável por cadastrar um usuário no banco de dados
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool CadastrarUsuario(Usuario usuario)
        {
            int id = 0;

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = CADASTRAR_USUARIO;

                _command.Parameters.AddWithValue("@NOME", usuario.Nome);
                _command.Parameters.AddWithValue("@SOBRENOME", usuario.Sobrenome);
                _command.Parameters.AddWithValue("@EMAIL", usuario.Email);
                _command.Parameters.AddWithValue("@CARGO", usuario.Cargo);

                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();
            }

            return id > 0 ? true : false;
        }

        /// <summary>
        /// Método responsável por buscar um usuário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario BuscarUsuarioPorId(int id)
        {
            Usuario usuario = new Usuario();

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = LISTAR_USUARIO_ID;

                _command.Parameters.AddWithValue("@ID", id);

                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader["ID"]);
                    usuario.Nome = reader["NOME"].ToString();
                    usuario.Email = reader["EMAIL"].ToString();
                    usuario.Cargo = reader["CARGO"].ToString();
                    usuario.Sobrenome = reader["SOBRENOME"].ToString();
                }

                _connection.Close();
            }

            return usuario;

        }

        /// <summary>
        /// Método responsável por editar um usuário no banco de dados
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool EditarUsuario(Usuario usuario)
        {

            var id = 0;

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = EDITAR_USUARIO;

                _command.Parameters.AddWithValue("@ID", usuario.Id);
                _command.Parameters.AddWithValue("@NOME", usuario.Nome);
                _command.Parameters.AddWithValue("@SOBRENOME", usuario.Sobrenome);
                _command.Parameters.AddWithValue("@EMAIL", usuario.Email);
                _command.Parameters.AddWithValue("@CARGO", usuario.Cargo);

                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();
            }

            return id > 0 ? true : false;
        }

        /// <summary>
        /// Método responsável por remover um usuário do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoverUsuario(int id)
        {
            var result = 0;

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = REMOVER_USUARIO;

                _command.Parameters.AddWithValue("@ID", id);

                _connection.Open();
                result = _command.ExecuteNonQuery();
                _connection.Close();
            }

            return result > 0 ? true : false;
        }
        #endregion

    }
}
