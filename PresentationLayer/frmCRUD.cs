using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCRUD : Form
    {
        public frmCRUD()
        {
            InitializeComponent();
        }
        public virtual void estado_edicion(bool estado)
        {
            btnNuevo.Enabled = !estado;
            btnModificar.Enabled = btnEliminar.Enabled = !estado;
            btnGuardar.Enabled = btnCancelar.Enabled = estado;
        }
        public virtual void grabar()
        {
            estado_edicion(false);
        }
        public virtual void nuevo()
        {
            estado_edicion(true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            grabar();
        }
    }
}
