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
        private usuarios_controller usuariosController = new usuarios_controller();
        private roles_controller roles_Controller = new roles_controller();
        private usuario_model usuario_Model = new usuario_model();
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
            var mensaje = "";
            if (txt_Contrasenia.Text != txt_Repita.Text)
            {
                MessageBox.Show("Las contrasenias no son iguales");
                return;
            }
            if (usuario_Model.Id_User == 0)
            {
                usuario_Model = new usuario_model
                {
                    Disponibilidad = (chbActivo.Checked == true ? 1 : 0),
                    Password = txt_Contrasenia.Text,
                    Roles_id = (int)cmd_Roles.SelectedValue,
                    Username = txt_Nombre.Text
                };
                mensaje = usuariosController.insertar(usuario_Model);
            }
            else {
                usuario_Model.Disponibilidad = (chbActivo.Checked == true ? 1 : 0);
                usuario_Model.Password = txt_Contrasenia.Text;
                usuario_Model.Roles_id = (int)cmd_Roles.SelectedValue;
                usuario_Model.Username = txt_Nombre.Text;
                mensaje = usuariosController.actualizar(usuario_Model);
            }
                     
            if (mensaje == "ok")
            {
                MessageBox.Show("Se guarrdo con exito");
                cargaLista();
                limpiar_cajas();
            }
            else { 
                MessageBox.Show("Ocurrio un error al guardar");

            }


        }

        private void lst_Usuarios_DoubleClick(object sender, EventArgs e)
        {
            editar();
        }
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            editar();
        }
        public void editar() {
            if (lst_Usuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Elija a un usuario de la lista");
                return;
            }
            usuario_Model = usuariosController.uno((int)lst_Usuarios.SelectedValue);
            txt_Nombre.Text = usuario_Model.Username;
            txt_Contrasenia.Text = usuario_Model.Password;
            txt_Repita.Text = usuario_Model.Password;
            chbActivo.Checked = usuario_Model.Disponibilidad == 1 ? true : false;
            cmd_Roles.SelectedValue = usuario_Model.Roles_id;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            limpiar_cajas();
        }

        public void limpiar_cajas() {
            txt_Contrasenia.Text = "";
            txt_Nombre.Text = "";
            txt_Repita.Text = "";
            cmd_Roles.SelectedIndex = 1;
            chbActivo.Checked = false;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Usuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Elija a un usuario de la lista para eliminarlo");
                return;
            }
            if (usuariosController.eliminar((int)lst_Usuarios.SelectedValue) == "ok")
            {
                MessageBox.Show("Se elimino con exito");
                cargaLista();
                limpiar_cajas();
            }
            else { 
                MessageBox.Show("Ocurrio un error al eliminar, por favor intente en unas 10 horas hasta corregir el error");
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
