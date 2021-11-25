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
    public partial class FrmProveedorCatalogo : Form
    {
        public Boolean isInsumo = false;
        public FrmProveedorCatalogo()
        {
            InitializeComponent();
            this.dgvProveedor.DataSource = CProveedor.MostrarProveedor();
            this.dgvProveedor.Columns[0].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProveedor frmProveedor = new FrmProveedor();
            frmProveedor.isUpdate = false;
            frmProveedor.ShowDialog();
            this.dgvProveedor.DataSource = CProveedor.MostrarProveedor();
            this.dgvProveedor.Columns[0].Visible = false;
        }

        private void btnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.Rows.Count == 0 || dgvProveedor.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }
            // Estableco el valor de la variable cliente del form padre (FrmOrden Orden)
            // Para acceder a esas varables deben tener el operador de acceso public o metodos para accederlas
            int ProveedorID = (int)this.dgvProveedor.CurrentRow.Cells[0].Value;
            string Nombre = Convert.ToString(this.dgvProveedor.CurrentRow.Cells[1].Value);
            string Ubicacion = Convert.ToString(this.dgvProveedor.CurrentRow.Cells[2].Value);

            string ProveedorInfo = Nombre + ", " + Ubicacion;

            if(isInsumo)
            {
                FrmInsumo Bebida = Owner as FrmInsumo;
                Bebida.ProveedorID = ProveedorID;
                Bebida.txtProveedor.Text = ProveedorInfo;
            }
            else
            {
                FrmBebida Bebida = Owner as FrmBebida;
                Bebida.ProveedorID = ProveedorID;
                Bebida.txtProveedor.Text = ProveedorInfo;
            }

            isInsumo = false;
            this.Dispose();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.Rows.Count == 0 || dgvProveedor.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int ProveedorID = (int)this.dgvProveedor.CurrentRow.Cells[0].Value;
            string NombreCompania = Convert.ToString(this.dgvProveedor.CurrentRow.Cells[1].Value);

            DataRow[] SelectedRow = CComboxes.MostrarProveedorForeignKey().Select("ProveedorID = " + ProveedorID);
            int LocalidadID = (int)SelectedRow[0][1];

            string Telefono = Convert.ToString(this.dgvProveedor.CurrentRow.Cells[3].Value);
            string Direccion = Convert.ToString(this.dgvProveedor.CurrentRow.Cells[4].Value);

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmProveedor frmProveedor = new FrmProveedor();
            frmProveedor.isUpdate = true;
            frmProveedor.fillSpaces(NombreCompania, Telefono, LocalidadID, Direccion);
            frmProveedor.EditableProveedorID = ProveedorID;
            frmProveedor.ShowDialog();
            this.dgvProveedor.DataSource = CProveedor.MostrarProveedor();
            this.dgvProveedor.Columns[0].Visible = false;
        }
    }
}
