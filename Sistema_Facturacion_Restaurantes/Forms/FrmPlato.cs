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
    public partial class FrmPlato : Form
    {
        public int EditablePlatoID;
        public Boolean isUpdate = false;
        public FrmPlato()
        {
            InitializeComponent();
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Extras");
            cmbCategoria.Items.Add("Platos principales");
            cmbCategoria.Items.Add("Postres");
            cmbCategoria.SelectedIndex = 0;
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            cmbCategoria.SelectedIndex = 0;
        }

        public void fillSpaces(string Nombre, string Descripcion, double Precio, string Categoria)
        {
            txtNombre.Text = Nombre;
            txtDescripcion.Text = Descripcion;
            txtPrecio.Text = Convert.ToString(Precio);
            cmbCategoria.SelectedIndex = cmbCategoria.FindStringExact(Categoria);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                double Precio;

                string rpta = "";
                if (isUpdate)
                {
                    if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtDescripcion.Text) || String.IsNullOrWhiteSpace(txtPrecio.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else if (!Double.TryParse(txtPrecio.Text, out Precio))
                    {
                        MessageBox.Show("El precio debe ser un numero", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CPlato.Actualizar(EditablePlatoID, txtNombre.Text, cmbCategoria.SelectedItem.ToString(), txtDescripcion.Text, Precio);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtDescripcion.Text) || String.IsNullOrWhiteSpace(txtPrecio.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else if (!Double.TryParse(txtPrecio.Text, out Precio))
                    {
                        MessageBox.Show("El precio debe ser un numero", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CPlato.Insertar(txtNombre.Text, cmbCategoria.SelectedItem.ToString(), txtDescripcion.Text, Precio);

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
