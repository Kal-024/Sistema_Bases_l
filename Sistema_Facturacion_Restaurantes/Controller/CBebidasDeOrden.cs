using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CBebidasDeOrden
    {
        public static DataTable Mostrar(int Orden)
        {
            return new DBebidasDePlato().Mostrar(Orden);
        }

        public static string Insertar(int OrdenID, int BebidaID, int Cantidad)
        {
            DBebidasDePlato Obj = new DBebidasDePlato();
            Obj.ordenID = OrdenID;
            Obj.bebidaID = BebidaID;
            Obj.cantidad = Cantidad;
            return Obj.Insertar(Obj);
        }

        public static string Actulizar(int OrdenID, int BebidaID, int NewBebidaID, int Cantidad)
        {
            DBebidasDePlato Obj = new DBebidasDePlato();
            Obj.ordenID = OrdenID;
            Obj.bebidaID = BebidaID;
            Obj.newBebidaID = NewBebidaID;
            Obj.cantidad = Cantidad;
            return Obj.Actualizar(Obj);
        }
    }
}
