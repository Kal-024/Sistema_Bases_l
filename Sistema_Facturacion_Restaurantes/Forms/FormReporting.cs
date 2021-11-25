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
    public partial class FormReporting : System.Windows.Forms.Form
    {
        public Boolean AgregarBebidaAOrden = false;
        public FormReporting()
        {
            InitializeComponent();
            this.dgvBebidas.DataSource = CBebida.MostrarBebida();
            this.dgvBebidas.Columns[0].Visible = false;
        }

        private void FormReporting_Load(object sender, EventArgs e)
        {
            LoadTheme();
            if(!AgregarBebidaAOrden)
                btnAgregarAOrden.Hide(); // Oculto ese boton si no voy a agregar plato a la orden
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
                label5.ForeColor = ThemeColor.PrimaryColor;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmBebida frmBebida = new FrmBebida();
            frmBebida.isUpdate = false;
            frmBebida.ShowDialog();
            this.dgvBebidas.DataSource = CBebida.MostrarBebida();
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
            string Nombre = Convert.ToString(this.dgvBebidas.CurrentRow.Cells[1].Value);
            string Proveedor = Convert.ToString(this.dgvBebidas.CurrentRow.Cells[2].Value);
            double Precio = Double.Parse(Convert.ToString(this.dgvBebidas.CurrentRow.Cells[3].Value));

            DataRow[] SelectedRow = CComboxes.MostrarBebidaForeignKey().Select("BebidaID = " + BebidaID);
            int ProveedorID = (int)SelectedRow[0][1];

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmBebida frmBebida = new FrmBebida();
            frmBebida.isUpdate = true;
            frmBebida.fillSpaces(Nombre, Proveedor, Precio);
            frmBebida.EditableBebidaID = BebidaID;
            frmBebida.ProveedorID = ProveedorID;
            frmBebida.ShowDialog();
            this.dgvBebidas.DataSource = CBebida.MostrarBebida();
            this.dgvBebidas.Columns[0].Visible = false;
        }

        private void btnAgregarAOrden_Click(object sender, EventArgs e)
        {
            int BebidaID = (int)this.dgvBebidas.CurrentRow.Cells[0].Value;
            string Nombre = Convert.ToString(this.dgvBebidas.CurrentRow.Cells[1].Value);

            if (AgregarBebidaAOrden)
            {
                FrmBebidaDeOrden co = Owner as FrmBebidaDeOrden;
                co.BebidaID = BebidaID;
                co.txtBebida.Text = Nombre;
                AgregarBebidaAOrden = false;
                this.Dispose();
            }
        }
    }
}
