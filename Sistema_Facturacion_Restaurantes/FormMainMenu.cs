using Sistema_Facturacion_Restaurantes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Facturacion_Restaurantes.Reportes;

namespace Sistema_Facturacion_Restaurantes
{
    public partial class FormMainMenu : Form
    {
        //Campos
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        //Datos de usuario
        string NombreUsuario;
        string Rol;

        //Constructor
        public FormMainMenu(string NombredeUsuario, String RolUsuario)
        {
            InitializeComponent();

            ToolTipMensaje();
            NombreUsuario = NombredeUsuario;
            Rol = RolUsuario;

            switch (Rol)
            {
                case "Recepcionista":
                    {
                        btnClientes.Hide();
                        btnEmpleados.Hide();
                        btnProveedores.Hide();
                        btnReport.Hide();
                        break;
                    }
                case "Jefe Cocina":
                    {
                        btnClientes.Hide();
                        btnEmpleados.Hide();
                        btnReport.Hide();
                        break;
                    }
                case "Chef":
                    {
                        btnSucursal.Hide();
                        btnOrders.Hide();
                        btnEmpleados.Hide();
                        btnClientes.Hide();
                        btnReport.Hide();
                        btnReservar.Hide();
                        break;
                    }

            }
           
            random = new Random();
            btnCloseChildForm.Visible = false;
            //Ocultar los botones de ventana
            this.Text = String.Empty;
            //this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Mensajes para los botones de ventana
        private void ToolTipMensaje()
        {
            this.ttButtonMensaje.SetToolTip(btnClientes, "Cerrar");
            ///this.ttButtonMensaje.SetToolTip(btnMaximize, "Maximizar");
            //this.ttButtonMensaje.SetToolTip(btnMinimize, "Minimizar");
        }

        //Métodos
        /*private Color SelectThemeColor()
        {
            /*int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }*/

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    btnCloseChildForm.Visible = true;

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitle.Text = childForm.Text;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSucursal(Rol), sender);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Ordenes";
            OpenChildForm(new Forms.FrmOrdenCatalogo(Rol), sender);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPlatos(Rol), sender);
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.formBebidas(Rol), sender);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormNotifications(), sender);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSetting(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            
            activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Home";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Clientes";
            FrmClienteCatalogo fcc = new FrmClienteCatalogo(Rol,this);
            fcc.btnSeleccionarCliente.Hide();
            OpenChildForm(fcc, sender);   
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Reservaciones";
            OpenChildForm(new Forms.frmReserva(Rol), sender);
        }

        private void btnConfig_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FrmConfig(NombreUsuario, Rol), sender);
        }

        private void btnSucursal_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Sucursales";
            OpenChildForm(new Forms.FormSucursal(Rol), sender);
        }

        private void btnPlatos_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Platos";
            OpenChildForm(new Forms.FormPlatos(Rol), sender);
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Bebidas";
            OpenChildForm(new Forms.formBebidas(Rol), sender);   //Pendiente no abre el correctamente aún 
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Empleados";
           OpenChildForm(new Forms.FrmEmpleadoCatalogo(), sender);     
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Proveedores";
            FrmProveedorCatalogo fpc = new FrmProveedorCatalogo();
            fpc.btnSeleccionarProveedor.Hide();
            OpenChildForm(fpc, sender);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reportes.FrmReportes(), sender);
        }

    }
}
