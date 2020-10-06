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
    public partial class FrmPrincipal : Form
    {
        private int childFormNumber = 0;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicios frm = FrmServicios.GetInstancia();
            frm.MdiParent = this;
            frm.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta App es destinada con el fin de ayudar la gestion y planificacion del empleado y llevar una estadistica de su negocio", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clientesDemoradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCochesDemorados frm = new FrmCochesDemorados();
            frm.MdiParent = this;
            frm.Show();
        }

        private void servicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoServicio frm = new FrmTipoServicio();
            frm.MdiParent = this;
            frm.Show();
        }

        private void matriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMatricula frm = new FrmMatricula();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusquedaNombre frm = new frmBusquedaNombre();
            frm.MdiParent = this;
            frm.Show();
        }

        private void numeroDeTelefonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNumeroTelefono frm = new FrmNumeroTelefono();
            frm.MdiParent = this;
            frm.Show();
        }

        private void fechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarPorFecha frm = new FrmBuscarPorFecha();
            frm.MdiParent = this;
            frm.Show();
        }

        private void diarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGanaciaPorFecha frm = new FrmGanaciaPorFecha();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGananciaPorFecha frm = new FrmGananciaPorFecha();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trabajadorQueAtendioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajador frm = new FrmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gananciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGananciaPorFecha frm = new FrmGananciaPorFecha();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
