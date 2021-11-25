using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CComidasDeOrden
    {
        public static DataTable Mostrar(int Orden)
        {
            return new DComidasDePlato().Mostrar(Orden);
        }

        public static string Insertar(int OrdenID, int PlatoID, int Cantidad)
        {
            DComidasDePlato Obj = new DComidasDePlato();
            Obj.ordenID = OrdenID;
            Obj.platoID = PlatoID;
            Obj.cantidad = Cantidad;
            return Obj.Insertar(Obj);
        }

        public static string Actulizar(int OrdenID, int PlatoID, int NewPlatoID, int Cantidad)
        {
            DComidasDePlato Obj = new DComidasDePlato();
            Obj.ordenID = OrdenID;
            Obj.platoID = PlatoID;
            Obj.newplatoID = NewPlatoID;
            Obj.cantidad = Cantidad;
            return Obj.Actualizar(Obj);
        }
    }
}
