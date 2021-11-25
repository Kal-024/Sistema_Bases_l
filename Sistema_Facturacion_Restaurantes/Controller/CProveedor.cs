using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CProveedor
    {
        public static DataTable MostrarProveedor()
        {
            return new DProveedor().MostrarProveedor();
        }

        public static string Insertar(string NombreCompania, string Telefono, int LocalidadID, string Direccion)
        {
            DProveedor Obj = new DProveedor();
            Obj.nombre = NombreCompania;
            Obj.telefono = Telefono;
            Obj.localidadID = LocalidadID;
            Obj.direccion = Direccion;
            return Obj.Insertar(Obj);
        }

        public static string Actualizar(int ProveedorID, string NombreCompania, string Telefono, int LocalidadID, string Direccion)
        {
            DProveedor Obj = new DProveedor();
            Obj.proveedorID = ProveedorID;
            Obj.nombre = NombreCompania;
            Obj.telefono = Telefono;
            Obj.localidadID = LocalidadID;
            Obj.direccion = Direccion;
            return Obj.Actualizar(Obj);
        }
    }
}
