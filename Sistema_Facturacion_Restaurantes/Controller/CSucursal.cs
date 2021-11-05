using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CSucursal
    {
        public static DataTable MostrarSucursal()
        {
            return new DSucursal().MostrarSucursal();
        }

        public static string Insertar(string Nombre, int ResponsableID, string Telefono, int LocalidadID, string Direccion)
        {
            DSucursal Obj = new DSucursal();
            Obj.nombre = Nombre;
            Obj.responsableID = ResponsableID;
            Obj.telefono = Telefono;
            Obj.localidadID = LocalidadID;
            Obj.direccion = Direccion;
            return Obj.Insertar(Obj);
        }

        public static int EliminarSucursal(int SucursalID)
        {
            return new DSucursal().EliminarSucursal(SucursalID);
        }

        public static string Actualizar(int SucursalID, string Nombre, int ResponsableID, string Telefono, int LocalidadID, string Direccion)
        {
            DSucursal Obj = new DSucursal();
            Obj.sucursalID = SucursalID;
            Obj.nombre = Nombre;
            Obj.responsableID = ResponsableID;
            Obj.telefono = Telefono;
            Obj.localidadID = LocalidadID;
            Obj.direccion = Direccion;
            return Obj.Actualizar(Obj);
        }
    }
}
