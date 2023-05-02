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
    public class dalPais
    {
        private dalConexion conexion;
        private List<SqlParameter> parameters;
        private const string SP_INSERTAR_PAIS = "spInsertarPais";
        private const string SP_EDITAR_PAIS = "spEditarPais";
        private const string SP_EXISTE_PAIS = "spExistePais";
        private const string SP_PAIS_TIENE_CIUDAD = "spPaisTieneCiudad";
        private const string SP_LISTAR_PAISES = "spListarPais";
        private const string SP_BUSCAR_PAIS_NOMBRE = "spBusquedaPaisNombre";
        private const string SP_ELIMINAR_PAIS = "spEliminarPaisCiuades";

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

        public int insertarPais(dslPais pais)
        {
            conexion = new dalConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@NOMBRE_PAIS", pais.NombrePais));
            return conexion.insertarRegistro(SP_INSERTAR_PAIS, parameters);
            // return new DALConexion().insertarRegistro(SP_INSERTAR_PAIS, parameters);
        }
        public int editarPais(dslPais pais) 
        {
            conexion = new dalConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nomPais", pais.NombrePais));
            parameters.Add(new SqlParameter("@idpais", pais.IdPais));
            return conexion.insertarRegistro(SP_EDITAR_PAIS, parameters);
        }

        public bool existePais(dslPais pais) 
        {
            conexion = new dalConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@NOMPAIS", pais.NombrePais.ToUpper()));
            return ConvertDataTableToBoolean(conexion.obtenerDatos(SP_EXISTE_PAIS, parameters));
        }

        public bool paisTieneCiudad(dslPais pais)
        {
            conexion = new dalConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@idpais", pais.IdPais));
            return ConvertDataTableToBoolean(conexion.obtenerDatos(SP_PAIS_TIENE_CIUDAD, parameters));
        }

        public DataTable listarPaises()
        {
            return new dalConexion().obtenerDatos(SP_LISTAR_PAISES);
        }

        public DataTable busquedaPaisNombre(dslPais pais)
        {
            conexion = new dalConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nomPais", pais.NombrePais.ToUpper()));
            return conexion.obtenerDatos(SP_BUSCAR_PAIS_NOMBRE, parameters);
        }

        public int eliminarPais(dslPais pais)
        {
            conexion = new dalConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@idpais", pais.IdPais));
            return conexion.insertarRegistro(SP_ELIMINAR_PAIS, parameters);
        }

    }
}
