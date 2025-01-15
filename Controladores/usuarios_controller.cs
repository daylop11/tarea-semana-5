using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Modelos;   //doy acceso a la carpeta
using Usuarios.Config;
using System.Data.SqlClient;
using System.Data;
using Usuarios.Helpers;
namespace Usuarios.Controladores
{
    class usuarios_controller
    {
        private usuario_model usuario_Model = new usuario_model();
        private readonly conexion cn = new conexion();
        private Encriptar encriptar = new Encriptar();
        public List<usuario_model> todos() {

            //List<usuario_model> lista_usuarios = new List<usuario_model>();
            var lista_usuarios = new List<usuario_model>();

            using (var conexion = cn.obtenerConexion())
            {
                conexion.Open();
                string cadena = $"SELECT Usuarios.*, Roles.Detalle FROM Roles " +
                    $"INNER JOIN Usuarios ON Roles.Rol_Id = Usuarios.Roles_id " +
                    $"WHERE (Usuarios.Disponibilidad = '1')";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var usuario = new usuario_model {
                               // createAt = Convert.ToDateTime(lector["createAt"].ToString()),
                                Detalle_Rol = lector["Detalle"].ToString(),
                                //Disponibilidad = (int)lector["Disponibilidad"],
                               Id_User = (int)lector["Id_User"],
                                Password = lector["Password"].ToString(),
                              //  Roles_id = (int)lector["Roles_id"],
                                //updateAt = Convert.ToDateTime(lector["updateAt"].ToString()),
                                Username = lector["Username"].ToString()
                            };
                            lista_usuarios.Add(usuario);
                        }

                    }
                }
                
            }

            return lista_usuarios; 
        }
        public usuario_model uno(int Id_User) {
            using (var conexion = cn.obtenerConexion())
            {
                conexion.Open();
                string cadena = $"SELECT Usuarios.*, Roles.Detalle FROM Roles " +
                    $"INNER JOIN Usuarios ON Roles.Rol_Id = Usuarios.Roles_id " +
                    $"WHERE (Usuarios.Disponibilidad = '1') and Usuarios.Id_User = {Id_User}";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (!lector.Read()) return null;
                          var usuario = new usuario_model
                            {
                                createAt = Convert.ToDateTime(lector["createAt"].ToString()),
                                Detalle_Rol = lector["Detalle"].ToString(),
                                Disponibilidad = (int)lector["Disponibilidad"],
                                Id_User = (int)lector["Id_User"],
                                Password = lector["Password"].ToString(),
                                Roles_id = (int)lector["Roles_id"],
                                updateAt = Convert.ToDateTime(lector["updateAt"].ToString()),
                                Username = lector["Username"].ToString()
                            };
                        return usuario;
                    }
                }

            }

        }
        public string insertar(usuario_model usuario) {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = $"INSERT INTO Usuarios(Username, Password, Disponibilidad, Roles_id) " +
                    $"values (@Username, @Password, @Disponibilidad, @Roles_id)";
                using (var comando = new SqlCommand(cadena, conexion))
                {

                    string contrasenia = encriptar.HashPassword(usuario.Password);

                    comando.Parameters.Add(new SqlParameter("@Username", usuario.Username));
                    comando.Parameters.Add(new SqlParameter("@Password", contrasenia));
                    comando.Parameters.Add(new SqlParameter("@Disponibilidad", usuario.Disponibilidad));
                    comando.Parameters.Add(new SqlParameter("@Roles_id", usuario.Roles_id));
                    conexion.Open();
                    if (comando.ExecuteNonQuery() != 0)
                    {
                        return "ok";
                    }
                    else
                    {
                        return "error";
                    }
                }
            }
        }
        public string actualizar(usuario_model usuario) {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = $"update Usuarios set Username = @Username, Disponibilidad = @Disponibilidad, Password= @Disponibilidad, " +
                    $"Roles_id = @Disponibilidad, updateAt = 'GETDATE()' where Id_User = @Id_User ";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    string contrasenia = encriptar.HashPassword(usuario.Password);
                    comando.Parameters.Add(new SqlParameter("@Id_User", usuario.Id_User));
                    comando.Parameters.Add(new SqlParameter("@Username", usuario.Username));
                    comando.Parameters.Add(new SqlParameter("@Password", contrasenia));
                    comando.Parameters.Add(new SqlParameter("@Disponibilidad", usuario.Disponibilidad));
                    comando.Parameters.Add(new SqlParameter("@Roles_id", usuario.Roles_id));
                    conexion.Open();
                    if (comando.ExecuteNonQuery() != 0)
                    {
                        return "ok";
                    }
                    else
                    {
                        return "error";
                    }
                }
            }

        }
        public string eliminar(int Id_User){

            using (var conexion = cn.obtenerConexion())
            {
                //string cadena = $"delete from usuarios where Id_User = @Id_User ";
                string cadena = $"update Usuarios set Disponibilidad = 0 " +
                   $"where Id_User = @Id_User ";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Id_User", Id_User));
                    conexion.Open();
                    if (comando.ExecuteNonQuery() != 0)
                    {
                        return "ok";
                    }
                    else
                    {
                        return "error";
                    }
                }
            }
        }

    }
}
