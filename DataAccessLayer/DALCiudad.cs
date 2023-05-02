using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLayer;

namespace DataAccessLayer
{
    public class DALCiudad
    {
        private DALConexion conexion;
        private List<SqlParameter> parameters;
        private const string SP_INSERTAR_CIUDAD = "SP_CIUDAD_INSERTAR_CIUDAD";
        private const string SP_EDITAR_CIUDAD = "SP_CIUDAD_EDITAR_CIUDAD";
        private const string SP_EXISTE_CIUDAD = "SP_CIUDAD_EXISTE_CIUDAD";
        private const string SP_CIUDAD_TIENE_PUERTO = "SP_CIUDAD_TIENE_PUERTO";
        private const string SP_LISTAR_CIUDADES = "SP_CIUDAD_LISTAR_CIUDAD";
        private const string SP_BUSCAR_CIUDAD_NOMBRE = "SP_PAIS_BUSCAR_PAIS";
        private const string SP_ELIMINAR_CIUDAD = "SP_CIUDAD_ELIMINAR_CIUDAD";

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

        public int insertarCiudad(DSLCiudad ciudad)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_PAIS", ciudad.Pais.IdPais));
            parameters.Add(new SqlParameter("@P_NOMBRE_CIUDAD", ciudad.NombreCiudad));
            return conexion.insertarRegistro(SP_INSERTAR_CIUDAD, parameters);

        }

        public int editarCiudad(DSLCiudad ciudad)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_PAIS", ciudad.Pais.IdPais));
            parameters.Add(new SqlParameter("@P_NOMBRE_CIUDAD", ciudad.NombreCiudad));
            parameters.Add(new SqlParameter("@P_ID_CIUDAD", ciudad.IdCiudad));
            return conexion.insertarRegistro(SP_EDITAR_CIUDAD, parameters);
        }

        public bool existeCiudad(DSLCiudad ciudad)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_NOMBRE_CIUDAD", ciudad.NombreCiudad.ToUpper()));
            parameters.Add(new SqlParameter("@P_ID_PAIS", ciudad.Pais.IdPais));
            return ConvertDataTableToBoolean(conexion.obtenerDatos(SP_EXISTE_CIUDAD, parameters));
        }

        public int eliminarCiudad(DSLCiudad ciudad)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_CIUDAD", ciudad.IdCiudad));
            return conexion.insertarRegistro(SP_ELIMINAR_CIUDAD, parameters);
        }

        public DataTable busquedaCiudadNombre(DSLCiudad ciudad) 
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_NOMBRE_PAIS", ciudad.NombreCiudad.ToUpper()));
            return conexion.obtenerDatos(SP_BUSCAR_CIUDAD_NOMBRE, parameters);

        }

        public bool ciudadTienePuertos(DSLCiudad ciudad)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_CIUDAD", ciudad.IdCiudad));
            return ConvertDataTableToBoolean(conexion.obtenerDatos(SP_CIUDAD_TIENE_PUERTO, parameters));
        }
        public DataTable listarCiudades()
        {
            return new DALConexion().obtenerDatos(SP_LISTAR_CIUDADES);

        }

    }
}
