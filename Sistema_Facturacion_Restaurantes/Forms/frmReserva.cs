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
    public partial class frmReserva : Form
    {
        int sucursalId;
        public frmReserva()
        {
            InitializeComponent();

            // Cargar el cmb comodin Sucursal
            Dictionary<int, string> Sucursales = new Dictionary<int, string>();

            foreach (DataRow row in CComboxes.CargarSucursal().Rows)
            {
                Sucursales.Add((int)row[1], (string)row[0]);
            }
            this.cmbSucursal.DataSource = new BindingSource(Sucursales, null);
            this.cmbSucursal.DisplayMember = "Value";
            this.cmbSucursal.ValueMember = "Key";

            // Get combobox selection (in handler)
            sucursalId = ((KeyValuePair<int, string>)this.cmbSucursal.SelectedItem).Key;
            // Cargar las ordenes de la sucursar selecionada
            dgvReservar.DataSource = CComboxes.CargarReserva(sucursalId);


        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update SucursalID var
            sucursalId = ((KeyValuePair<int, string>)this.cmbSucursal.SelectedItem).Key;
            // Cargar las ordenes de la sucursar selecionada
            dgvReservar.DataSource = CComboxes.CargarReserva(sucursalId);
            this.dgvReservar.Columns[0].Visible = false;
        }
    }
}
