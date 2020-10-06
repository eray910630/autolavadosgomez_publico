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
    public partial class FrmCochesDemorados : Form
    {
        public FrmCochesDemorados()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[1].Visible = false;

        }

        // Metodo Mostrar

        private void CochesDemorados()
        {
            int cant_dias = int.Parse(numericCantidadDias.Value.ToString());
            this.dataListado.DataSource = NServicio.CochesDemorados(cant_dias);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros :    " + dataListado.Rows.Count;


        }

        private void FrmCochesDemorados_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            CochesDemorados();
        }

        private void numericCantidadDias_ValueChanged(object sender, EventArgs e)
        {
            CochesDemorados();
        }
    }
}
