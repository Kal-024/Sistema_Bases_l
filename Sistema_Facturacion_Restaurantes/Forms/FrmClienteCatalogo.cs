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
    public partial class FrmClienteCatalogo : Form
    {
        public FrmClienteCatalogo()
        {
            InitializeComponent();
            this.dgvCliente.DataSource = CCliente.MostrarCliente();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.isUpdate = false;
            frmCliente.ShowDialog();
            this.dgvCliente.DataSource = CCliente.MostrarCliente();
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            if (dgvCliente.Rows.Count == 0 || dgvCliente.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }
            // Estableco el valor de la variable cliente del form padre (FrmOrden Orden)
            // Para acceder a esas varables deben tener el operador de acceso public o metodos para accederlas
            int Cliente = (int) this.dgvCliente.CurrentRow.Cells[0].Value;
            FrmOrden Orden = Owner as FrmOrden;
            Orden.ClienteID = Cliente;
            this.Dispose();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCliente.Rows.Count == 0 || dgvCliente.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int ClienteID = (int)this.dgvCliente.CurrentRow.Cells[0].Value;
            string Cedula = Convert.ToString(this.dgvCliente.CurrentRow.Cells[1].Value);
            string Nombres = Convert.ToString(this.dgvCliente.CurrentRow.Cells[2].Value);
            string Apellidos = Convert.ToString(this.dgvCliente.CurrentRow.Cells[3].Value);
            string Telefono = Convert.ToString(this.dgvCliente.CurrentRow.Cells[4].Value);

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.isUpdate = true;
            frmCliente.fillSpaces(Cedula, Nombres, Apellidos, Telefono);
            frmCliente.EditableClienteID = ClienteID;
            frmCliente.ShowDialog();
            this.dgvCliente.DataSource = CCliente.MostrarCliente();
        }
    }
}
