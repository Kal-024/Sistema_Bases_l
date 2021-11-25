using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CBebida
    {
        public static DataTable MostrarBebida()
        {
            return new DBebida().MostrarBebida();
        }

        public static string Insertar(string Nombre, int ProveedorID, double Precio)
        {
            DBebida Obj = new DBebida();
            Obj.nombre = Nombre;
            Obj.proveedorID = ProveedorID;
            Obj.precio = Precio;
            return Obj.Insertar(Obj);
        }

        public static string Actulizar(int BebidaID, string Nombre, int ProveedorID, double Precio)
        {
            DBebida Obj = new DBebida();
            Obj.bebidaID = BebidaID;
            Obj.nombre = Nombre;
            Obj.proveedorID = ProveedorID;
            Obj.precio = Precio;
            return Obj.Actualizar(Obj);
        }
    }
}
