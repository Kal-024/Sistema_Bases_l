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
    public partial class FrmBebidaDeOrden : Form
    {
        public int OrdenID;
        // Solo puedo actualizar los Bebidas a la orden y la cantidad.
        public int BebidaID;
        // Para cuando vaya a actualizar
        public int OldBebidaID;
        public Boolean isUpdate = false;
        string rol;
        public FrmBebidaDeOrden(string rolU)
        {
            rol = rolU;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int Cantidad;

                string rpta = "";
                if (isUpdate)
                {
                    if (String.IsNullOrWhiteSpace(txtBebida.Text) || String.IsNullOrWhiteSpace(txtCantidad.Text))
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
                        rpta = CBebidasDeOrden.Actulizar(OrdenID, OldBebidaID, BebidaID, Cantidad);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtBebida.Text) || String.IsNullOrWhiteSpace(txtCantidad.Text))
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
                        rpta = CBebidasDeOrden.Insertar(OrdenID, BebidaID, Cantidad);

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

        private void limpiar()
        {
            txtBebida.Text = "";
            txtCantidad.Text = "";
        }

        public void fillSpaces(string Bebida, int Cantidad)
        {
            txtBebida.Text = Bebida;
            txtCantidad.Text = Cantidad.ToString();
        }

        private void btnBebida_Click(object sender, EventArgs e)
        {
            formBebidas pc = new formBebidas(rol);
            pc.AgregarBebidaAOrden = true;
            this.AddOwnedForm(pc);
            pc.Show();
        }
    }
}
