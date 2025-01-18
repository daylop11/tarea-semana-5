using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usuarios.Vistas.Reportes
{
    public partial class ResporteUsuarios : Form
    {
        public ResporteUsuarios()
        {
            InitializeComponent();
        }

        private void ResporteUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistemasrolesDataSet.listaUsuariosconRoles' Puede moverla o quitarla según sea necesario.
            this.listaUsuariosconRolesTableAdapter.Fill(this.sistemasrolesDataSet.listaUsuariosconRoles);
           
            this.reportViewer1.RefreshReport();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            this.listaUsuariosconRolesTableAdapter.FillByNombre(this.sistemasrolesDataSet.listaUsuariosconRoles, txt_Buscar.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
