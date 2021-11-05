using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CComboxes
    {
        public static DataTable CargarDepartamentos()
        {
            return new DComboxes().CargarDepartamentos();
        }
        
        public static DataTable CargarEmpleados()
        {
            return new DComboxes().CargarEmpleados();
        }
    }
}
