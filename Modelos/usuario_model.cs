using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Modelos
{
    class usuario_model
    {
        public int Id_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Disponibilidad { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
        public int Roles_id { get; set; }
        public string Detalle_Rol { get; set; } = null;
    }
}
