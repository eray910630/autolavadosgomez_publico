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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable datos = Ntrabajador.Login(this.txtusuario.Text, this.txtPassword.Text);
            if (datos.Rows.Count == 0)
            {
                MessageBox.Show("No tiene Acceso al Sistema", "Autolavados Gomez", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmPrincipal form = new FrmPrincipal();
                //form.Idtrabajador = datos.Rows[0][0].ToString();
                //form.Nombre = datos.Rows[0][1].ToString();
                //form.Acceso = datos.Rows[0][2].ToString();
                form.Show();
                this.Hide();

            }
        }
    }
}
