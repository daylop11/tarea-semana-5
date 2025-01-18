
namespace Usuarios.Vistas.Reportes
{
    partial class ResporteUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.listaUsuariosconRolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemasrolesDataSet = new Usuarios.SistemasrolesDataSet();
            this.listaUsuariosconRolesTableAdapter = new Usuarios.SistemasrolesDataSetTableAdapters.listaUsuariosconRolesTableAdapter();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.listaUsuariosconRolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemasrolesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.listaUsuariosconRolesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Usuarios.Vistas.Reportes.ReporteUsuarios.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 65);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 373);
            this.reportViewer1.TabIndex = 0;
            // 
            // listaUsuariosconRolesBindingSource
            // 
            this.listaUsuariosconRolesBindingSource.DataMember = "listaUsuariosconRoles";
            this.listaUsuariosconRolesBindingSource.DataSource = this.sistemasrolesDataSet;
            // 
            // sistemasrolesDataSet
            // 
            this.sistemasrolesDataSet.DataSetName = "SistemasrolesDataSet";
            this.sistemasrolesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listaUsuariosconRolesTableAdapter
            // 
            this.listaUsuariosconRolesTableAdapter.ClearBeforeFill = true;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar.Location = new System.Drawing.Point(590, 2);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(139, 36);
            this.btn_Buscar.TabIndex = 1;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar por Nombre";
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar.Location = new System.Drawing.Point(268, 8);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(316, 30);
            this.txt_Buscar.TabIndex = 3;
            // 
            // ResporteUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_Buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ResporteUsuarios";
            this.Text = "ResporteUsuarios";
            this.Load += new System.EventHandler(this.ResporteUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaUsuariosconRolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemasrolesDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SistemasrolesDataSet sistemasrolesDataSet;
        private System.Windows.Forms.BindingSource listaUsuariosconRolesBindingSource;
        private SistemasrolesDataSetTableAdapters.listaUsuariosconRolesTableAdapter listaUsuariosconRolesTableAdapter;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Buscar;
    }
}