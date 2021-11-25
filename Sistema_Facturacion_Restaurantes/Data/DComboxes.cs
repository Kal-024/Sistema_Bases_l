using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DComboxes
    {
        public DataTable CargarDepartamentos()
        {
            DataTable dtDepartamentos = new DataTable("Departamentos");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarLocalidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtDepartamentos);

            }
            catch (Exception ex)
            {
                dtDepartamentos = null;
            }
            return dtDepartamentos;
        }

        public DataTable CargarEmpleados()
        {
            DataTable dtEmpleados = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtEmpleados);

            }
            catch (Exception ex)
            {
                dtEmpleados = null;
            }
            return dtEmpleados;
        }

        public DataTable CargarMesero(int SucursalID)
        {
            DataTable dtMeseros = new DataTable("Mesero");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "CargarMeseroPorSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@SucursalID";
                Nombre.SqlDbType = SqlDbType.Int;
                Nombre.Value = SucursalID;
                SqlCmd.Parameters.Add(Nombre);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtMeseros);

            }
            catch (Exception ex)
            {
                dtMeseros = null;
            }
            return dtMeseros;
        }

        public DataTable CargarSucursal()
        {
            DataTable dtSucursal = new DataTable("Sucursales");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "CargarSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtSucursal);

            }
            catch (Exception ex)
            {
                dtSucursal = null;
            }
            return dtSucursal;
        }

        public DataTable CargarMesas(int SucursalID)
        {
            DataTable dtMeseros = new DataTable("Mesero");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "CargarMesasPorSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@SucursalID";
                Nombre.SqlDbType = SqlDbType.Int;
                Nombre.Value = SucursalID;
                SqlCmd.Parameters.Add(Nombre);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtMeseros);

            }
            catch (Exception ex)
            {
                dtMeseros = null;
            }
            return dtMeseros;
        }

        public DataTable CargarOrden(int SucursalID)
        {
            DataTable dtOrdenes = new DataTable("Mesero");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarOrdenBasicoPorSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@SucursalID";
                Nombre.SqlDbType = SqlDbType.Int;
                Nombre.Value = SucursalID;
                SqlCmd.Parameters.Add(Nombre);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtOrdenes);

            }
            catch (Exception ex)
            {
                dtOrdenes = null;
            }
            return dtOrdenes;
        }

        public DataTable MostrarOrdenForeignKey(int SucursalID)
        {
            DataTable dtOrdenes = new DataTable("Mesero");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarOrdenFKPorSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@SucursalID";
                Nombre.SqlDbType = SqlDbType.Int;
                Nombre.Value = SucursalID;
                SqlCmd.Parameters.Add(Nombre);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtOrdenes);

            }
            catch (Exception ex)
            {
                dtOrdenes = null;
            }
            return dtOrdenes;
        }

        public DataTable MostrarSucursalForeignKey()
        {
            DataTable dtOrdenes = new DataTable("SucursalFK");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarSucursalFK";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtOrdenes);

            }
            catch (Exception ex)
            {
                dtOrdenes = null;
            }
            return dtOrdenes;
        }

        public DataTable MostrarProveedorForeignKey()
        {
            DataTable dtOrdenes = new DataTable("SucursalFK");
            SqlConnection SqlCon = new SqlConnection();
            
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "ProveedorFK";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtOrdenes);

            }
            catch (Exception ex)
            {
                dtOrdenes = null;
            }
            return dtOrdenes;
        }

        public DataTable MostrarBebidaForeignKey()
        {
            DataTable dtOrdenes = new DataTable("SucursalFK");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "BebidaFK";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtOrdenes);

            }
            catch (Exception ex)
            {
                dtOrdenes = null;
            }
            return dtOrdenes;
        }

        public DataTable MostrarInsumoForeignKey()
        {
            DataTable dtOrdenes = new DataTable("InsumoFK");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "InsumoPK";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtOrdenes);

            }
            catch (Exception ex)
            {
                dtOrdenes = null;
            }
            return dtOrdenes;
        }

        public DataTable OrdenDetalleComidaForeignKey()
        {
            DataTable dtOrdenes = new DataTable("OrdenDetalleComidaFK");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "OrdenDetalleComidaFK";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtOrdenes);

            }
            catch (Exception ex)
            {
                dtOrdenes = null;
            }
            return dtOrdenes;
        }
    }
}
