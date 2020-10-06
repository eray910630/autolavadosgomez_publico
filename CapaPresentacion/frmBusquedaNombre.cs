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
    public partial class frmBusquedaNombre : Form
    {
        public frmBusquedaNombre()
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

        private void Buscarnombre()
        {
            this.dataListado.DataSource = NServicio.BuscarNombresClientes(this.txtBusqueda.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros :    " + dataListado.Rows.Count;

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            Buscarnombre();
        }

        private void frmBusquedaNombre_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
            this.Mostrar();
        }
    }
}
