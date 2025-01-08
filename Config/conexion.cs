using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Usuarios.Config
{
    class conexion
    {
        private readonly string cadenaConexion = 
            "Server=(local);database=Sistemasroles;uid=sa;pwd=123";

        public SqlConnection obtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
