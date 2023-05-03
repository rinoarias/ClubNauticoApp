using CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmHomePage : Form
    {
        public frmHomePage()
        {
            InitializeComponent();
            inicializarTableLayoutPanel();

        }

        private void inicializarTableLayoutPanel()
        {
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.ColumnCount = 3;

            // Establecer las dimensiones de las filas y columnas para que sean cuadradas
            for (int i = 0; i < 3; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            }

            this.Controls.Add(tableLayoutPanel1);

            string[] nombresBotones = { "Reporte", "Pais", "Ciudad", "Puerto", "Barco", "Persona", "Salida" };

            for (int row = 0; row < Math.Ceiling((decimal)nombresBotones.Length / tableLayoutPanel1.ColumnCount); row++)
            {
                for (int col = 0; col < tableLayoutPanel1.ColumnCount && (row * tableLayoutPanel1.ColumnCount) + col < nombresBotones.Length; col++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.AutoSize = false;
                    button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    button.Text = nombresBotones[(row * tableLayoutPanel1.ColumnCount) + col];
                    button.Name = "btn" + button.Text;
                    tableLayoutPanel1.Controls.Add(button, col, row);
                    button.Click += new EventHandler(Button_Click);
                }
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Text == "Pais")
            {
                string nombreFormulario = "frm" + button.Text;
                //Type tipoFormulario = Type.GetType(nombreFormulario);
                //Form formulario = (Form)Activator.CreateInstance(tipoFormulario);
                Form formulario = new frmPais();
                formulario.ShowDialog();
            }
            else
            {
                Form formulario = new frmCRUD();
                formulario.ShowDialog();
            }
        }

    }
}
