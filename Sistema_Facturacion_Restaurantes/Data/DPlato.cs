using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Restaurantes.Data
{
    class DPlato
    {
        private int PlatoID;
        private string Nombre;
        private string Categoria;
        private string Descripcion;
        private double Precio;

        public int platoID { get => PlatoID; set => PlatoID = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public string categoria { get => Categoria; set => Categoria = value; }
        public string descripcion { get => Descripcion; set => Descripcion = value; }
        public double precio { get => Precio; set => Precio = value; }

        public DataTable MostrarPlato()
        {
            DataTable dtSucursales = new DataTable("Platos");
            SqlConnection SqlCon = new SqlConnection();

            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.Cn;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarPlato";
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

        public string Insertar(DPlato plato)
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
                SqlCmd.CommandText = "AgregarPlato";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@Nombre";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 100;
                Nombre.Value = plato.Nombre;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter Categoria = new SqlParameter();
                Categoria.ParameterName = "@Categoria";
                Categoria.SqlDbType = SqlDbType.VarChar;
                Categoria.Size = 100;
                Categoria.Value = plato.Categoria;
                SqlCmd.Parameters.Add(Categoria);

                SqlParameter Descripcion = new SqlParameter();
                Descripcion.ParameterName = "@Descripcion";
                Descripcion.SqlDbType = SqlDbType.VarChar;
                Descripcion.Size = 100;
                Descripcion.Value = plato.Descripcion;
                SqlCmd.Parameters.Add(Descripcion);

                SqlParameter Precio = new SqlParameter();
                Precio.ParameterName = "@Precio";
                Precio.SqlDbType = SqlDbType.Money;
                Precio.Value = plato.Precio;
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

        public string Actualizar(DPlato plato)
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
                SqlCmd.CommandText = "ActualizarPlato";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter PlatoID = new SqlParameter();
                PlatoID.ParameterName = "@PlatoID";
                PlatoID.SqlDbType = SqlDbType.Int;
                PlatoID.Value = plato.PlatoID;
                SqlCmd.Parameters.Add(PlatoID);

                SqlParameter Nombre = new SqlParameter();
                Nombre.ParameterName = "@Nombre";
                Nombre.SqlDbType = SqlDbType.VarChar;
                Nombre.Size = 100;
                Nombre.Value = plato.Nombre;
                SqlCmd.Parameters.Add(Nombre);

                SqlParameter Categoria = new SqlParameter();
                Categoria.ParameterName = "@Categoria";
                Categoria.SqlDbType = SqlDbType.VarChar;
                Categoria.Size = 100;
                Categoria.Value = plato.Categoria;
                SqlCmd.Parameters.Add(Categoria);

                SqlParameter Descripcion = new SqlParameter();
                Descripcion.ParameterName = "@Descripcion";
                Descripcion.SqlDbType = SqlDbType.VarChar;
                Descripcion.Size = 100;
                Descripcion.Value = plato.Descripcion;
                SqlCmd.Parameters.Add(Descripcion);

                SqlParameter Precio = new SqlParameter();
                Precio.ParameterName = "@Precio";
                Precio.SqlDbType = SqlDbType.Money;
                Precio.Value = plato.Precio;
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
