using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Modelos;   //doy acceso a la carpeta
using Usuarios.Config;
using System.Data.SqlClient;
using System.Data;
namespace Usuarios.Controladores
{
    class roles_controller
    {
        
        private readonly conexion cn = new conexion();
        public List<roles_model> todos() {
            var listaRoles = new List<roles_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = "select * from roles";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var rol = new roles_model
                            {
                                Detalle = lector["Detalle"].ToString(),
                                Rol_Id = (int)lector["Rol_Id"]
                            };
                            listaRoles.Add(rol);
                        }
                    }
                }
            }
            return listaRoles;
        }
    }
}
