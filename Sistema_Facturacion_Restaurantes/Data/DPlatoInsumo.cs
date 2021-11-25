using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DPlatoInsumo
    {
        private int PlatoID;
        private int InsumoID;

        public int platoID { get => PlatoID; set => PlatoID = value;}
        public int insumoID { get => InsumoID; set => InsumoID = value;}

        public DataTable MostrarPlatoInsumo(int Plato)
        {
            DataTable dtSucursales = new DataTable("Ingredientes");
            SqlConnection SqlCon = new SqlConnection();

            try
            {   
                // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarPlatoInsumoDetalle";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // Parametros
                SqlParameter PlatoID = new SqlParameter();
                PlatoID.ParameterName = "@PlatoID";
                PlatoID.SqlDbType = SqlDbType.Int;
                PlatoID.Value = Plato;
                SqlCmd.Parameters.Add(PlatoID);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtSucursales);

            }
            catch (Exception ex)
            {
                dtSucursales = null;
            }
            return dtSucursales;
        }

        public string Insertar(DPlatoInsumo insumo)
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
                SqlCmd.CommandText = "AgregarPlatoInsumoDetalle";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter PlatoID = new SqlParameter();
                PlatoID.ParameterName = "@PlatoID";
                PlatoID.SqlDbType = SqlDbType.Int;
                PlatoID.Value = insumo.PlatoID;
                SqlCmd.Parameters.Add(PlatoID);

                SqlParameter InsumoID = new SqlParameter();
                InsumoID.ParameterName = "@InsumoID";
                InsumoID.SqlDbType = SqlDbType.Int;
                InsumoID.Value = insumo.InsumoID;
                SqlCmd.Parameters.Add(InsumoID);

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
