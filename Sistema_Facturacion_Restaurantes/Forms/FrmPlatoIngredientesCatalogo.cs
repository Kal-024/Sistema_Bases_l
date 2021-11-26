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
    public partial class FrmPlatoIngredientesCatalogo : Form
    {
        private int PlatoID;
        string rol;
        public FrmPlatoIngredientesCatalogo(int PlatoID,string rolU)
        {
            rol = rolU;

            InitializeComponent();

            switch (rol)
            {
                case "Recepcionista":
                    {
                        btnAgregar.Enabled = false;
                        btnEliminar.Enabled = false;

                        break;
                    }
                case "Jefe Cocina":
                    {
                        //btnAgregar.Enabled = false;
                        //btnActualizar.Enabled = false;
                        //btnEliminar.Enabled = false;
                        //btnEmpleados.Hide();
                        break;
                    }
                case "Chef":
                    {

                        break;
                    }

            }

            this.PlatoID = PlatoID;
            this.dgvIngredientes.DataSource = CPlatoInsumo.MostrarInsumos(this.PlatoID);
            this.dgvIngredientes.Columns[0].Visible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmInsumoCatalogo ic = new FrmInsumoCatalogo();
            ic.PlatoID = PlatoID;
            ic.ShowDialog();
            this.dgvIngredientes.DataSource = CPlatoInsumo.MostrarInsumos(this.PlatoID);
            this.dgvIngredientes.Columns[0].Visible = false;
        }

        private void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
