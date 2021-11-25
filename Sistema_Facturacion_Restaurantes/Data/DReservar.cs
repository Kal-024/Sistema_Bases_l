using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public int atencionEspecial { get => AtencionEspecial; set => AtencionEspecial = value; }


        public string Insertar(DReservar reserva)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "AgregarReserva";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //AgregarOrden @MesaID int, @ClienteID int, @CantidadA int, @FechaR datetime , @FechaL datatime, @AtencionE int
                SqlParameter MesaID = new SqlParameter();
                MesaID.ParameterName = "@MesaID";
                MesaID.SqlDbType = SqlDbType.Int;
                MesaID.Value = reserva.MesaID;
                SqlCmd.Parameters.Add(MesaID);

                SqlParameter clienteID = new SqlParameter();
                clienteID.ParameterName = "@ClienteID";
                clienteID.SqlDbType = SqlDbType.Int;
                clienteID.Value = reserva.clienteID;
                SqlCmd.Parameters.Add(clienteID);

                SqlParameter cantidadA = new SqlParameter();
                cantidadA.ParameterName = "@CantidadA";
                cantidadA.SqlDbType = SqlDbType.Int;
                cantidadA.Value = reserva.cantidadAsistente;
                SqlCmd.Parameters.Add(cantidadA);

                SqlParameter fechaR = new SqlParameter();
                fechaR.ParameterName = "@fechaR";
                fechaR.SqlDbType = SqlDbType.DateTime;
                fechaR.Value = reserva.fechaReserva;
                SqlCmd.Parameters.Add(fechaR);

                SqlParameter fechaL = new SqlParameter();
                fechaL.ParameterName = "@fechaL";
                fechaL.SqlDbType = SqlDbType.DateTime;
                fechaL.Value = reserva.FechaLlegada;
                SqlCmd.Parameters.Add(fechaL);

                SqlParameter atencionE = new SqlParameter();
                atencionE.ParameterName = "@AtencionE";
                atencionE.SqlDbType = SqlDbType.Int;
                atencionE.Value = reserva.atencionEspecial;
                SqlCmd.Parameters.Add(atencionE);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Actualizar(DReservar reserva)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "ActualizarReserva";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //AgregarOrden @MesaID int, @ClienteID int, @CantidadA int, @FechaR datetime , @FechaL datatime, @AtencionE int

                SqlParameter reservaID = new SqlParameter();
                reservaID.ParameterName = "@ReservaID";
                reservaID.SqlDbType = SqlDbType.Int;
                reservaID.Value = reserva.reservaID;
                SqlCmd.Parameters.Add(reservaID);

                SqlParameter MesaID = new SqlParameter();
                MesaID.ParameterName = "@MesaID";
                MesaID.SqlDbType = SqlDbType.Int;
                MesaID.Value = reserva.mesaID;
                SqlCmd.Parameters.Add(MesaID);

                SqlParameter clienteID = new SqlParameter();
                clienteID.ParameterName = "@ClienteID";
                clienteID.SqlDbType = SqlDbType.Int;
                clienteID.Value = reserva.clienteID;
                SqlCmd.Parameters.Add(clienteID);

                SqlParameter cantidadA = new SqlParameter();
                cantidadA.ParameterName = "@CantidadA";
                cantidadA.SqlDbType = SqlDbType.Int;
                cantidadA.Value = reserva.cantidadAsistente;
                SqlCmd.Parameters.Add(cantidadA);

                SqlParameter fechaR = new SqlParameter();
                fechaR.ParameterName = "@fechaR";
                fechaR.SqlDbType = SqlDbType.DateTime;
                fechaR.Value = reserva.fechaReserva;
                SqlCmd.Parameters.Add(fechaR);

                SqlParameter fechaL = new SqlParameter();
                fechaL.ParameterName = "@fechaL";
                fechaL.SqlDbType = SqlDbType.DateTime;
                fechaL.Value = reserva.FechaLlegada;
                SqlCmd.Parameters.Add(fechaL);

                SqlParameter atencionE = new SqlParameter();
                atencionE.ParameterName = "@AtencionE";
                atencionE.SqlDbType = SqlDbType.Int;
                atencionE.Value = reserva.atencionEspecial;
                SqlCmd.Parameters.Add(atencionE);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }















    }
}
