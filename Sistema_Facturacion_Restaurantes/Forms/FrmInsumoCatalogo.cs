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
    public partial class FrmInsumoCatalogo : Form
    {
        public int PlatoID;
        public FrmInsumoCatalogo()
        {
            InitializeComponent();
            this.dgvIngredientes.DataSource = CInsumo.MostrarInsumo();
            this.dgvIngredientes.Columns[0].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmInsumo frmInsumo = new FrmInsumo();
            frmInsumo.isUpdate = false;
            frmInsumo.ShowDialog();
            this.dgvIngredientes.DataSource = CInsumo.MostrarInsumo();
            this.dgvIngredientes.Columns[0].Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvIngredientes.Rows.Count == 0 || dgvIngredientes.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int InsumoID = (int)this.dgvIngredientes.CurrentRow.Cells[0].Value;
            string Nombre = Convert.ToString(this.dgvIngredientes.CurrentRow.Cells[1].Value);
            string Proveedor = Convert.ToString(this.dgvIngredientes.CurrentRow.Cells[2].Value);

            DataRow[] SelectedRow = CComboxes.MostrarInsumoForeignKey().Select("InsumoID = " + InsumoID);
            int ProveedorID = (int)SelectedRow[0][1];

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmInsumo frmInsumo = new FrmInsumo();
            frmInsumo.isUpdate = true;
            frmInsumo.fillSpaces(Nombre, Proveedor);
            frmInsumo.EditableInsumoID = InsumoID;
            frmInsumo.ProveedorID = ProveedorID;
            frmInsumo.ShowDialog();
            this.dgvIngredientes.DataSource = CInsumo.MostrarInsumo();
            this.dgvIngredientes.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvIngredientes.Rows.Count == 0 || dgvIngredientes.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }
            try
            {
                string rpta = "";

                rpta = CPlatoInsumo.Insertar(PlatoID, (int)this.dgvIngredientes.CurrentRow.Cells[0].Value);

                if (rpta.Equals("OK"))
                    MessageBox.Show("Datos ingresados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            finally
            {
                this.Dispose();
            }
        }
    }
}
