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
    public partial class FrmOrdenCatalogo : System.Windows.Forms.Form
    {
        int SucursalID;
        public FrmOrdenCatalogo()
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
            SucursalID = ((KeyValuePair<int, string>)this.cmbSucursal.SelectedItem).Key;
            // Cargar las ordenes de la sucursar selecionada
            dgvOrdenes.DataSource = CComboxes.CargarOrden(SucursalID);
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            //label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update SucursalID var
            SucursalID = ((KeyValuePair<int, string>)this.cmbSucursal.SelectedItem).Key;
            // Cargar las ordenes de la sucursar selecionada
            dgvOrdenes.DataSource = CComboxes.CargarOrden(SucursalID);
            this.dgvOrdenes.Columns[0].Visible = false;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmOrden o = new FrmOrden(SucursalID);
            o.isUpdate = false;
            o.ShowDialog();
            dgvOrdenes.DataSource = CComboxes.CargarOrden(SucursalID);
            this.dgvOrdenes.Columns[0].Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.Rows.Count == 0 || dgvOrdenes.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int OrdenID = (int)this.dgvOrdenes.CurrentRow.Cells[0].Value;

            DataRow[] SelectedRow = CComboxes.MostrarOrdenForeignKey(SucursalID).Select("OrdenID = " + OrdenID);

            int MeseroID = (int) SelectedRow[0][1];
            int MesaID = (int)SelectedRow[0][2];
            int ClienteID = (int)SelectedRow[0][3];
            string FechaRealizacion = Convert.ToString(this.dgvOrdenes.CurrentRow.Cells[4].Value);

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmOrden frmOrden = new FrmOrden(SucursalID);
            frmOrden.isUpdate = true;
            frmOrden.fillSpaces(MeseroID, MesaID, ClienteID, FechaRealizacion);
            frmOrden.EditableOrdenID = OrdenID;
            frmOrden.ShowDialog();
            this.dgvOrdenes.DataSource = CComboxes.CargarOrden(SucursalID);
            this.dgvOrdenes.Columns[0].Visible = false;
        }

        private void btnComida_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.Rows.Count == 0 || dgvOrdenes.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int OrdenID = (int)this.dgvOrdenes.CurrentRow.Cells[0].Value;

            FrmComidasDeOrdenCatalogo co = new FrmComidasDeOrdenCatalogo(OrdenID);
            co.ShowDialog();

            dgvOrdenes.DataSource = CComboxes.CargarOrden(SucursalID);
            this.dgvOrdenes.Columns[0].Visible = false;
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.Rows.Count == 0 || dgvOrdenes.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int OrdenID = (int)this.dgvOrdenes.CurrentRow.Cells[0].Value;

            FrmBebidaDeOrdenCatalogo co = new FrmBebidaDeOrdenCatalogo(OrdenID);
            co.ShowDialog();

            dgvOrdenes.DataSource = CComboxes.CargarOrden(SucursalID);
            this.dgvOrdenes.Columns[0].Visible = false;
        }
    }
}
