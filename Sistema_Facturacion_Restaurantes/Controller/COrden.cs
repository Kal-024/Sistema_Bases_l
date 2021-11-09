using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class COrden
    {
        public static string Insertar(int EmpleadoID, int MesaID, int ClienteID, string FechaRealizacion)
        {
            DOrden Obj = new DOrden();
            Obj.empleadoID = EmpleadoID;
            Obj.mesaID = MesaID;
            Obj.clienteID = ClienteID;
            Obj.fechaRealizacion = FechaRealizacion;
            return Obj.Insertar(Obj);
        }

        public static string Actualizar(int OrdenID, int EmpleadoID, int MesaID, int ClienteID, string FechaRealizacion)
        {
            DOrden Obj = new DOrden();
            Obj.ordenID = OrdenID;
            Obj.empleadoID = EmpleadoID;
            Obj.mesaID = MesaID;
            Obj.clienteID = ClienteID;
            Obj.fechaRealizacion = FechaRealizacion;
            return Obj.Actualizar(Obj);
        }
    }
}
