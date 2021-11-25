using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DMesa
    {
        private int MesaID;
        private int CantidadAsiento;
        private string Area;
        private int SucursalID;
        public int mesaID { get => MesaID; set => MesaID = value; }
        public int cantidadAsiento { get => CantidadAsiento; set => CantidadAsiento = value; }
        public string area { get => Area; set => Area = value; }
        public int sucursalID { get => SucursalID; set => SucursalID = value; }

        public string Insertar(DMesa mesa)
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
                SqlCmd.CommandText = "AgregarMesa";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //SqlParameter MesaID = new SqlParameter();
                //MesaID.ParameterName = "@MesaID";
                //MesaID.SqlDbType = SqlDbType.Int;
                //MesaID.Value = mesa.MesaID;
                //SqlCmd.Parameters.Add(MesaID);

                SqlParameter CantidadAsiento = new SqlParameter();
                CantidadAsiento.ParameterName = "@CantidadAsiento";
                CantidadAsiento.SqlDbType = SqlDbType.Int;
                CantidadAsiento.Value = mesa.CantidadAsiento;
                SqlCmd.Parameters.Add(CantidadAsiento);

                SqlParameter Area = new SqlParameter();
                Area.ParameterName = "@Area";
                Area.SqlDbType = SqlDbType.VarChar;
                Area.Size = 30;
                Area.Value = mesa.Area;
                SqlCmd.Parameters.Add(Area);

                SqlParameter SucursalID = new SqlParameter();
                SucursalID.ParameterName = "@SucursalID";
                SucursalID.SqlDbType = SqlDbType.Int;
                SucursalID.Value = mesa.SucursalID;
                SqlCmd.Parameters.Add(SucursalID);
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

        public string Actualizar(DMesa mesa)
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
                SqlCmd.CommandText = "ActualizarMesa";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter MesaID = new SqlParameter();
                MesaID.ParameterName = "@MesaID";
                MesaID.SqlDbType = SqlDbType.Int;
                MesaID.Value = mesa.MesaID;
                SqlCmd.Parameters.Add(MesaID);

                SqlParameter CantidadAsiento = new SqlParameter();
                CantidadAsiento.ParameterName = "@CantidadAsiento";
                CantidadAsiento.SqlDbType = SqlDbType.Int;
                CantidadAsiento.Value = mesa.CantidadAsiento;
                SqlCmd.Parameters.Add(CantidadAsiento);

                SqlParameter Area = new SqlParameter();
                Area.ParameterName = "@Area";
                Area.SqlDbType = SqlDbType.VarChar;
                Area.Size = 30;
                Area.Value = mesa.Area;
                SqlCmd.Parameters.Add(Area);

                SqlParameter SucursalID = new SqlParameter();
                SucursalID.ParameterName = "@SucursalID";
                SucursalID.SqlDbType = SqlDbType.Int;
                SucursalID.Value = mesa.SucursalID;
                SqlCmd.Parameters.Add(SucursalID);
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

        public DataTable MostrarMesaPorSucursal(int SucursalIDP)
        {
            DataTable dtEmpleados = new DataTable("Mesas");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarMesaPorSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter SucursalID = new SqlParameter();
                SucursalID.ParameterName = "@SucursalID";
                SucursalID.SqlDbType = SqlDbType.Int;
                SucursalID.Value = SucursalIDP;
                SqlCmd.Parameters.Add(SucursalID);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtEmpleados);

            }
            catch (Exception ex)
            {
                dtEmpleados = null;
            }
            return dtEmpleados;
        }
        
        public DataTable LoadTableAvailableForSucursall(int SucursalIDP)
        {
            DataTable dtSucursal = new DataTable("Mesas");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "LoadTableAvailableForSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter SucursalID = new SqlParameter();
                SucursalID.ParameterName = "@SucursalID";
                SucursalID.SqlDbType = SqlDbType.Int;
                SucursalID.Value = SucursalIDP;
                SqlCmd.Parameters.Add(SucursalID);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtSucursal);

            }
            catch (Exception ex)
            {
                dtSucursal = null;
            }
            return dtSucursal;
        }



    }
}
