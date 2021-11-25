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
    public partial class FrmBebidaDeOrdenCatalogo : Form
    {
        public int OrdenID;
        public FrmBebidaDeOrdenCatalogo(int Orden)
        {
            InitializeComponent();
            OrdenID = Orden;
            this.dgvBebidas.DataSource = CBebidasDeOrden.Mostrar(OrdenID);
            this.dgvBebidas.Columns[0].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmBebidaDeOrden co = new FrmBebidaDeOrden();
            co.OrdenID = OrdenID;
            co.ShowDialog();
            this.dgvBebidas.DataSource = CBebidasDeOrden.Mostrar(OrdenID);
            this.dgvBebidas.Columns[0].Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvBebidas.Rows.Count == 0 || dgvBebidas.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int BebidaID = (int)this.dgvBebidas.CurrentRow.Cells[0].Value;
            string BebidaNombre = Convert.ToString(this.dgvBebidas.CurrentRow.Cells[1].Value);
            int Cantidad = int.Parse(Convert.ToString(this.dgvBebidas.CurrentRow.Cells[2].Value));

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmBebidaDeOrden frmBebidaDeOrden = new FrmBebidaDeOrden();
            frmBebidaDeOrden.isUpdate = true;
            frmBebidaDeOrden.fillSpaces(BebidaNombre, Cantidad);
            frmBebidaDeOrden.OrdenID = OrdenID; // Esta es la orden que voy a actualizar. Seria equivalente a la variable editable que he usado en otros casos
            frmBebidaDeOrden.OldBebidaID = BebidaID;
            frmBebidaDeOrden.ShowDialog();
            this.dgvBebidas.DataSource = CBebidasDeOrden.Mostrar(OrdenID);
            this.dgvBebidas.Columns[0].Visible = false;
        }
    }
}
