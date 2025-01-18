using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
namespace Usuarios.Helpers
{
    class Encriptar
    {
        public string HashPassword(string contrasenia) {
            return BCrypt.Net.BCrypt.HashPassword(contrasenia);
        }

        public bool VerifyPassword(string pwdDBB, string pwdForm)
        {
            return BCrypt.Net.BCrypt.Verify(pwdDBB, pwdForm);
        }
    }
}
