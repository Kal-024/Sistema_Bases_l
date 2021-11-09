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
    public partial class FrmCliente : Form
    {
        public Boolean isUpdate = false;
        public int EditableClienteID = 0;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (isUpdate)
                {
                    if (String.IsNullOrWhiteSpace(txtCedula.Text) || String.IsNullOrWhiteSpace(txtNombres.Text) || String.IsNullOrWhiteSpace(txtApellidos.Text)
                        || String.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CCliente.Actualizar(EditableClienteID, txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtCedula.Text) || String.IsNullOrWhiteSpace(txtNombres.Text) || String.IsNullOrWhiteSpace(txtApellidos.Text)
                        || String.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CCliente.Insertar(txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text);

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
        }

        public void fillSpaces(string Cedula, string Nombres, string Apellidos, string Telefono)
        {
            txtCedula.Text = Cedula;
            txtNombres.Text = Nombres;
            txtApellidos.Text = Apellidos;
            txtTelefono.Text = Telefono;
        }
    }
}
