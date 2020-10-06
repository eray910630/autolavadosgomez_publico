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
    public partial class FrmGanaciaPorFecha : Form
    {
        public FrmGanaciaPorFecha()
        {
            InitializeComponent();
            this.datefechaInicio.Enabled = false;
            
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

        private void Buscarpordia()
        {
            //DateTime valorfinal = datefechaInicio.Value.AddDays(1);
            DateTime fecha = DateTime.Today;
            this.dataListado.DataSource = NServicio.GananciaPorFecha(datefechaInicio.Value, datefechaInicio.Value);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros :    " + dataListado.Rows.Count;

        }

        private void GananciaDiaria()
        {

            DateTime valorfinal = datefechaInicio.Value.AddDays(1);
            DataTable datos = NServicio.GananciaPorDias(datefechaInicio.Value, datefechaInicio.Value);
            this.lblmoney.Text = datos.Rows[0][0].ToString();
        
        }

        private void FrmGanaciaPorFecha_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            
            this.GananciaDiaria();
            this.Buscarpordia();
            
          
                
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Buscarporfecha();
        //    this.lblmoney.Text = "0";
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //Buscarporfecha();
        //    GananciaDiaria();
        //}
    }
}
