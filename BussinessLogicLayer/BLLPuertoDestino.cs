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
    public class BLLPuertoDestino
    {
        DALPuertoDestino objPuerto = new DALPuertoDestino();

        public DataTable listarPuertos()
        {
            return objPuerto.listarPuertos();
        }

        public int insertarPuerto(DSLPuertoDestino puerto)
        {
            if (!objPuerto.existePuerto(puerto))
            {
                objPuerto.insertarPuertoDestino(puerto);
                MessageBox.Show("El puerto se registró correctamente");
                return 1;
            }
            else
            {
                MessageBox.Show("El puerto ya esta registrado en dicha ciudad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }
        }

        public int editarPuerto(DSLPuertoDestino puerto)
        {
            if (!objPuerto.existePuerto(puerto))
            {
                objPuerto.editarPuerto(puerto);
                MessageBox.Show("el puerto se actualizó correctamente");
                return 1;
            }
            else
            {
                MessageBox.Show("Ya hay un puerto registardo en dicha ciudad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int eliminarPuerto(DSLPuertoDestino puerto)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar este puerto ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes)
            {
                objPuerto.eliminarPuerto(puerto);
                MessageBox.Show("El puerto se eliminó correctamente");
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public DataTable buscarPuertoNombre(DSLPuertoDestino puerto)
        {
            return objPuerto.busquedaPuertoNombre(puerto);
        }
    }
}
