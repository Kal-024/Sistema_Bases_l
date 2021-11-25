using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CInsumo
    {
        public static DataTable MostrarInsumo()
        {
            return new DInsumo().MostrarInsumo();
        }

        public static string Insertar(string Nombre, int ProveedorID)
        {
            DInsumo Obj = new DInsumo();
            Obj.nombre = Nombre;
            Obj.proveedorID = ProveedorID;
            return Obj.Insertar(Obj);
        }

        public static string Actulizar(int InsumoID, string Nombre, int ProveedorID)
        {
            DInsumo Obj = new DInsumo();
            Obj.insumoID = InsumoID;
            Obj.nombre = Nombre;
            Obj.proveedorID = ProveedorID;
            return Obj.Actulizar(Obj);
        }
    }
}
