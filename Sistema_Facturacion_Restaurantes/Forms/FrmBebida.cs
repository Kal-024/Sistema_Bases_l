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
    public partial class FrmBebida : Form
    {
        public int ProveedorID;
        public Boolean isUpdate = false;
        public int EditableBebidaID;
        public FrmBebida()
        {
            InitializeComponent();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            FrmProveedorCatalogo pc = new FrmProveedorCatalogo();
            this.AddOwnedForm(pc);
            pc.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                double Precio;

                string rpta = "";
                if (isUpdate)
                {
                    if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtProveedor.Text) || String.IsNullOrWhiteSpace(txtPrecio.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else if(!Double.TryParse(txtPrecio.Text, out Precio))
                    {
                        MessageBox.Show("El precio debe ser un numero", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CBebida.Actulizar(EditableBebidaID, txtNombre.Text, ProveedorID, Precio);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtProveedor.Text) || String.IsNullOrWhiteSpace(txtPrecio.Text))
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
                        rpta = CBebida.Insertar(txtNombre.Text, ProveedorID, Precio);

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
            txtNombre.Text = "";
            txtProveedor.Text = "";
            txtPrecio.Text = "";
        }

        public void fillSpaces(string Nombre, string Proveedor, double Precio)
        {
            txtNombre.Text = Nombre;
            txtProveedor.Text = Proveedor;
            txtPrecio.Text = Convert.ToString(Precio);
        }
    }
}
