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
    public partial class FrmTipoLavados : Form
    {
        
        
        public FrmTipoLavados()
        {
            InitializeComponent();
           
           
        }

        private void FrmTipoLavados_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FrmServicios aux = FrmServicios.GetInstancia();
            string extra = this.txtDescripcion.Text.ToUpper();
            aux.GuardarTipoExtra(extra);
            this.Close();
        }
    }
}
