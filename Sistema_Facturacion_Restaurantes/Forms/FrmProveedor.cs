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
    public partial class FrmProveedor : Form
    {
        public int EditableProveedorID = 0;
        public Boolean isUpdate = false;
        public FrmProveedor()
        {
            InitializeComponent();
            Dictionary<int, string> Departamentos = new Dictionary<int, string>();

            foreach (DataRow row in CComboxes.CargarDepartamentos().Rows)
            {
                Departamentos.Add((int)row[1], (string)row[0]);
            }
            this.cmbUbicacion.DataSource = new BindingSource(Departamentos, null);
            this.cmbUbicacion.DisplayMember = "Value";
            this.cmbUbicacion.ValueMember = "Key";
        }

        private void limpiar()
        {
            txtTelefono.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            this.cmbUbicacion.SelectedIndex = 0;
        }

        public void fillSpaces(string Nombre, string Telefono, int LocalidadID, string Direccion)
        {
            txtNombre.Text = Nombre;
            txtTelefono.Text = Telefono;
            txtDireccion.Text = Direccion;
            cmbUbicacion.SelectedValue = LocalidadID;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Get combobox selection (in handler)
                int LocalidadID = ((KeyValuePair<int, string>)this.cmbUbicacion.SelectedItem).Key;

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
                        rpta = CProveedor.Actualizar(EditableProveedorID, txtNombre.Text, txtTelefono.Text, LocalidadID, txtDireccion.Text);

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
                        rpta = CProveedor.Insertar(txtNombre.Text, txtTelefono.Text, LocalidadID, txtDireccion.Text);

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
    }
}
