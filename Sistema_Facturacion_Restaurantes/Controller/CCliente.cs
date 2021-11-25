using Sistema_Facturacion_Restaurantes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Controller
{
    class CCliente
    {
        public static string Insertar(string Cedula, string Nombres, string Apellidos, string Telefono)
        {
            DCliente Obj = new DCliente();
            Obj.cedula = Cedula;
            Obj.nombres = Nombres;
            Obj.apellidos = Apellidos;
            Obj.telefono = Telefono;
            
            return Obj.Insertar(Obj);
        }

        public static DataTable MostrarCliente()
        {
            return new DCliente().MostrarClientes();
        }


        public static DataTable MostrarNombreCliente(int ClienteID)
        {
            return new DCliente().MostrarNombreCliente(ClienteID);
        }

        public static string Actualizar(int ClienteID, string Cedula, string Nombres, string Apellidos, string Telefono)
        {
            DCliente Obj = new DCliente();
            Obj.clienteID = ClienteID;
            Obj.cedula = Cedula;
            Obj.nombres = Nombres;
            Obj.apellidos = Apellidos;
            Obj.telefono = Telefono;
            return Obj.Actualizar(Obj);
        }
    }
}
