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
    public partial class FrmEmpleado : Form
    {
        public Boolean isUpdate = false;
        public int EditableEmpledoID = 0;
        public int SucursalID = 0;
        public FrmEmpleado()
        {
            InitializeComponent();
            cmbCargo.Items.Add("Chef");
            cmbCargo.Items.Add("Mesero");
            cmbCargo.Items.Add("Responsable");
            cmbCargo.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (isUpdate)
                {
                    if (String.IsNullOrWhiteSpace(txtCedula.Text) || String.IsNullOrWhiteSpace(txtNombres.Text) || String.IsNullOrWhiteSpace(txtApellidos.Text)
                        || String.IsNullOrWhiteSpace(txtTelefono.Text) || String.IsNullOrWhiteSpace(txtDireccion.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CEmpleado.Actualizar(EditableEmpledoID, txtCedula.Text, txtNombres.Text, txtApellidos.Text, cmbCargo.SelectedItem.ToString(), txtTelefono.Text, txtDireccion.Text, SucursalID);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtCedula.Text) || String.IsNullOrWhiteSpace(txtNombres.Text) || String.IsNullOrWhiteSpace(txtApellidos.Text)
                        || String.IsNullOrWhiteSpace(txtTelefono.Text) || String.IsNullOrWhiteSpace(txtDireccion.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CEmpleado.Insertar(txtCedula.Text, txtNombres.Text, txtApellidos.Text, cmbCargo.SelectedItem.ToString(), txtTelefono.Text, txtDireccion.Text, SucursalID);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos ingresados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            finally
            {
                this.isUpdate = false;
                this.Dispose();
            }
        }

        private void limpiar()
        {
            txtTelefono.Text = "";
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            cmbCargo.SelectedIndex = 1;
        }

        public void fillSpaces(string Cedula, string Nombres, string Apellidos, string Cargo,string Telefono, string Direccion)
        {
            txtCedula.Text = Cedula;
            txtNombres.Text = Nombres;
            txtApellidos.Text = Apellidos;
            txtTelefono.Text = Telefono;
            txtDireccion.Text = Direccion;
            cmbCargo.SelectedIndex = cmbCargo.FindStringExact(Cargo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
