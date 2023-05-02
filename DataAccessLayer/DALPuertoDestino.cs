using DataServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALPuertoDestino
    {
        private DALConexion conexion;
        private List<SqlParameter> parameters;
        private const string SP_INSERTAR_PUERTO = "SP_PUERTO_INSERTAR_PUERTO";
        private const string SP_EDITAR_PUERTO = "SP_PUERTO_EDITAR_PUERTO";
        private const string SP_ELIMINAR_PUERTO = "SP_PUERTO_ELIMINAR_PUERTO";
        private const string SP_LISTAR_PUERTO = "SP_PUERTO_LISTAR_PUERTO";
        private const string SP_BUSQUEDA_CIUDAD_PUERTO = "SP_PUERTO_BUSCAR_CIUDAD_PUERTO";
        private const string SP_EXISTE_PUERTO = "SP_PUERTO_EXISTE_PUERTO";

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

        public int insertarPuertoDestino(DSLPuertoDestino puertoDestino)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_CIUDAD", puertoDestino.Ciudad.IdCiudad));
            parameters.Add(new SqlParameter("@P_NOMBRE_PUERTO", puertoDestino.NombrePuerto));
            return conexion.insertarRegistro(SP_INSERTAR_PUERTO, parameters);
        }

        public int editarPuerto(DSLPuertoDestino puertoDestino)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_CIUDAD", puertoDestino.Ciudad.IdCiudad));
            parameters.Add(new SqlParameter("@P_NOMBRE_PUERTO", puertoDestino.NombrePuerto));
            parameters.Add(new SqlParameter("@P_ID_PUERTO", puertoDestino.IdPuerto));
            return conexion.insertarRegistro(SP_EDITAR_PUERTO, parameters);
        }

        public int eliminarPuerto(DSLPuertoDestino puertoDestino)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_ID_PUERTO", puertoDestino.IdPuerto));
            return conexion.insertarRegistro(SP_ELIMINAR_PUERTO, parameters);
        }

        public DataTable listarPuertos()
        {
            return new DALConexion().obtenerDatos(SP_LISTAR_PUERTO);
        }

        public DataTable busquedaPuertoNombre(DSLPuertoDestino puertoDestino)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_NOMBRE_CIUDAD_PUERTO", puertoDestino.NombrePuerto));
            return conexion.obtenerDatos(SP_BUSQUEDA_CIUDAD_PUERTO, parameters);
        }

        public bool existePuerto(DSLPuertoDestino puertoDestino)
        {
            conexion = new DALConexion();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@P_NOMBRE_PUERTO", puertoDestino.NombrePuerto));
            parameters.Add(new SqlParameter("@P_ID_CIUDAD", puertoDestino.Ciudad.IdCiudad));
            return ConvertDataTableToBoolean(conexion.obtenerDatos(SP_EXISTE_PUERTO, parameters));
        }

    }
}
