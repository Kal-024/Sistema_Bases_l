using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CPlato
    {
        public static DataTable MostrarPlato()
        {
            return new DPlato().MostrarPlato();
        }

        public static string Insertar(string Nombre, string Categoria, string Descripcion, double Precio)
        {
            DPlato Obj = new DPlato();
            Obj.nombre = Nombre;
            Obj.categoria = Categoria;
            Obj.descripcion = Descripcion;
            Obj.precio = Precio;
            return Obj.Insertar(Obj);
        }

        public static string Actualizar(int PlatoID, string Nombre, string Categoria, string Descripcion, double Precio)
        {
            DPlato Obj = new DPlato();
            Obj.platoID = PlatoID;
            Obj.nombre = Nombre;
            Obj.categoria = Categoria;
            Obj.descripcion = Descripcion;
            Obj.precio = Precio;
            return Obj.Actualizar(Obj);
        }
    }
}
