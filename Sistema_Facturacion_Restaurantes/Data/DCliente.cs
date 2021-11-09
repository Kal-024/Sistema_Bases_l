using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DCliente
    {
        private int ClienteID;
        private string Cedula;
        private string Nombres;
        private string Apellidos;
        private string Telefono;

        public int clienteID { get => ClienteID; set => ClienteID = value; }
        public string cedula { get => Cedula; set => Cedula = value; }
        public string nombres { get => Nombres; set => Nombres = value; }
        public string apellidos { get => Apellidos; set => Apellidos = value; }
        public string telefono { get => Telefono; set => Telefono = value; }

        public string Insertar(DCliente cliente)
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
                SqlCmd.CommandText = "AgregarCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //@Nombre varchar(50), @ResponsableID int, @Telefono varchar(24), @LocalidadID int, @Direccion varchar(100)
                SqlParameter Cedula = new SqlParameter();
                Cedula.ParameterName = "@Cedula";
                Cedula.SqlDbType = SqlDbType.VarChar;
                Cedula.Size = 15;
                Cedula.Value = cliente.Cedula;
                SqlCmd.Parameters.Add(Cedula);

                SqlParameter Nombres = new SqlParameter();
                Nombres.ParameterName = "@Nombres";
                Nombres.SqlDbType = SqlDbType.VarChar;
                Nombres.Size = 50;
                Nombres.Value = cliente.Nombres;
                SqlCmd.Parameters.Add(Nombres);

                SqlParameter Apellidos = new SqlParameter();
                Apellidos.ParameterName = "@Apellidos";
                Apellidos.SqlDbType = SqlDbType.VarChar;
                Apellidos.Size = 50;
                Apellidos.Value = cliente.Apellidos;
                SqlCmd.Parameters.Add(Apellidos);

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.SqlDbType = SqlDbType.VarChar;
                Telefono.Size = 24;
                Telefono.Value = cliente.Telefono;
                SqlCmd.Parameters.Add(Telefono);

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

        public DataTable MostrarClientes()
        {
            DataTable dtClientes = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarClientes";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtClientes);

            }
            catch (Exception ex)
            {
                dtClientes = null;
            }
            return dtClientes;
        }

        public string Actualizar(DCliente cliente)
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
                SqlCmd.CommandText = "ActualizarCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //@ClienteID int, @Cedula varchar(15), @Nombres varchar(50), @Apellidos varchar(50), @Telefono varchar(24)
                SqlParameter ClienteID = new SqlParameter();
                ClienteID.ParameterName = "@ClienteID";
                ClienteID.SqlDbType = SqlDbType.Int;
                ClienteID.Value = cliente.ClienteID;
                SqlCmd.Parameters.Add(ClienteID);

                SqlParameter Nombres = new SqlParameter();
                Nombres.ParameterName = "@Nombres";
                Nombres.SqlDbType = SqlDbType.VarChar;
                Nombres.Size = 50;
                Nombres.Value = cliente.Nombres;
                SqlCmd.Parameters.Add(Nombres);

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.SqlDbType = SqlDbType.VarChar;
                Telefono.Size = 24;
                Telefono.Value = cliente.Telefono;
                SqlCmd.Parameters.Add(Telefono);

                SqlParameter Cedula = new SqlParameter();
                Cedula.ParameterName = "@Cedula";
                Cedula.SqlDbType = SqlDbType.VarChar;
                Cedula.Size = 15;
                Cedula.Value = cliente.Cedula;
                SqlCmd.Parameters.Add(Cedula);

                SqlParameter Apellidos = new SqlParameter();
                Apellidos.ParameterName = "@Apellidos";
                Apellidos.SqlDbType = SqlDbType.VarChar;
                Apellidos.Size = 50;
                Apellidos.Value = cliente.Apellidos;
                SqlCmd.Parameters.Add(Apellidos);

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
