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
    public class BLLPais
    {
        private DALPais oPais = new DALPais();

        public int insertarPais(DSLPais pais)
        {
            if(!oPais.existePais(pais))
            {
                oPais.insertarPais(pais);
                MessageBox.Show("El país se registró correctamente");
                return 1;
            }
            else
            {
                MessageBox.Show("El país ya está registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; 
            }
        }

        public DataTable listarPaises()
        {
            return oPais.listarPaises();
        }
        public DataTable buscarPaisNombre(DSLPais pais)
        {
            return oPais.busquedaPaisNombre(pais);
        }

        public int editarPais(DSLPais pais)
        {
            if (!oPais.existePais(pais))
            {
                oPais.editarPais(pais);
                MessageBox.Show("El país se actualizó correctamente");
                return 1;
            }
            else
            {
                MessageBox.Show("El país ya está registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int eliminarPais(DSLPais pais)
        {
            if (oPais.paisTieneCiudad(pais))
            {
                DialogResult resultado = MessageBox.Show("El pais tiene ciudades registradas ¿Está seguro que desea eliminar este País?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    oPais.eliminarPais(pais);
                    MessageBox.Show("El país se eliminó correctamente");
                    return 1;
                }
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Deseas eliminar este País?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    oPais.eliminarPais(pais);
                    MessageBox.Show("El país se eliminó correctamente");
                    return 1;
                }

            }
            return 0;

        }

    }
}
