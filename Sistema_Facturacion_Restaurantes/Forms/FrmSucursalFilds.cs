using Sistema_Facturacion_Restaurantes.Controller;
using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Sistema_Facturacion_Restaurantes.Forms
{
    public partial class FrmSucursalFilds : Form
    {
        public bool isUpdate = false;
        public int EditableSucursalID = 0;
        public FrmSucursalFilds()
        {
            InitializeComponent();
            // Bind comboboxes to dictionary
            Dictionary<int, string> Departamentos = new Dictionary<int, string>();

            foreach (DataRow row in CComboxes.CargarDepartamentos().Rows)
            {
                Departamentos.Add((int)row[1], (string)row[0]);
            }
            this.cmbDepartamento.DataSource = new BindingSource(Departamentos, null);
            this.cmbDepartamento.DisplayMember = "Value";
            this.cmbDepartamento.ValueMember = "Key";

            Dictionary<int, string> Empleados = new Dictionary<int, string>();

            foreach (DataRow row in CComboxes.CargarEmpleados().Rows)
            {
                Empleados.Add((int)row[1], (string)row[0]);
            }
            this.cmbResponsable.DataSource = new BindingSource(Empleados, null);
            this.cmbResponsable.DisplayMember = "Value";
            this.cmbResponsable.ValueMember = "Key";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Get combobox selection (in handler)
                int KeyDepartamentoID = ((KeyValuePair<int, string>)this.cmbDepartamento.SelectedItem).Key;
                int KeyEmpleadoID = ((KeyValuePair<int, string>)this.cmbResponsable.SelectedItem).Key;

                string rpta = "";
                if (isUpdate)
                {
                    if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtDireccion.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CSucursal.Actualizar(EditableSucursalID, txtNombre.Text, KeyEmpleadoID, txtTelefono.Text, KeyDepartamentoID, txtDireccion.Text);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtDireccion.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CSucursal.Insertar(txtNombre.Text, KeyEmpleadoID, txtTelefono.Text, KeyDepartamentoID, txtDireccion.Text);

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
            txtNombre.Text = "";
            txtDireccion.Text = "";
            this.cmbDepartamento.SelectedIndex = 0;
            this.cmbResponsable.SelectedIndex = 0;
        }

        private void FrmSucursalFilds_Load(object sender, EventArgs e)
        {

        }

        public void fillSpaces(string Responsable, string NombreSucursal, string Telefono, string Ubicacion, string Direccion)
        {
            txtNombre.Text = NombreSucursal;
            txtTelefono.Text = Telefono;
            txtDireccion.Text = Direccion;

            int index = 0;
            //Cargar los comboxes con los datos iniciales
            foreach(DataRow item in CComboxes.CargarDepartamentos().Rows)
            {
                if ((string)item[0] == Ubicacion)
                {
                    cmbDepartamento.SelectedIndex = index;
                    break;
                }
                ++index;
            }
            index = 0;
            foreach (DataRow item in CComboxes.CargarEmpleados().Rows)
            {
                if((string)item[0] == Responsable)
                {
                    cmbResponsable.SelectedIndex = index;
                    break;
                }
                ++index;
            }
        }
    }
}
