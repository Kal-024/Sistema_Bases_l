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
        String rol;
        Object obj;
        public FrmClienteCatalogo(String rolUsuario,Object o)
        {
            rol = rolUsuario;
            obj = o;
            InitializeComponent();
            this.dgvCliente.DataSource = CCliente.MostrarCliente();
            this.dgvCliente.Columns[0].Visible = false;

            switch (rol)
            {
                case "Recepcionista":
                    {
                        btnEliminar.Enabled = false;
                        break;
                    }
                case "Jefe Cocina":
                    {
                        btnEliminar.Enabled = false;
                        break;
                    }
                case "Chef":
                    {

                        break;
                    }
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.isUpdate = false;
            frmCliente.ShowDialog();
            this.dgvCliente.DataSource = CCliente.MostrarCliente();
            this.dgvCliente.Columns[0].Visible = false;
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
            Console.WriteLine(obj.GetType() == typeof(FrmOrden));
            //Console.WriteLine(frmType.GetType().Name);
            //Console.WriteLine(frmType.GetType());

            //Aqui he cambiado un poco para poder usarlo en otro form
            if (obj.GetType() == typeof(FrmOrden))
            { 
                FrmOrden Orden = Owner as FrmOrden;
                Orden.ClienteID = Cliente;
                this.Dispose();
            }
            if (obj.GetType() == typeof(frmSaveReserva))
            {
                frmSaveReserva reserva= Owner as frmSaveReserva;
                reserva.ClienteID = Cliente;
                this.Dispose();
            }

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
            this.dgvCliente.Columns[0].Visible = false;
        }

        private void FrmClienteCatalogo_Load(object sender, EventArgs e)
        {
            this.dgvCliente.Columns[0].Visible = false;
        }
    }
}
