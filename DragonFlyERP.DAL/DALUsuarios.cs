using DragonFlyERP.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DragonFlyERP.DAL
{
    public class DALUsuarios
    {
        private readonly string StringConnection = ApplicationSettings.StringConnection;

        #region CRUD

        #region Create

        public bool VerificaDisponilidade(string login)
        {
            bool retorno = false;
            int qtde = 0;

            try
            {
                StringBuilder consultaSQL = new StringBuilder();
                consultaSQL.AppendLine("SELECT COUNT(Usuario) as Quantidade ");
                consultaSQL.AppendLine("FROM Sistema_Usuarios ");
                consultaSQL.AppendLine($"WHERE Usuario = '{login}' ");

                using (SqlConnection con = new SqlConnection(StringConnection))
                using (SqlCommand cmd = new SqlCommand(consultaSQL.ToString(), con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!string.IsNullOrEmpty(reader["Quantidade"].ToString()))
                            {
                                qtde = Convert.ToInt32(reader["Quantidade"].ToString());
                            }
                        }
                    }
                }
                if (qtde == 0)
                    retorno = true;

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool InserirUsuario(UsuarioDTO novoUsuario)
        {
            bool retorno = false;

            try
            {
                StringBuilder consultaSQL = new StringBuilder();
                consultaSQL.AppendLine("INSERT INTO Sistema_Usuarios(Usuario, Senha, IsAdm) ");
                consultaSQL.AppendLine($"VALUES ('{novoUsuario.Login}', '{novoUsuario.Senha}', '{novoUsuario.IsAdm}') ");

                using (SqlConnection con = new SqlConnection(StringConnection))
                using (SqlCommand cmd = new SqlCommand(consultaSQL.ToString(), con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Read
        public UsuarioDTO ObterUsuarioPorLogin(string login)
        {
            UsuarioDTO usuario = null;

            try
            {
                StringBuilder consultaSQL = new StringBuilder();
                consultaSQL.AppendLine("SELECT IdUsuario, Usuario, Senha, IsAdm ");
                consultaSQL.AppendLine("FROM Sistema_Usuarios ");
                consultaSQL.AppendLine($"WHERE Usuario = '{login}' ");

                using (SqlConnection con = new SqlConnection(StringConnection))
                using (SqlCommand cmd = new SqlCommand(consultaSQL.ToString(), con))
                {
                    con.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new UsuarioDTO();

                            if (!string.IsNullOrEmpty(reader["IdUsuario"].ToString()))
                            {
                                usuario.Codigo = Convert.ToInt64(reader["IdUsuario"]);
                            }
                            if (!string.IsNullOrEmpty(reader["Usuario"].ToString()))
                            {
                                usuario.Login = reader["Usuario"].ToString();
                            }
                            if (!string.IsNullOrEmpty(reader["Senha"].ToString()))
                            {
                                usuario.Senha = reader["Senha"].ToString();
                            }
                            if (!string.IsNullOrEmpty(reader["IsAdm"].ToString()))
                            {
                                usuario.IsAdm = Convert.ToBoolean(reader["IsAdm"]);
                            }                            
                        }
                    }                    
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<UsuarioDTO> ListarUsuarios()
        {
            List<UsuarioDTO> listaUsuarios = null;

            try
            {
                listaUsuarios = new List<UsuarioDTO>();

                StringBuilder consultaSQL = new StringBuilder();
                consultaSQL.AppendLine("SELECT IdUsuario, Usuario, Senha, IsAdm ");
                consultaSQL.AppendLine("FROM Sistema_Usuarios ");

                using (SqlConnection con = new SqlConnection(StringConnection))
                using (SqlCommand cmd = new SqlCommand(consultaSQL.ToString(), con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new UsuarioDTO();

                            if (!string.IsNullOrEmpty(reader["IdUsuario"].ToString()))
                            {
                                usuario.Codigo = Convert.ToInt64(reader["IdUsuario"]);
                            }
                            if (!string.IsNullOrEmpty(reader["Usuario"].ToString()))
                            {
                                usuario.Login = reader["Usuario"].ToString();
                            }
                            if (!string.IsNullOrEmpty(reader["Senha"].ToString()))
                            {
                                usuario.Senha = reader["Senha"].ToString();
                            }
                            if (!string.IsNullOrEmpty(reader["IsAdm"].ToString()))
                            {
                                usuario.IsAdm = Convert.ToBoolean(reader["IsAdm"]);
                            }
                            listaUsuarios.Add(usuario);
                        }
                    }
                }
                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public bool AtualizarUsuario(UsuarioDTO novosDados)
        {
            bool retorno = false;

            try
            {
                StringBuilder consultaSQL = new StringBuilder();
                consultaSQL.AppendLine("UPDATE Sistema_Usuarios ");
                consultaSQL.AppendLine($"SET Usuario = '{novosDados.Login}', Senha = '{novosDados.Senha}', IsAdm = '{novosDados.IsAdm}' ");
                consultaSQL.AppendLine($"WHERE IdUsuario = {novosDados.Codigo} ");

                using (SqlConnection con = new SqlConnection(StringConnection))
                using (SqlCommand cmd = new SqlCommand(consultaSQL.ToString(), con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public bool ExcluirUsuario(UsuarioDTO novosDados)
        {
            bool retorno = false;

            try
            {
                StringBuilder consultaSQL = new StringBuilder();
                consultaSQL.AppendLine("DELETE FROM Sistema_Usuarios ");
                consultaSQL.AppendLine($"WHERE IdUsuario = {novosDados.Codigo} ");

                using (SqlConnection con = new SqlConnection(StringConnection))
                using (SqlCommand cmd = new SqlCommand(consultaSQL.ToString(), con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #endregion
    }
}