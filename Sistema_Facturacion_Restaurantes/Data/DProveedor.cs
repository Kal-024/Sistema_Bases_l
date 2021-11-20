using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DProveedor
    {
        private string NombreCompania;
        private string Telefono;
        private int LocalidadID;
        private string Direccion;

        public string nombre { get => NombreCompania; set => NombreCompania = value; }
        public string telefono { get => Telefono; set => Telefono = value; }
        public int localidadID { get => LocalidadID; set => LocalidadID= value; }
        public string direccion { get => Direccion; set => Direccion = value; }

        public DataTable MostrarProveedor()
        {
            DataTable dtSucursales = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarProveedor";
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

        public string Insertar(DProveedor proveedor)
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
                SqlCmd.CommandText = "AgregarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@NombreCompania";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 100;
                Nombre.Value = proveedor.NombreCompania;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.SqlDbType = SqlDbType.VarChar;
                Telefono.Size = 24;
                Telefono.Value = proveedor.Telefono;
                SqlCmd.Parameters.Add(Telefono);

                SqlParameter Direccion = new SqlParameter();
                Direccion.ParameterName = "@Direccion";
                Direccion.SqlDbType = SqlDbType.VarChar;
                Direccion.Size = 150;
                Direccion.Value = proveedor.Direccion;
                SqlCmd.Parameters.Add(Direccion);

                SqlParameter LocalidadID = new SqlParameter();
                LocalidadID.ParameterName = "@LocalidadID";
                LocalidadID.SqlDbType = SqlDbType.Int;
                LocalidadID.Value = proveedor.LocalidadID;
                SqlCmd.Parameters.Add(LocalidadID);

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
