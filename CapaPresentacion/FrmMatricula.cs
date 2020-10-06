using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmMatricula : Form
    {
        public FrmMatricula()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        // Metodo Mostrar

        private void Mostrar()
        {
            this.dataListado.DataSource = NServicio.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros :    " + dataListado.Rows.Count;


        }

        private void BuscarMatricula()
        {
            this.dataListado.DataSource = NServicio.BuscarMatricula(this.txtBusqueda.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros :    " + dataListado.Rows.Count;

        }

        private void FrmMatricula_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
            this.Mostrar();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            BuscarMatricula();
        }
    }
}
