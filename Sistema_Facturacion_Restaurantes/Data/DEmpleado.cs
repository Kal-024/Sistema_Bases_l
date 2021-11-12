using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DEmpleado
    {
        private string Cedula;
        private string Nombres;
        private string Apellidos;
        private string Cargo;
        private string Telefono;
        private string Direccion;
        private int SucursalID;
        private int EmpleadoID;

        public string cedula { get => Cedula; set => Cedula = value; }
        public string nombres { get => Nombres; set => Nombres = value; }
        public string apellidos{ get => Apellidos; set => Apellidos = value; }
        public string cargo { get => Cargo; set => Cargo = value; }
        public string direccion { get => Direccion; set => Direccion = value; }
        public string telefono { get => Telefono; set => Telefono = value; }
        public int sucursalID { get => SucursalID; set => SucursalID = value; }
        public int empleadoID { get => EmpleadoID; set => EmpleadoID = value; }

        public string Insertar(DEmpleado empleado)
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
                SqlCmd.CommandText = "AgregarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //@Cedula varchar(15), @Nombres varchar(50), @Apellidos varchar(50), @Cargo varchar(50),
                //@Telefono varchar(24), @Direccion varchar(100), @SucursalID int
                SqlParameter Cedula = new SqlParameter();
                Cedula.ParameterName = "@Cedula";
                Cedula.SqlDbType = SqlDbType.VarChar;
                Cedula.Size = 15;
                Cedula.Value = empleado.Cedula;
                SqlCmd.Parameters.Add(Cedula);

                SqlParameter Nombres = new SqlParameter();
                Nombres.ParameterName = "@Nombres";
                Nombres.SqlDbType = SqlDbType.VarChar;
                Nombres.Size = 50;
                Nombres.Value = empleado.Nombres;
                SqlCmd.Parameters.Add(Nombres);

                SqlParameter Apellidos = new SqlParameter();
                Apellidos.ParameterName = "@Apellidos";
                Apellidos.SqlDbType = SqlDbType.VarChar;
                Apellidos.Size = 50;
                Apellidos.Value = empleado.Apellidos;
                SqlCmd.Parameters.Add(Apellidos);

                SqlParameter Cargo = new SqlParameter();
                Cargo.ParameterName = "@Cargo";
                Cargo.SqlDbType = SqlDbType.VarChar;
                Cargo.Size = 50;
                Cargo.Value = empleado.Cargo;
                SqlCmd.Parameters.Add(Cargo);

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.SqlDbType = SqlDbType.VarChar;
                Telefono.Size = 24;
                Telefono.Value = empleado.Telefono;
                SqlCmd.Parameters.Add(Telefono);

                SqlParameter Direccion = new SqlParameter();
                Direccion.ParameterName = "@Direccion";
                Direccion.SqlDbType = SqlDbType.VarChar;
                Direccion.Size = 100;
                Direccion.Value = empleado.Direccion;
                SqlCmd.Parameters.Add(Direccion);

                SqlParameter SucursalID = new SqlParameter();
                SucursalID.ParameterName = "@SucursalID";
                SucursalID.SqlDbType = SqlDbType.Int;
                SucursalID.Value = empleado.SucursalID;
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

        public DataTable MostrarEmpleadoPorSucursal(int SucursalIDP)
        {
            DataTable dtEmpleados = new DataTable("Empleados");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarEmpleadoPorSucursal";
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

        public string Actualizar(DEmpleado empleado)
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
                SqlCmd.CommandText = "ActualizarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //@Nombre varchar(50), @ResponsableID int, @Telefono varchar(24), @LocalidadID int, @Direccion varchar(100)
                SqlParameter EmpleadoID = new SqlParameter();
                EmpleadoID.ParameterName = "@EmpleadoID";
                EmpleadoID.SqlDbType = SqlDbType.Int;
                EmpleadoID.Value = empleado.EmpleadoID;
                SqlCmd.Parameters.Add(EmpleadoID);

                SqlParameter Cedula = new SqlParameter();
                Cedula.ParameterName = "@Cedula";
                Cedula.SqlDbType = SqlDbType.VarChar;
                Cedula.Size = 15;
                Cedula.Value = empleado.Cedula;
                SqlCmd.Parameters.Add(Cedula);

                SqlParameter Nombres = new SqlParameter();
                Nombres.ParameterName = "@Nombres";
                Nombres.SqlDbType = SqlDbType.VarChar;
                Nombres.Size = 50;
                Nombres.Value = empleado.Nombres;
                SqlCmd.Parameters.Add(Nombres);

                SqlParameter Apellidos = new SqlParameter();
                Apellidos.ParameterName = "@Apellidos";
                Apellidos.SqlDbType = SqlDbType.VarChar;
                Apellidos.Size = 50;
                Apellidos.Value = empleado.Apellidos;
                SqlCmd.Parameters.Add(Apellidos);

                SqlParameter Cargo = new SqlParameter();
                Cargo.ParameterName = "@Cargo";
                Cargo.SqlDbType = SqlDbType.VarChar;
                Cargo.Size = 50;
                Cargo.Value = empleado.Cargo;
                SqlCmd.Parameters.Add(Cargo);

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.SqlDbType = SqlDbType.VarChar;
                Telefono.Size = 24;
                Telefono.Value = empleado.Telefono;
                SqlCmd.Parameters.Add(Telefono);

                SqlParameter Direccion = new SqlParameter();
                Direccion.ParameterName = "@Direccion";
                Direccion.SqlDbType = SqlDbType.VarChar;
                Direccion.Size = 100;
                Direccion.Value = empleado.Direccion;
                SqlCmd.Parameters.Add(Direccion);

                SqlParameter SucursalID = new SqlParameter();
                SucursalID.ParameterName = "@SucursalID";
                SucursalID.SqlDbType = SqlDbType.Int;
                SucursalID.Value = empleado.SucursalID;
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
    }
}
