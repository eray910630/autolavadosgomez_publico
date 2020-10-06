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
    public partial class FrmTrabajador : Form
    {
        public FrmTrabajador()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        private void Mostrar()
        {

            this.dataListado.DataSource = NServicio.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros :    " + dataListado.Rows.Count;

        }
        private void BuscarTrabajador()
        {
            int valor;
            if (int.TryParse(txtBuscar.Text,out valor))
            {
                this.dataListado.DataSource = NServicio.Trabajadorqatendioelcoche(valor);
                this.OcultarColumnas();
                lblTotal.Text = "Total de Registros :    " + dataListado.Rows.Count;
            }
            
            




        }

        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarTrabajador();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            this.Mostrar();
        }
    }
}
