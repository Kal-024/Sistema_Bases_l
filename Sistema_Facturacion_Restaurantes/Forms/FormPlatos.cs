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
    public partial class FormPlatos : System.Windows.Forms.Form
    {
        String rol;

        public Boolean AgregarPlatoAOrden = false;
        public FormPlatos(string RolUsuario)
        {

            rol = RolUsuario;

            InitializeComponent();
            switch (rol)
            {
                case "Recepcionista":
                    {
                        btnAgregar.Enabled = false;
                        btnActualizar.Enabled = false;
                        btnEliminar.Enabled = false;
                        break;
                    }
                case "Jefe Cocina":
                    {
                        btnAgregar.Enabled = false;
                        btnActualizar.Enabled = false;
                        //btnEliminar.Enabled = false;
                        //btnEmpleados.Hide();
                        break;
                    }
                case "Chef":
                    {

                        break;
                    }

            }

            this.dgvPlatos.DataSource = CPlato.MostrarPlato();
            this.dgvPlatos.Columns[0].Visible = false;
        }  

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            //LoadTheme();
            if (!AgregarPlatoAOrden)
                btnAgregarPlatoAOrden.Hide(); // Oculto ese boton si no voy a agregar plato a la orden
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmPlato frmPlato = new FrmPlato();
            frmPlato.isUpdate = false;
            frmPlato.ShowDialog();
            this.dgvPlatos.DataSource = CPlato.MostrarPlato();
            this.dgvPlatos.Columns[0].Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvPlatos.Rows.Count == 0 || dgvPlatos.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int PlatoID = (int)this.dgvPlatos.CurrentRow.Cells[0].Value;
            string Nombre = Convert.ToString(this.dgvPlatos.CurrentRow.Cells[1].Value);
            string Categoria = Convert.ToString(this.dgvPlatos.CurrentRow.Cells[2].Value);
            string Descripcion = Convert.ToString(this.dgvPlatos.CurrentRow.Cells[3].Value);
            double Precio = Double.Parse(Convert.ToString(this.dgvPlatos.CurrentRow.Cells[4].Value));

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmPlato frmPlato = new FrmPlato();
            frmPlato.isUpdate = true;
            frmPlato.fillSpaces(Nombre, Descripcion, Precio, Categoria);
            frmPlato.EditablePlatoID = PlatoID;
            frmPlato.ShowDialog();
            this.dgvPlatos.DataSource = CPlato.MostrarPlato();
            this.dgvPlatos.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvPlatos.Rows.Count == 0 || dgvPlatos.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            int PlatoID = (int)this.dgvPlatos.CurrentRow.Cells[0].Value;

            FrmPlatoIngredientesCatalogo pic = new FrmPlatoIngredientesCatalogo(PlatoID,rol);
            pic.ShowDialog();
        }

        private void btnAgregarPlatoAOrden_Click(object sender, EventArgs e)
        {
            int PlatoID = (int)this.dgvPlatos.CurrentRow.Cells[0].Value;
            string Nombre = Convert.ToString(this.dgvPlatos.CurrentRow.Cells[1].Value);

            if (AgregarPlatoAOrden)
            {
                FrmComidaDeOrden co = Owner as FrmComidaDeOrden;
                co.PlatoID = PlatoID;
                co.txtComida.Text = Nombre;
                AgregarPlatoAOrden = false;
                this.Dispose();
            }
        }
    }
}
