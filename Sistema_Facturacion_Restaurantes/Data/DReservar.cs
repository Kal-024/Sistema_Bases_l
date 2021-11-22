using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DReservar
    {
        private int ReservaID;
        private int MesaID;
        private int ClienteID;
        private int CantidadAsistente;
        string FechaReserva;
        string FechaLlegada;
        private int AtencionEspecial;

        public int reservaID { get => ReservaID; set => ReservaID = value; }
        public int mesaID { get => MesaID; set => MesaID = value; }
        public int clienteID { get => ClienteID; set => ClienteID = value; }
        public int cantidadAsistente { get => CantidadAsistente; set => CantidadAsistente = value; }
        public string fechaReserva { get => FechaReserva; set => FechaReserva = value; }
        public string fechaLLegada { get => FechaLlegada; set => FechaLlegada = value; }
        public int atencionEspeccial { get => AtencionEspecial; set => AtencionEspecial = value; }









    }
}
