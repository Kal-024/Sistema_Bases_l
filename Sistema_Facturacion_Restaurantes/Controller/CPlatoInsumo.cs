using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CPlatoInsumo
    {
        public static DataTable MostrarInsumos(int PlatoID)
        {
            return new DPlatoInsumo().MostrarPlatoInsumo(PlatoID);
        }

        public static string Insertar(int PlatoID, int InsumoID)
        {
            DPlatoInsumo Obj = new DPlatoInsumo();
            Obj.platoID = PlatoID;
            Obj.insumoID = InsumoID;
            return Obj.Insertar(Obj);
        }
    }
}
