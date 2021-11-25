using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CMesa
    {
        public static string Insertar(int CantidadAsiento, string Area, int SucursalId)
        {
            DMesa Obj = new DMesa();
            Obj.cantidadAsiento = CantidadAsiento;
            Obj.area = Area;
            Obj.sucursalID = SucursalId;

            return Obj.Insertar(Obj);
        }

        public static string Actualizar(int MesaID, int CantidadAsiento, string Area, int SucursalId)
        {
            DMesa Obj = new DMesa();
            Obj.mesaID = MesaID;
            Obj.cantidadAsiento = CantidadAsiento;
            Obj.area = Area;
            Obj.sucursalID = SucursalId;

            return Obj.Actualizar(Obj);
        }
        public static DataTable MostrarMesaPorSucursal(int SucursalID)
        {
            return new DMesa().MostrarMesaPorSucursal(SucursalID);
        }

        public static DataTable LoadTableAvailableForSucursal(int SucursalID)
        {
            return new DMesa().LoadTableAvailableForSucursall(SucursalID);
        }




    }
}
