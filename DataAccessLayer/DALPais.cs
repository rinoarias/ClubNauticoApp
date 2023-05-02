using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataServiceLayer;

namespace DataAccessLayer
{
    public class DALPais
    {
        private DALConexion conexion;
        private List<SqlParameter> parameters;
        private const string SP_INSERTAR_PAIS = "SP_PAIS_INSERTAR_PAIS";
        private const string SP_EDITAR_PAIS = "SP_PAIS_EDITAR_PAIS";
        private const string SP_EXISTE_PAIS = "SP_PAIS_EXISTE_PAIS";
        private const string SP_PAIS_TIENE_CIUDAD = "SP_CIUDAD_VERIFICAR_PAIS";
        private const string SP_LISTAR_PAISES = "SP_PAIS_LISTAR_PAIS";
        private const string SP_BUSCAR_PAIS_NOMBRE = "SP_PAIS_BUSCAR_PAIS";
        private const string SP_ELIMINAR_PAIS = "SP_PAIS_ELIMINAR_PAIS";

        private bool ConvertDataTableToBoolean(DataTable dataTable)
        {
            bool result = false;
            if (dataTable != null && dataTable.Rows.Count == 1 && dataTable.Columns.Count == 1)
            {
                int value = Convert.ToInt32(dataTable.Rows[0][0]);
                result = value == 1;
            }
            return result;
        }

        public int insertarPais(DSLPais pais)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_NOMBRE_PAIS", pais.NombrePais));
            return conexion.insertarRegistro(SP_INSERTAR_PAIS, parameters);
            // return new DALConexion().insertarRegistro(SP_INSERTAR_PAIS, parameters);
        }
        public int editarPais(DSLPais pais) 
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_NOMBRE_PAIS", pais.NombrePais));
            parameters.Add(new SqlParameter("@P_ID_PAIS", pais.IdPais));
            return conexion.insertarRegistro(SP_EDITAR_PAIS, parameters);
        }

        public bool existePais(DSLPais pais) 
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_NOMBRE_PAIS", pais.NombrePais.ToUpper()));
            return ConvertDataTableToBoolean(conexion.obtenerDatos(SP_EXISTE_PAIS, parameters));
        }

        public bool paisTieneCiudad(DSLPais pais)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_PAIS", pais.IdPais));
            return ConvertDataTableToBoolean(conexion.obtenerDatos(SP_PAIS_TIENE_CIUDAD, parameters));
        }

        public DataTable listarPaises()
        {
            return new DALConexion().obtenerDatos(SP_LISTAR_PAISES);
        }

        public DataTable busquedaPaisNombre(DSLPais pais)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_NOMBRE_PAIS", pais.NombrePais.ToUpper()));
            return conexion.obtenerDatos(SP_BUSCAR_PAIS_NOMBRE, parameters);
        }

        public int eliminarPais(DSLPais pais)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_PAIS", pais.IdPais));
            return conexion.insertarRegistro(SP_ELIMINAR_PAIS, parameters);
        }

    }
}
