using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    public class DSucursal
    {
        private int SucursalID;
        private string Nombre;
        private int ResponsableID;
        private string Telefono;
        private int LocalidadID;
        private string Direccion;

        public int sucursalID { get => SucursalID; set => SucursalID = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public int responsableID { get => ResponsableID; set => ResponsableID = value; }
        public string telefono { get => Telefono; set => Telefono = value; }
        public int localidadID { get => LocalidadID; set => LocalidadID = value; }
        public string direccion { get => Direccion; set => Direccion = value; }

        public DataTable MostrarSucursal()
        {
            DataTable dtSucursales = new DataTable("Sucursales");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarSucuarsal";
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

        public string Insertar(DSucursal sucursal)
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
                SqlCmd.CommandText = "AgregarSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //@Nombre varchar(50), @ResponsableID int, @Telefono varchar(24), @LocalidadID int, @Direccion varchar(100)
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@Nombre";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 50;
                Nombre.Value = sucursal.Nombre;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter ResponsableID = new SqlParameter();
                ResponsableID.ParameterName = "@ResponsableID";
                ResponsableID.SqlDbType = SqlDbType.Int;
                ResponsableID.Value = sucursal.ResponsableID;
                SqlCmd.Parameters.Add(ResponsableID);

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.SqlDbType = SqlDbType.VarChar;
                Telefono.Size = 24;
                Telefono.Value = sucursal.Telefono;
                SqlCmd.Parameters.Add(Telefono);
                
                SqlParameter ParDirección = new SqlParameter();
                ParDirección.ParameterName = "@Direccion";
                ParDirección.SqlDbType = SqlDbType.VarChar;
                ParDirección.Size = 100;
                ParDirección.Value = sucursal.Direccion;
                SqlCmd.Parameters.Add(ParDirección);

                SqlParameter LocalidadID = new SqlParameter();
                LocalidadID.ParameterName = "@LocalidadID";
                LocalidadID.SqlDbType = SqlDbType.Int;
                LocalidadID.Value = sucursal.LocalidadID;
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

        public string Actualizar(DSucursal sucursal)
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
                SqlCmd.CommandText = "ActualizarSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                //@Nombre varchar(50), @ResponsableID int, @Telefono varchar(24), @LocalidadID int, @Direccion varchar(100)
                SqlParameter SucursalID = new SqlParameter();
                SucursalID.ParameterName = "@SucursalID";
                SucursalID.SqlDbType = SqlDbType.Int;
                SucursalID.Value = sucursal.SucursalID;
                SqlCmd.Parameters.Add(SucursalID);

                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@Nombre";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 50;
                Nombre.Value = sucursal.Nombre;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter ResponsableID = new SqlParameter();
                ResponsableID.ParameterName = "@ResponsableID";
                ResponsableID.SqlDbType = SqlDbType.Int;
                ResponsableID.Value = sucursal.ResponsableID;
                SqlCmd.Parameters.Add(ResponsableID);

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.SqlDbType = SqlDbType.VarChar;
                Telefono.Size = 24;
                Telefono.Value = sucursal.Telefono;
                SqlCmd.Parameters.Add(Telefono);

                SqlParameter ParDirección = new SqlParameter();
                ParDirección.ParameterName = "@Direccion";
                ParDirección.SqlDbType = SqlDbType.VarChar;
                ParDirección.Size = 100;
                ParDirección.Value = sucursal.Direccion;
                SqlCmd.Parameters.Add(ParDirección);

                SqlParameter LocalidadID = new SqlParameter();
                LocalidadID.ParameterName = "@LocalidadID";
                LocalidadID.SqlDbType = SqlDbType.Int;
                LocalidadID.Value = sucursal.LocalidadID;
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

        public int EliminarSucursal(int SucursalID)
        {
            DataTable dtSucursales = new DataTable("Sucursales");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "ElimanarSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@SucursalID";
                Nombre.SqlDbType = SqlDbType.Int;
                Nombre.Value = SucursalID;
                SqlCmd.Parameters.Add(Nombre);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtSucursales);

            }
            catch (Exception ex)
            {
                dtSucursales = null;
            }
            return 0;
        }
    }
}
