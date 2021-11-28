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
    public partial class frmReserva : Form
    {
        int sucursalId;
        string rol;
        public int ClienteID = 0;
        public frmReserva(string rolUsuario)
        {
            InitializeComponent();
            rol = rolUsuario;

            // Cargar el cmb comodin Sucursal
            Dictionary<int, string> Sucursales = new Dictionary<int, string>();

            foreach (DataRow row in CComboxes.CargarSucursal().Rows)
            {
                Sucursales.Add((int)row[1], (string)row[0]);
            }
            this.cmbSucursal.DataSource = new BindingSource(Sucursales, null);
            this.cmbSucursal.DisplayMember = "Value";
            this.cmbSucursal.ValueMember = "Key";

            // Get combobox selection (in handler)
            sucursalId = ((KeyValuePair<int, string>)this.cmbSucursal.SelectedItem).Key;
            // Cargar las ordenes de la sucursar selecionada
            dgvReservar.DataSource = CComboxes.CargarReserva(sucursalId);


        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update SucursalID var
            sucursalId = ((KeyValuePair<int, string>)this.cmbSucursal.SelectedItem).Key;
            // Cargar las ordenes de la sucursar selecionada
            dgvReservar.DataSource = CComboxes.CargarReserva(sucursalId);
            this.dgvReservar.Columns[0].Visible = false;
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {

            DataTable SelectedRow = CMesa.LoadTableAvailableForSucursal(sucursalId);
            bool hasRows = SelectedRow.Rows.GetEnumerator().MoveNext();
            if (!hasRows)
            {
                MessageBox.Show("No hay mesas disponibles para Reservar");
                return;
            }
            //DataTable dataConfirm = CMesa.LoadTableAvailableForSucursal(sucursalId);
            //Console.WriteLine(dataConfirm.Rows);


            frmSaveReserva o = new frmSaveReserva(sucursalId, rol, 0);
            o.isUpdate = false;
            o.ShowDialog();
            dgvReservar.DataSource = CComboxes.CargarReserva(sucursalId);
            this.dgvReservar.Columns[0].Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
            if (dgvReservar.Rows.Count == 0 || dgvReservar.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Para actualizar un registro debe seleccionar una fila");
                return;
            }

            // Respaldo de los datos iniciales
            int reservaID = int.Parse(Convert.ToString(this.dgvReservar.CurrentRow.Cells[0].Value));

            DataTable tableF = CComboxes.MostrarReservaForeignKey(reservaID);

            int mesaID = (int)tableF.Rows[0][0];
            int clienteID = (int)tableF.Rows[0][1];

            int cantidadA = int.Parse(Convert.ToString(this.dgvReservar.CurrentRow.Cells[3].Value));
            string fechaR = Convert.ToString(this.dgvReservar.CurrentRow.Cells[4].Value);
            string fechaL = Convert.ToString(this.dgvReservar.CurrentRow.Cells[5].Value);
            int atencionE = Convert.ToString(this.dgvReservar.CurrentRow.Cells[6].Value) == "No"? 0: 1;

            // Llamada al form que contine los datos de entrada del 'objeto' Sucursal
            frmSaveReserva frmSave = new frmSaveReserva(sucursalId, rol, mesaID);
            frmSave.isUpdate = true;
            frmSave.fillSpaces(mesaID, clienteID, cantidadA, fechaR, fechaL, atencionE);
            frmSave.EditableReservaID = reservaID;
            frmSave.ShowDialog();
            dgvReservar.DataSource = CComboxes.CargarReserva(sucursalId);
            this.dgvReservar.Columns[0].Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvReservar.Rows.Count == 0 || dgvReservar.CurrentCell.RowIndex < 0)
            {
                return;
            }

            DataTable filtro = new DataTable();
            filtro.Columns.Add("ReservaID");
            filtro.Columns.Add("Mesa");
            filtro.Columns.Add("Cliente");
            filtro.Columns.Add("Cantidad Asistente");
            filtro.Columns.Add("Fecha Reserva");
            filtro.Columns.Add("Fecha Llegada");
            filtro.Columns.Add("Atencion especial");
            string Clave = txtBuscar.Text.ToUpper();
            int rows = CComboxes.CargarReserva(sucursalId).Rows.Count;

            for (int i = 0; i < rows; i++)
            {
                // string array
                string[] pro = CComboxes.CargarReserva(sucursalId).Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                //MessageBox.Show(pro.Length + " " + pro[0].ToString());

                if (pro[0].ToString().ToUpper().Contains(Clave) || pro[1].ToString().ToUpper().Contains(Clave)
                    || pro[2].ToString().ToUpper().Contains(Clave) || pro[3].ToString().ToUpper().Contains(Clave)
                    || pro[4].ToString().ToUpper().Contains(Clave) || pro[5].ToString().Contains(Clave)
                    || pro[6].ToString().ToUpper().Contains(Clave))
                    filtro.Rows.Add(pro);
            }

            if (filtro.Rows.Count > 0 && filtro != null)
            {
                dgvReservar.DataSource = filtro;
            }
            else
            {
                dgvReservar.DataSource = CComboxes.CargarReserva(sucursalId);
            }
        }
    }
}
