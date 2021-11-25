using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CReserva
    {
        public static string Insertar(int MesaID, int ClienteID, int CantidadA, string fechaR, string fechaL, int atencionE)
        {
            DReservar Obj = new DReservar();
            Obj.mesaID = MesaID;
            Obj.clienteID = ClienteID;
            Obj.cantidadAsistente = CantidadA;
            Obj.fechaReserva = fechaR;
            Obj.fechaLLegada = fechaL;
            Obj.atencionEspecial = atencionE;
            return Obj.Insertar(Obj);
        }


        public static string Actualizar(int reservaID,int MesaID, int ClienteID, int CantidadA, string fechaR, string fechaL, int atencionE)
        {
            DReservar Obj = new DReservar();
            Obj.reservaID = reservaID;
            Obj.mesaID = MesaID;
            Obj.clienteID = ClienteID;
            Obj.cantidadAsistente = CantidadA;
            Obj.fechaReserva = fechaR;
            Obj.fechaLLegada = fechaL;
            Obj.atencionEspecial = atencionE;
            return Obj.Actualizar(Obj);
        }

    }
}
