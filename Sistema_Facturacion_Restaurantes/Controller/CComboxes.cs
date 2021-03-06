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

        public static DataTable CargarMesero(int SucursalID)
        {
            return new DComboxes().CargarMesero(SucursalID);
        }

        public static DataTable CargarSucursal()
        {
            return new DComboxes().CargarSucursal();
        }

        public static DataTable CargarMesas(int SucursalID)
        {
            return new DComboxes().CargarMesas(SucursalID);
        }

        public static DataTable CargarOrden(int SucursalID)
        {
            return new DComboxes().CargarOrden(SucursalID);
        }

        public static DataTable MostrarOrdenForeignKey(int SucursalID)
        {
            return new DComboxes().MostrarOrdenForeignKey(SucursalID);
        }

        public static DataTable MostrarSucursalForeignKey()
        {
            return new DComboxes().MostrarSucursalForeignKey();
        }

        public static DataTable MostrarProveedorForeignKey()
        {
            return new DComboxes().MostrarProveedorForeignKey();
        }

        public static DataTable MostrarBebidaForeignKey()
        {
            return new DComboxes().MostrarBebidaForeignKey();
        }

        public static DataTable MostrarInsumoForeignKey()
        {
            return new DComboxes().MostrarInsumoForeignKey();
        }

        public static DataTable OrdenDetalleComidaForeignKey()
        {
            return new DComboxes().OrdenDetalleComidaForeignKey();
        }

        public static DataTable CargarReserva(int SucursalID)
        {
            return new DComboxes().CargarReserva(SucursalID);
        }

        public static DataTable MostrarReservaForeignKey(int reservaID)
        {
            return new DComboxes().MostrarReservaForeignKey(reservaID);
        }

        public static int EliminarR(int iD, string tabla)
        {
            return new DComboxes().EliminarRegistro(iD,tabla);
        }


    }
}
