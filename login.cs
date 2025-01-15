using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuarios.Controladores;
using Usuarios.Vistas;
namespace Usuarios
{
    public partial class login : Form
    {
        private accunt_coontroller cuentas_accesos = new accunt_coontroller();
        public login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            var usuario = cuentas_accesos.login(txtUsuario.Text.Trim(), txtContrasenia.Text.Trim());
            if (usuario.Detalle_Rol == null)
            {
                MessageBox.Show("El usuario o la contrasenia son incorrectos");
            }
            else {

                var menuGeneral = new MenuGeneral();
                menuGeneral.Show();
                this.Hide();

            }
        }
    }
}
