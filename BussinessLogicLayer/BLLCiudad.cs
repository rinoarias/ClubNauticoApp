using DataAccessLayer;
using DataServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BussinessLogicLayer
{
    public class BLLCiudad
    {
        DALCiudad objCiudad = new DALCiudad();

        public DataTable listarCiudades()
        {
            return objCiudad.listarCiudades();
        }

        public int insertarCiudad(DSLCiudad ciudad)
        {
            if (!objCiudad.existeCiudad(ciudad))
            {
                objCiudad.insertarCiudad(ciudad);
                MessageBox.Show("La ciudad se registró correctamente");
                return 1;
            }
            else
            {
                MessageBox.Show("La ciudad ya está registrada en ese Pais", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public int editarCiudad(DSLCiudad ciudad)
        {
            if (!objCiudad.existeCiudad(ciudad))
            {
                objCiudad.editarCiudad(ciudad);
                MessageBox.Show("La ciudad se actualizó correctamente");
                return 1;
            }
            else
            {
                MessageBox.Show("La ciudad ya está registrada en dicho país", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public int eliminarCiudad(DSLCiudad ciudad)
        {
            if (objCiudad.ciudadTienePuertos(ciudad))
            {
                DialogResult resultado = MessageBox.Show("La ciudad tiene puertos registrados ¿Está seguro que desea eliminar esta ciudad ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    objCiudad.eliminarCiudad(ciudad);
                    MessageBox.Show("La ciudad se eliminó correctamente");
                    return 1;
                }
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar esta ciudad ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    objCiudad.eliminarCiudad(ciudad);
                    MessageBox.Show("La ciudad se eliminó correctamente");
                    return 1;
                }
            }
            return 0;
        }

        public DataTable buscarCiudadNombre(DSLCiudad ciudad)
        {
            return objCiudad.busquedaCiudadNombre(ciudad);
        }

    }
}
