using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DBebida
    {
        private int BebidaID;
        private string Nombre;
        private int ProveedorID;
        private double Precio;

        public int bebidaID { get => BebidaID; set => BebidaID = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public int proveedorID { get => ProveedorID; set => ProveedorID = value; }
        public double precio { get => Precio; set => Precio = value; }

        public DataTable MostrarBebida()
        {
            DataTable dtSucursales = new DataTable("Bebidas");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarBebida";
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

        public string Insertar(DBebida bebida)
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
                SqlCmd.CommandText = "AgregarBebida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@Nombre";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 100;
                Nombre.Value = bebida.Nombre;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter ProveedorID = new SqlParameter();
                ProveedorID.ParameterName = "@ProveedorID";
                ProveedorID.SqlDbType = SqlDbType.Int;
                ProveedorID.Value = bebida.ProveedorID;
                SqlCmd.Parameters.Add(ProveedorID);

                SqlParameter Precio = new SqlParameter();
                Precio.ParameterName = "@Precio";
                Precio.SqlDbType = SqlDbType.Money;
                Precio.Value = bebida.Precio;
                SqlCmd.Parameters.Add(Precio);

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

        public string Actualizar(DBebida bebida)
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
                SqlCmd.CommandText = "ActualizarBebida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter BebidaID = new SqlParameter();
                BebidaID.ParameterName = "@BebidaID";
                BebidaID.SqlDbType = SqlDbType.Int;
                BebidaID.Value = bebida.BebidaID;
                SqlCmd.Parameters.Add(BebidaID);

                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@Nombre";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 100;
                Nombre.Value = bebida.Nombre;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter ProveedorID = new SqlParameter();
                ProveedorID.ParameterName = "@ProveedorID";
                ProveedorID.SqlDbType = SqlDbType.Int;
                ProveedorID.Value = bebida.ProveedorID;
                SqlCmd.Parameters.Add(ProveedorID);

                SqlParameter Precio = new SqlParameter();
                Precio.ParameterName = "@Precio";
                Precio.SqlDbType = SqlDbType.Money;
                Precio.Value = bebida.Precio;
                SqlCmd.Parameters.Add(Precio);

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
