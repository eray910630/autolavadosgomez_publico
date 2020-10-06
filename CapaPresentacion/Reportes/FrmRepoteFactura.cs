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
    public partial class FrmRepoteFactura : Form
    {
        private int _Idservicio;

        public int Idservicio
        {
            get { return _Idservicio; }
            set { _Idservicio = value; }
        }
        public FrmRepoteFactura()
        {
            InitializeComponent();
        }

        private void FrmRepoteFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsPrincipal.reporte_factura' Puede moverla o quitarla según sea necesario.

            try
            {
                this.reporte_facturaTableAdapter.Fill(this.DsPrincipal.reporte_factura, Idservicio);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
                
            }
            
        }
    }
}
