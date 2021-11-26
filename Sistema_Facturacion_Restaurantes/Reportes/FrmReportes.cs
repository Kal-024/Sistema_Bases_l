using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Facturacion_Restaurantes.Reportes
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.MostrarOrdenBasicoPorSucursal' Puede moverla o quitarla según sea necesario.
            //this.MostrarOrdenBasicoPorSucursalTableAdapter.Fill(this.DataSet1.MostrarOrdenBasicoPorSucursal);

            //this.reportViewer1.RefreshReport();
        }

        private void btnScursal1_Click(object sender, EventArgs e)
        {
            var sucursalID = 1;
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.MostrarOrdenBasicoPorSucursal' Puede moverla o quitarla según sea necesario.
            this.MostrarOrdenBasicoPorSucursalTableAdapter.Fill(this.DataSet1.MostrarOrdenBasicoPorSucursal, sucursalID);

            this.reportViewer1.RefreshReport();
        }
    }
}
