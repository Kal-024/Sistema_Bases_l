using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DOrden
    {
        private int OrdenID;
        private int EmpleadoID;
        private int MesaID;
        private int ClienteID;
        string FechaRealizacion;

        public int ordenID { get => OrdenID; set => OrdenID = value; }
        public int empleadoID { get => EmpleadoID; set => EmpleadoID = value; }
        public int mesaID { get => MesaID; set => MesaID = value; }
        public int clienteID { get => ClienteID; set => ClienteID = value; }
        public string  fechaRealizacion { get => FechaRealizacion; set => FechaRealizacion = value; }

        public string Insertar(DOrden orden)
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
                SqlCmd.CommandText = "AgregarOrden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //AgregarOrden @EmpleadoID int, @MesaID int, @ClienteID int, @FechaRealizacion
                SqlParameter EmpleadoID = new SqlParameter();
                EmpleadoID.ParameterName = "@EmpleadoID";
                EmpleadoID.SqlDbType = SqlDbType.Int;
                EmpleadoID.Value = orden.EmpleadoID;
                SqlCmd.Parameters.Add(EmpleadoID);

                SqlParameter MesaID = new SqlParameter();
                MesaID.ParameterName = "@MesaID";
                MesaID.SqlDbType = SqlDbType.Int;
                MesaID.Value = orden.MesaID;
                SqlCmd.Parameters.Add(MesaID);

                SqlParameter ClienteID = new SqlParameter();
                ClienteID.ParameterName = "@ClienteID";
                ClienteID.SqlDbType = SqlDbType.Int;
                ClienteID.Value = orden.ClienteID;
                SqlCmd.Parameters.Add(ClienteID);

                SqlParameter FechaRealizacion = new SqlParameter();
                FechaRealizacion.ParameterName = "@FechaRealizacion";
                FechaRealizacion.SqlDbType = SqlDbType.DateTime;
                FechaRealizacion.Value = orden.FechaRealizacion;
                SqlCmd.Parameters.Add(FechaRealizacion);
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

        public string Actualizar(DOrden orden)
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
                SqlCmd.CommandText = "ActualizarOrden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //ActualizarOrden @OrdenID int, @EmpleadoID int, @MesaID int, @ClienteID int, @FechaRealizacion datetime
                SqlParameter OrdenID = new SqlParameter();
                OrdenID.ParameterName = "@OrdenID";
                OrdenID.SqlDbType = SqlDbType.Int;
                OrdenID.Value = orden.OrdenID;
                SqlCmd.Parameters.Add(OrdenID);

                SqlParameter EmpleadoID = new SqlParameter();
                EmpleadoID.ParameterName = "@EmpleadoID";
                EmpleadoID.SqlDbType = SqlDbType.Int;
                EmpleadoID.Value = orden.EmpleadoID;
                SqlCmd.Parameters.Add(EmpleadoID);

                SqlParameter MesaID = new SqlParameter();
                MesaID.ParameterName = "@MesaID";
                MesaID.SqlDbType = SqlDbType.Int;
                MesaID.Value = orden.MesaID;
                SqlCmd.Parameters.Add(MesaID);

                SqlParameter ClienteID = new SqlParameter();
                ClienteID.ParameterName = "@ClienteID";
                ClienteID.SqlDbType = SqlDbType.Int;
                ClienteID.Value = orden.ClienteID;
                SqlCmd.Parameters.Add(ClienteID);

                SqlParameter FechaRealizacion = new SqlParameter();
                FechaRealizacion.ParameterName = "@FechaRealizacion";
                FechaRealizacion.SqlDbType = SqlDbType.DateTime;
                FechaRealizacion.Value = orden.FechaRealizacion;
                SqlCmd.Parameters.Add(FechaRealizacion);

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
