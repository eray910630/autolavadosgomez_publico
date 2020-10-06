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
    public partial class FrmGananciaPorFecha : Form
    {
        public FrmGananciaPorFecha()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        // Metodo Mostrar

        

        private void Buscarporfecha()
        {
            
            this.dataListado.DataSource = NServicio.BuscarFechas(datefechaInicio.Value, datefechafinal.Value);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros :    " + dataListado.Rows.Count;

        }

        private void GananciaDiaria()
        {

            
            DataTable datos = NServicio.GananciaPorFecha(datefechaInicio.Value, datefechafinal.Value);
            this.lblmoney.Text = datos.Rows[0][0].ToString();

        }

        private void FrmGananciaPorFecha_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            GananciaDiaria();
            Buscarporfecha();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscarporfecha();
            GananciaDiaria();
        }
    }
}
