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
using System.Windows.Forms;

namespace Sistema_Facturacion_Restaurantes.Forms
{
    public partial class FormSucursal : System.Windows.Forms.Form
    {
        String rol;
        public FormSucursal(String RolUsuario)
        {
            InitializeComponent();

            rol = RolUsuario;
 
            switch (rol)
            {
                case "Recepcionista":
                    {
                        btnAgregar.Enabled = false;
                        btnActualizar.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnEmpleados.Hide();
                        break;
                    }
                case "Jefe Cocina":
                    {
                        btnAgregar.Enabled = false;
                        btnActualizar.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnEmpleados.Hide();
                        break;
                    }
                case "Chef":
                    {

                        break;
                    }

            }

        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadTheme();

            //Cargar la el dgvSucursal
            this.dgvSucursal.DataSource = CSucursal.MostrarSucursal();
            this.dgvSucursal.Columns[0].Visible = false;
            //this.dgvSucursal.AutoResizeColumns();
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
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmSucursalFilds frmSucursalFilds = new FrmSucursalFilds();
            frmSucursalFilds.isUpdate = false;
            frmSucursalFilds.ShowDialog();
            this.dgvSucursal.DataSource = CSucursal.MostrarSucursal();
            this.dgvSucursal.Columns[0].Visible = false;
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.Rows.Count == 0 || dgvSucursal.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para eliminar un registro debe seleccionar una fila");
                return;
            }

            if (MessageBox.Show("Esta seguro de que quiere borrar este registro?", "Eliminacion de registro", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                int SucursalID = (int)this.dgvSucursal.Rows[dgvSucursal.CurrentRow.Index].Cells[0].Value;
                if (CSucursal.EliminarSucursal(SucursalID) == 0)
                    MessageBox.Show("Sucursal eliminada de forma exitosa", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sucursal no eliminada", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvSucursal.DataSource = CSucursal.MostrarSucursal();
                this.dgvSucursal.Columns[0].Visible = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.Rows.Count == 0 || dgvSucursal.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int SucursalID = (int) this.dgvSucursal.CurrentRow.Cells[0].Value;
            string NombreSucursal = Convert.ToString(this.dgvSucursal.CurrentRow.Cells[2].Value);
            string Telefono = Convert.ToString(this.dgvSucursal.CurrentRow.Cells[3].Value);
            string Direccion = Convert.ToString(this.dgvSucursal.CurrentRow.Cells[5].Value);

            DataRow[] SelectedRow = CComboxes.MostrarSucursalForeignKey().Select("SucursalID = " + SucursalID);

            int ResponsableID = (int)SelectedRow[0][1];
            int LocalidadID = (int)SelectedRow[0][2];

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            FrmSucursalFilds frmSucursalFilds = new FrmSucursalFilds();
            frmSucursalFilds.isUpdate = true;
            frmSucursalFilds.fillSpaces(ResponsableID, NombreSucursal, Telefono, LocalidadID, Direccion);
            frmSucursalFilds.EditableSucursalID = SucursalID;
            frmSucursalFilds.ShowDialog();
            this.dgvSucursal.DataSource = CSucursal.MostrarSucursal();
            this.dgvSucursal.Columns[0].Visible = false;
        }

        private void dgvSucursal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.Rows.Count == 0 || dgvSucursal.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }
            else
            {
                FrmEmpleadoCatalogo frmEmpleadoCatalogo = new FrmEmpleadoCatalogo((int)this.dgvSucursal.CurrentRow.Cells[0].Value);
                frmEmpleadoCatalogo.ShowDialog();
            }
        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.Rows.Count == 0 || dgvSucursal.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }
            else
            {
                FrmMesaCatalogo frmMesaCatalogo = new FrmMesaCatalogo((int)this.dgvSucursal.CurrentRow.Cells[0].Value,rol);
                frmMesaCatalogo.ShowDialog();
            }
        }
    }
}
