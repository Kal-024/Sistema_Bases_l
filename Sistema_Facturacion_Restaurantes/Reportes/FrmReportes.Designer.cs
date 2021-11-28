
namespace Sistema_Facturacion_Restaurantes.Reportes
{
    partial class FrmReportes
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
            this.MostrarOrdenBasicoPorSucursalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Sistema_Facturacion_Restaurantes.Reportes.DataSet1();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSucursal3 = new System.Windows.Forms.Button();
            this.btnSucursal2 = new System.Windows.Forms.Button();
            this.btnScursal1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MostrarOrdenBasicoPorSucursalTableAdapter = new Sistema_Facturacion_Restaurantes.Reportes.DataSet1TableAdapters.MostrarOrdenBasicoPorSucursalTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarOrdenBasicoPorSucursalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MostrarOrdenBasicoPorSucursalBindingSource
            // 
            this.MostrarOrdenBasicoPorSucursalBindingSource.DataMember = "MostrarOrdenBasicoPorSucursal";
            this.MostrarOrdenBasicoPorSucursalBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSucursal3);
            this.panel1.Controls.Add(this.btnSucursal2);
            this.panel1.Controls.Add(this.btnScursal1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 450);
            this.panel1.TabIndex = 0;
            // 
            // btnSucursal3
            // 
            this.btnSucursal3.Location = new System.Drawing.Point(27, 167);
            this.btnSucursal3.Name = "btnSucursal3";
            this.btnSucursal3.Size = new System.Drawing.Size(118, 41);
            this.btnSucursal3.TabIndex = 2;
            this.btnSucursal3.Text = "Sucursal #3";
            this.btnSucursal3.UseVisualStyleBackColor = true;
            this.btnSucursal3.Click += new System.EventHandler(this.btnSucursal3_Click);
            // 
            // btnSucursal2
            // 
            this.btnSucursal2.Location = new System.Drawing.Point(27, 103);
            this.btnSucursal2.Name = "btnSucursal2";
            this.btnSucursal2.Size = new System.Drawing.Size(118, 41);
            this.btnSucursal2.TabIndex = 1;
            this.btnSucursal2.Text = "Sucursal #2";
            this.btnSucursal2.UseVisualStyleBackColor = true;
            this.btnSucursal2.Click += new System.EventHandler(this.btnSucursal2_Click);
            // 
            // btnScursal1
            // 
            this.btnScursal1.Location = new System.Drawing.Point(27, 35);
            this.btnScursal1.Name = "btnScursal1";
            this.btnScursal1.Size = new System.Drawing.Size(118, 41);
            this.btnScursal1.TabIndex = 0;
            this.btnScursal1.Text = "Sucursal #1";
            this.btnScursal1.UseVisualStyleBackColor = true;
            this.btnScursal1.Click += new System.EventHandler(this.btnScursal1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "ReportesSucursal";
            reportDataSource2.Value = this.MostrarOrdenBasicoPorSucursalBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema_Facturacion_Restaurantes.Reportes.Reporte.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(177, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(623, 450);
            this.reportViewer1.TabIndex = 1;
            // 
            // MostrarOrdenBasicoPorSucursalTableAdapter
            // 
            this.MostrarOrdenBasicoPorSucursalTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MostrarOrdenBasicoPorSucursalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnScursal1;
        private System.Windows.Forms.Button btnSucursal3;
        private System.Windows.Forms.Button btnSucursal2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource MostrarOrdenBasicoPorSucursalBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.MostrarOrdenBasicoPorSucursalTableAdapter MostrarOrdenBasicoPorSucursalTableAdapter;
    }
}