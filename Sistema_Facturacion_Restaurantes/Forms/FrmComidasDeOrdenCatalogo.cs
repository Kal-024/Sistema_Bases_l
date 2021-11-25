using Sistema_Facturacion_Restaurantes.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Facturacion_Restaurantes.Forms
{
    public partial class FrmComidasDeOrdenCatalogo : Form
    {
        public int OrdenID;

        public FrmComidasDeOrdenCatalogo(int Orden)
        {
            InitializeComponent();
            OrdenID = Orden;
            this.dgvComidas.DataSource = CComidasDeOrden.Mostrar(OrdenID);
            this.dgvComidas.Columns[0].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmComidaDeOrden co = new FrmComidaDeOrden();
            co.OrdenID = OrdenID;
            co.ShowDialog();
            this.dgvComidas.DataSource = CComidasDeOrden.Mostrar(OrdenID);
            this.dgvComidas.Columns[0].Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvComidas.Rows.Count == 0 || dgvComidas.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int PlatoID = (int)this.dgvComidas.CurrentRow.Cells[0].Value;
            string PlatoNombre = Convert.ToString(this.dgvComidas.CurrentRow.Cells[1].Value);
            int Cantidad = int.Parse(Convert.ToString(this.dgvComidas.CurrentRow.Cells[2].Value));

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmComidaDeOrden frmComidaDeOrden = new FrmComidaDeOrden();
            frmComidaDeOrden.isUpdate = true;
            frmComidaDeOrden.fillSpaces(PlatoNombre, Cantidad);
            frmComidaDeOrden.OrdenID = OrdenID; // Esta es la orden que voy a actualizar. Seria equivalente a la variable editable que he usado en otros casos
            frmComidaDeOrden.OldPlatoID = PlatoID;
            frmComidaDeOrden.ShowDialog();
            this.dgvComidas.DataSource = CComidasDeOrden.Mostrar(OrdenID);
            this.dgvComidas.Columns[0].Visible = false;
        }
    }
}
