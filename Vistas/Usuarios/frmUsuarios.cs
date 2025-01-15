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
using Usuarios.Modelos;

namespace Usuarios.Vistas
{
    public partial class frmUsuarios : Form 
    {

        private roles_controller roles_Controller = new roles_controller();
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            var roles = roles_Controller.todos();

            cmd_Roles.DataSource = roles;
            cmd_Roles.ValueMember = "Rol_Id";
            cmd_Roles.DisplayMember = "Detalle";

            Disponibilidad();
            cargaLista();

        }

        public void cargaLista()
        {
            var usuariosController = new usuarios_controller();
            var listaUsuarios = usuariosController.todos();

            lst_Usuarios.DataSource = listaUsuarios;
            lst_Usuarios.ValueMember = "Id_User";
            lst_Usuarios.DisplayMember = "Username";
        }
        public void Disponibilidad() {
            if (chbActivo.Checked == true)
            {
                chbActivo.Text = "Usuario Activo";
            }
            else { 
                chbActivo.Text = "Usuario Innactivo";
            }
        }

        private void chbActivo_CheckedChanged(object sender, EventArgs e)
        {
            Disponibilidad();
        }

        private void btnGuadar_Click(object sender, EventArgs e)
        {
            var usuarioModel = new usuario_model {
            Disponibilidad = (chbActivo.Checked == true? 1 : 0),
            Password = txt_Contrasenia.Text,
            Roles_id = (int)cmd_Roles.SelectedValue,
            Username = txt_Nombre.Text 
            };

            var usuariosController = new usuarios_controller();
            if (usuariosController.insertar(usuarioModel) == "ok")
            {
                MessageBox.Show("Se guarrdo con exito");
                cargaLista();
            }
            else { 
                MessageBox.Show("Ocurrio un error al guardar");

            }


        }
    }
}
