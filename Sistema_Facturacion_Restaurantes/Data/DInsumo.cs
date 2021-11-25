using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DInsumo
    {
        private int InsumoID;
        private string Nombre;
        private int ProveedorID;

        public int insumoID { get => InsumoID; set => InsumoID = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public int proveedorID { get => ProveedorID; set => ProveedorID = value; }

        public DataTable MostrarInsumo()
        {
            DataTable dtSucursales = new DataTable("Insumo");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarInsumo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtSucursales);

            }
            catch (Exception ex)
            {
                dtSucursales = null;
            }
            return dtSucursales;
        }

        public string Insertar(DInsumo insumo)
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
                SqlCmd.CommandText = "AgregarIngrediente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@NombreIngrediente";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 50;
                Nombre.Value = insumo.Nombre;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter ProveedorID = new SqlParameter();
                ProveedorID.ParameterName = "@ProveedorID";
                ProveedorID.SqlDbType = SqlDbType.Int;
                ProveedorID.Value = insumo.ProveedorID;
                SqlCmd.Parameters.Add(ProveedorID);

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

        public string Actulizar(DInsumo insumo)
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
                SqlCmd.CommandText = "ActualizarInsumo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter InsumoID = new SqlParameter();
                InsumoID.ParameterName = "@InsumoID";
                InsumoID.SqlDbType = SqlDbType.Int;
                InsumoID.Value = insumo.InsumoID;
                SqlCmd.Parameters.Add(InsumoID);

                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@NombreIngrediente";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 50;
                Nombre.Value = insumo.Nombre;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter ProveedorID = new SqlParameter();
                ProveedorID.ParameterName = "@ProveedorID";
                ProveedorID.SqlDbType = SqlDbType.Int;
                ProveedorID.Value = insumo.ProveedorID;
                SqlCmd.Parameters.Add(ProveedorID);

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
