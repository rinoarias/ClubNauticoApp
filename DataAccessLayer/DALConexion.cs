using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALConexion
    {
        private string servidor;
        private string usuario;
        private string clave;
        private string baseDatos;
        private DataSet sqlDataSet;
        private DataTable sqlDataTable;
        private SqlDataReader sqlDataReader;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlDataAdapter;
        private SqlConnection sqlConexion = new SqlConnection();


        public DALConexion()
        {
            this.servidor = "localhost";
            this.usuario = "sa";
            this.clave = "Cuda12ab";
            this.baseDatos = "CLUB_NAUTICO";
        }

        public DALConexion(string servidor, string usuario, string clave, string baseDatos)
        {
            this.servidor = servidor;
            this.usuario = usuario;
            this.clave = clave;
            this.baseDatos = baseDatos;
        }

        public SqlConnection abrirConexion()
        {
            // verificar si la conexion está cerrada
            if (this.sqlConexion.State == ConnectionState.Closed)
            {
                //Conexion.ConnectionString = "Server= " + servidor + " ; Database= " + baseDeDatos + "Integrated Security=true";
                this.sqlConexion.ConnectionString = "Server= " + this.servidor + " ; Database= " + this.baseDatos + ";User id =" + this.usuario + "; Password= " + this.clave;
                this.sqlConexion.Open();
            }
            return this.sqlConexion;
        }

        public SqlConnection cerrarConexion()
        {
            if (this.sqlConexion.State == ConnectionState.Open)
            {
                this.sqlConexion.Close();
            }
            return this.sqlConexion;
        }

        public DataTable obtenerDatos(string nombreProcedimientoAlmacenado)
        {
            this.sqlDataTable = new DataTable();
            try
            {
                this.sqlCommand = new SqlCommand();
                this.sqlCommand.CommandText = nombreProcedimientoAlmacenado;
                this.sqlCommand.CommandType = CommandType.StoredProcedure;
                this.sqlCommand.Connection = this.abrirConexion();
                this.sqlDataReader = this.sqlCommand.ExecuteReader();
                this.sqlDataTable.Load(this.sqlDataReader);
                this.sqlDataReader.Close();
                this.cerrarConexion();
            }
            catch (Exception ex)
            {
                return null;
            }
            return this.sqlDataTable;
        }


        public DataTable obtenerDatos(string nombreProcedimientoAlmacenado, List<SqlParameter> listadoParametrosSql)
        { 
            this.sqlDataTable = new DataTable();
            try
            {
                this.sqlCommand = new SqlCommand();
                this.sqlCommand.CommandText = nombreProcedimientoAlmacenado;
                this.sqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parametro in listadoParametrosSql)
                {
                    this.sqlCommand.Parameters.Add(parametro);
                }
                this.sqlCommand.Connection = this.abrirConexion();
                this.sqlDataReader = this.sqlCommand.ExecuteReader();
                this.sqlDataTable.Load(this.sqlDataReader);
                this.sqlDataReader.Close();
                this.cerrarConexion();
            }
            catch (SqlException ex)
            {
                return null;
            }
            return this.sqlDataTable;
        }


        public int insertarRegistro(string nombreProcedimientoAlmacenado, List<SqlParameter> listadoParametrosSql)
        {
            try
            {
                this.sqlCommand = new SqlCommand();
                this.sqlCommand.CommandText = nombreProcedimientoAlmacenado;
                this.sqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parametro in listadoParametrosSql)
                {
                    this.sqlCommand.Parameters.Add(parametro);
                }
                this.sqlCommand.Connection = this.abrirConexion();
                int filasAfectadas = this.sqlCommand.ExecuteNonQuery();
                this.cerrarConexion();
                return filasAfectadas;
            }
            catch (SqlException ex)
            {
                return ex.Number;
            }
        }
    }
}
