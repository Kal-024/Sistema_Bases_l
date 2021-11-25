using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DComidasDePlato
    {
        private int OrdenID;
        private int PlatoID;
        private int Cantidad;
        private int NewPlatoID;

        public int ordenID { get => OrdenID; set => OrdenID = value; }
        public int platoID { get => PlatoID; set => PlatoID = value; }
        public int cantidad { get => Cantidad; set => Cantidad = value; }
        public int newplatoID { get => NewPlatoID; set => NewPlatoID = value; }

        public DataTable Mostrar(int Orden)
        {
            DataTable dtSucursales = new DataTable("Comidas");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarComidasDeOrden";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // Parametro
                SqlParameter OrdenID = new SqlParameter();
                OrdenID.ParameterName = "@OrdenID";
                OrdenID.SqlDbType = SqlDbType.Int;
                OrdenID.Value = Orden;
                SqlCmd.Parameters.Add(OrdenID);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtSucursales);

            }
            catch (Exception ex)
            {
                dtSucursales = null;
            }
            return dtSucursales;
        }

        public string Insertar(DComidasDePlato comida)
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
                SqlCmd.CommandText = "AgregarCamidaAOrden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter OrdenID = new SqlParameter();
                OrdenID.ParameterName = "@OrdenID";
                OrdenID.SqlDbType = SqlDbType.Int;
                OrdenID.Value = comida.OrdenID;
                SqlCmd.Parameters.Add(OrdenID);

                SqlParameter PlatoID = new SqlParameter();
                PlatoID.ParameterName = "@PlatoID";
                PlatoID.SqlDbType = SqlDbType.Int;
                PlatoID.Value = comida.PlatoID;
                SqlCmd.Parameters.Add(PlatoID);

                SqlParameter Cantidad = new SqlParameter();
                Cantidad.ParameterName = "@Cantidad";
                Cantidad.SqlDbType = SqlDbType.Int;
                Cantidad.Value = comida.Cantidad;
                SqlCmd.Parameters.Add(Cantidad);

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

        public string Actualizar(DComidasDePlato comida)
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
                SqlCmd.CommandText = "ActualizarComidaDePlato";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter OrdenID = new SqlParameter();
                OrdenID.ParameterName = "@OrdenID";
                OrdenID.SqlDbType = SqlDbType.Int;
                OrdenID.Value = comida.OrdenID;
                SqlCmd.Parameters.Add(OrdenID);

                SqlParameter PlatoID = new SqlParameter();
                PlatoID.ParameterName = "@OldPlatoID";
                PlatoID.SqlDbType = SqlDbType.Int;
                PlatoID.Value = comida.PlatoID;
                SqlCmd.Parameters.Add(PlatoID);

                SqlParameter NewPlatoID = new SqlParameter();
                NewPlatoID.ParameterName = "@NewPlatoID";
                NewPlatoID.SqlDbType = SqlDbType.Int;
                NewPlatoID.Value = comida.NewPlatoID;
                SqlCmd.Parameters.Add(NewPlatoID);

                SqlParameter Cantidad = new SqlParameter();
                Cantidad.ParameterName = "@Cantidad";
                Cantidad.SqlDbType = SqlDbType.Int;
                Cantidad.Value = comida.Cantidad;
                SqlCmd.Parameters.Add(Cantidad);

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
