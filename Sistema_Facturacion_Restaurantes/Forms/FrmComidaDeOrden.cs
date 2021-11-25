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
    public partial class FrmComidaDeOrden : Form
    {
        public int OrdenID;
        // Solo puedo actualizar los platos a la orden y la cantidad.
        public int PlatoID;
        // Para cuando vaya a actualizar
        public int OldPlatoID;
        public Boolean isUpdate = false;
        public FrmComidaDeOrden()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void limpiar()
        {
            txtComida.Text = "";
            txtCantidad.Text = "";
        }

        public void fillSpaces(string Comida, int Cantidad)
        {
            txtComida.Text = Comida;
            txtCantidad.Text = Cantidad.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int Cantidad;

                string rpta = "";
                if (isUpdate)
                {
                    if (String.IsNullOrWhiteSpace(txtComida.Text) || String.IsNullOrWhiteSpace(txtCantidad.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else if(!(int.TryParse(txtCantidad.Text, out Cantidad)))
                    {
                        MessageBox.Show("El precio debe ser un numero entero", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CComidasDeOrden.Actulizar(OrdenID, OldPlatoID, PlatoID, Cantidad);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtComida.Text) || String.IsNullOrWhiteSpace(txtCantidad.Text))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else if (!(int.TryParse(txtCantidad.Text, out Cantidad)))
                    {
                        MessageBox.Show("El precio debe ser un numero entero", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        rpta = CComidasDeOrden.Insertar(OrdenID, PlatoID, Cantidad);

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

        private void btnComida_Click(object sender, EventArgs e)
        {
            FormPlatos pc = new FormPlatos();
            pc.AgregarPlatoAOrden = true;
            this.AddOwnedForm(pc);
            pc.Show();
        }
    }
}
