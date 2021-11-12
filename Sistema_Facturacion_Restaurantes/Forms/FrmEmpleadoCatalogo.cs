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
    public partial class FrmEmpleadoCatalogo : Form
    {
        private int SucursalID = 0;
        public FrmEmpleadoCatalogo(int Sucursal)
        {
            InitializeComponent();
            SucursalID = Sucursal;
            this.dgvEmpleados.DataSource = CEmpleado.MostrarEmpleadoPorSucursal(SucursalID);
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmEmpleado frmEmpleado = new FrmEmpleado();
            frmEmpleado.isUpdate = false;
            frmEmpleado.SucursalID = SucursalID;
            frmEmpleado.ShowDialog();
            this.dgvEmpleados.DataSource = CEmpleado.MostrarEmpleadoPorSucursal(SucursalID);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0 || dgvEmpleados.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int EmpleadoID = (int)this.dgvEmpleados.CurrentRow.Cells[0].Value;
            string Cedula = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells[1].Value);
            string Nombres = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells[2].Value);
            string Apellidos = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells[3].Value);
            string Cargo = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells[4].Value);
            string Telefono = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells[5].Value);
            string Direccion = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells[6].Value);

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmEmpleado frmEmpleado = new FrmEmpleado();
            frmEmpleado.isUpdate = true;
            frmEmpleado.fillSpaces(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion);
            frmEmpleado.EditableEmpledoID = EmpleadoID;
            frmEmpleado.SucursalID = SucursalID;
            frmEmpleado.ShowDialog();
            this.dgvEmpleados.DataSource = CEmpleado.MostrarEmpleadoPorSucursal(SucursalID);
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
