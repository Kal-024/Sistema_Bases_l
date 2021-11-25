using Sistema_Facturacion_Restaurantes.Controller;
using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Facturacion_Restaurantes.Forms
{
    public partial class frmSaveReserva : Form
    {


        public Boolean isUpdate = false;
        String rol;
        public int ClienteID = 0;
        int sucursalID;
        public int EditableReservaID = 0;


        SqlConnection cmd = new SqlConnection("Data Source = TV-236; Initial Catalog = Restaurantes; user=adminRestaurante; password =password01");


        public frmSaveReserva(int sucursal, string rolUsuario, int mesaId)
        {
            InitializeComponent();
            rol = rolUsuario;
            sucursalID = sucursal;
            nupAsistente.Minimum = 2;
            nupAsistente.Maximum = 12;

            // Cargar el cmb comodin Sucursal

            Dictionary<int, string> mesas = new Dictionary<int, string>();

            SqlCommand message = new SqlCommand(" Select M.Area + ' ' + CONCAT(M.CantidadAsiento, ' asientos, ') + S.Nombre as Mesa from Mesa as M inner join Sucursal as S on M.SucursalID = S.SucursalID where M.MesaID = '" + mesaId + "'", cmd);
            cmd.Open();
            SqlDataReader reader = message.ExecuteReader();

            while (reader.Read())
            {
                string tableInf = reader["Mesa"].ToString();
                mesas.Add(mesaId, tableInf);
            }

            cmd.Close();

            foreach (DataRow row in CMesa.LoadTableAvailableForSucursal(sucursalID).Rows)
            {
                mesas.Add((int)row[1], (string)row[0]);
            }

            this.cmbMesas.DataSource = new BindingSource(mesas, null);
            this.cmbMesas.DisplayMember = "Value";
            this.cmbMesas.ValueMember = "Key";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                int MesaID = ((KeyValuePair<int, string>)this.cmbMesas.SelectedItem).Key;
                int clienteID = ClienteID;
                int cantidadA = (int)nupAsistente.Value;
                string fechaR = dtpFechaR.Value.ToString();
                string fechaL = dtpFechaL.Value.ToString();
                int atencionE;
                if (rbtnNo.Checked)
                {
                    atencionE = 0;
                }
                else
                {
                    atencionE = 1;
                }

                string rpta = "";
                if (isUpdate)
                {
                    rpta = CReserva.Actualizar(EditableReservaID, MesaID, clienteID, cantidadA, fechaR, fechaL, atencionE);

                    if (rpta.Equals("OK"))
                        MessageBox.Show("Datos actualizados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(rpta, "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rpta = CReserva.Insertar(MesaID, clienteID, cantidadA, fechaR, fechaL, atencionE);

                    if (rpta.Equals("OK"))
                        MessageBox.Show("Datos ingresados exitosamente", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(rpta, "Sistema de Reservas aqui estro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClienteCatalogo cc = new FrmClienteCatalogo(rol, this);
            // Le indicamos a VS que cc va a formar de este form (FrmOrden) desde donde lo instanciamos
            // es decir que cc sera hijo de FrmOrden
            this.AddOwnedForm(cc);
            cc.ShowDialog();
            DataTable dato = CCliente.MostrarNombreCliente(ClienteID);
            try
            {
                txtCliente.Text = dato.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void fillSpaces(int MesaID, int clienteID, int cantidadA, string fechaR, string fechaL, int atencionE)
        {
            //Cargar los comboxes con los datos iniciales
            DataTable dato = CCliente.MostrarNombreCliente(clienteID);
            this.ClienteID = clienteID;
            txtCliente.Text = dato.Rows[0][0].ToString();
            cmbMesas.SelectedValue = MesaID;
            nupAsistente.Value = cantidadA;
            DateTime fr = Convert.ToDateTime(fechaR);
            dtpFechaR.Value = fr.AddDays(0);
            DateTime fl = Convert.ToDateTime(fechaL);
            dtpFechaL.Value = fl.AddDays(0);
            if (atencionE == 0)
            {
                rbtnNo.Checked = true;
            }
            else
            {
                rbtnYes.Checked = true;
            }
        }

    }

}

