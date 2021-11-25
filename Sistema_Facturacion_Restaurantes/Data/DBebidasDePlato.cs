using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DBebidasDePlato
    {
        private int OrdenID;
        private int BebidaID;
        private int Cantidad;
        private int NewBebidaID;

        public int ordenID { get => OrdenID; set => OrdenID = value; }
        public int bebidaID { get => BebidaID; set => BebidaID = value; }
        public int cantidad { get => Cantidad; set => Cantidad = value; }
        public int newBebidaID { get => NewBebidaID; set => NewBebidaID = value; }

        public DataTable Mostrar(int Orden)
        {
            DataTable dtSucursales = new DataTable("Bebida");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarBebidasDeOrden";
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

        public string Insertar(DBebidasDePlato comida)
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
                SqlCmd.CommandText = "AgregarBebidaAOrden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter OrdenID = new SqlParameter();
                OrdenID.ParameterName = "@OrdenID";
                OrdenID.SqlDbType = SqlDbType.Int;
                OrdenID.Value = comida.OrdenID;
                SqlCmd.Parameters.Add(OrdenID);

                SqlParameter BebidaID = new SqlParameter();
                BebidaID.ParameterName = "@BebidaID";
                BebidaID.SqlDbType = SqlDbType.Int;
                BebidaID.Value = comida.BebidaID;
                SqlCmd.Parameters.Add(BebidaID);

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

        public string Actualizar(DBebidasDePlato comida)
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
                SqlCmd.CommandText = "ActualizarBebidaDePlato";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter OrdenID = new SqlParameter();
                OrdenID.ParameterName = "@OrdenID";
                OrdenID.SqlDbType = SqlDbType.Int;
                OrdenID.Value = comida.OrdenID;
                SqlCmd.Parameters.Add(OrdenID);

                SqlParameter BebidaID = new SqlParameter();
                BebidaID.ParameterName = "@OldBebidaID";
                BebidaID.SqlDbType = SqlDbType.Int;
                BebidaID.Value = comida.BebidaID;
                SqlCmd.Parameters.Add(BebidaID);

                SqlParameter NewBebidaID = new SqlParameter();
                NewBebidaID.ParameterName = "@NewBebidaID";
                NewBebidaID.SqlDbType = SqlDbType.Int;
                NewBebidaID.Value = comida.NewBebidaID;
                SqlCmd.Parameters.Add(NewBebidaID);

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
