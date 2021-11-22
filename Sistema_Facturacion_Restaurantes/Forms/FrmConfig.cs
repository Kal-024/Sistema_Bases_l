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
    public partial class FrmConfig : Form
    {
        public FrmConfig(string NombredeUsuario, String RolUsuario)
        {
            InitializeComponent();
            lblUserName.Text = NombredeUsuario + "\n" + RolUsuario;
        }
    }
}
