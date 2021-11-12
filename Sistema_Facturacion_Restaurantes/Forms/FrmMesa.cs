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
    public partial class FrmMesa : Form
    {
        public int SucursalID;
        public int EditableMesaID;
        public Boolean isUpdate = false;

        public object Canvert { get; private set; }

        public FrmMesa()
        {
            InitializeComponent();
            CargarCombobox();
        }

        private void CargarCombobox()
        {
            // La cantidad de asientos por mesa va de 2 a 12
            for (int i = 2; i <= 12; i++)
                cmbCantAsiento.Items.Add(i);
            // El area de una mesa puede ser una de tres opciones
            cmbArea.Items.Add("Terraza");
            cmbArea.Items.Add("Salon fumadores");
            cmbArea.Items.Add("Solo NO fumadores");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (isUpdate)
                {
                    //Validar si no se ha seleccionado nada de los combobox
                    if (!(cmbArea.SelectedIndex > -1) || !(cmbCantAsiento.SelectedIndex > -1))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int CantAsientos = Int32.Parse(cmbCantAsiento.SelectedItem.ToString());
                        string Area = cmbArea.SelectedItem.ToString();

                        rpta = CMesa.Actualizar(EditableMesaID, CantAsientos, Area, SucursalID);

                        if (rpta.Equals("OK"))
                            MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (!(cmbArea.SelectedIndex > -1) || !(cmbCantAsiento.SelectedIndex > -1))
                    {
                        MessageBox.Show("Verificar que los datos de entrada no sean vacios", "Entrada de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int CantAsientos = Int32.Parse(cmbCantAsiento.SelectedItem.ToString());
                        string Area = cmbArea.SelectedItem.ToString();

                        rpta = CMesa.Insertar(CantAsientos, Area, SucursalID);

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

        public void fillSpaces(string CantAsientos, string Area)
        {
            cmbCantAsiento.SelectedIndex = cmbCantAsiento.FindStringExact(CantAsientos);
            cmbArea.SelectedIndex = cmbArea.FindStringExact(Area);
        }
    }
}
