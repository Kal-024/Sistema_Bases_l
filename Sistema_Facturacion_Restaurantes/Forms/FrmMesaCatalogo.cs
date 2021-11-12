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
    public partial class FrmMesaCatalogo : Form
    {
        public int SucursalID;
        
        public FrmMesaCatalogo(int Sucursal)
        {
            InitializeComponent();
            SucursalID = Sucursal;
            dgvMesa.DataSource = CMesa.MostrarMesaPorSucursal(SucursalID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmMesa frmMesa = new FrmMesa();
            frmMesa.isUpdate = false;
            frmMesa.SucursalID = SucursalID;
            frmMesa.ShowDialog();
            this.dgvMesa.DataSource = CMesa.MostrarMesaPorSucursal(SucursalID);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvMesa.Rows.Count == 0 || dgvMesa.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int MesaID = (int)this.dgvMesa.CurrentRow.Cells[0].Value;
            string CantAsientos = Convert.ToString(this.dgvMesa.CurrentRow.Cells[1].Value);
            string Area = Convert.ToString(this.dgvMesa.CurrentRow.Cells[2].Value);

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmMesa frmMesa = new FrmMesa();
            frmMesa.isUpdate = true;
            frmMesa.fillSpaces(CantAsientos, Area);
            frmMesa.EditableMesaID = MesaID;
            frmMesa.SucursalID = SucursalID;
            frmMesa.ShowDialog();
            this.dgvMesa.DataSource = CMesa.MostrarMesaPorSucursal(SucursalID);
        }
    }
}
