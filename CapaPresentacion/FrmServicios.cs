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
    public partial class FrmServicios : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static FrmServicios _Instancia;
        string aux = "";

        public FrmServicios()
        {
            InitializeComponent();
            
            this.ttMensaje.SetToolTip(this.datefecha, "Ingrese la fecha del Servicio");
            this.ttMensaje.SetToolTip(this.cbmNombreclientes, "Ingrese el nombre del cliente");
            this.ttMensaje.SetToolTip(this.txtTelefonocliente, "Ingrese el cell del cliente");

            this.ttMensaje.SetToolTip(this.txtTipoCoches, "Ingrese el  tipo del coche");
            this.ttMensaje.SetToolTip(this.txtmatricula, "Ingrese la matricula del coche");
            this.ttMensaje.SetToolTip(this.cmbTipoLavados, "Ingrese el tipo del coche");
            this.ttMensaje.SetToolTip(this.txtPrecio, "Ingrese el precio del lavado");
            this.ttMensaje.SetToolTip(this.txtAtendidopor, "Entre un numero entre 1 y 3");


            this.txtidservicios.Visible = false;



            this.cbmNombreclientes.Enabled = true;
            this.txtTelefonocliente.ReadOnly = true;

            this.txtTipoCoches.ReadOnly = true;
            this.txtmatricula.ReadOnly = true;
            this.txtPrecio.ReadOnly = true;
            this.datefecha.Enabled = false;
            this.txtAtendidopor.ReadOnly = true;
            this.btnTipoLavados.Enabled = false;
        }

        public static FrmServicios GetInstancia()
        {
            if (_Instancia==null)
            {
                _Instancia = new FrmServicios();
                //_Instancia.cmbTipoLavados.Text = "BASICO EXTRA";
            }
            return _Instancia;
        }
        public void GuardarTipoExtra(string extra)
        {

            aux = extra;
            this.cmbTipoLavados.Text = this.cmbTipoLavados.Text + " + "+ aux;
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Autolavados Gomez", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Autolavados Gomez", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        // Limpiar todos controles del formulario

        private void Limpiar()
        {
            this.txtidservicios.Text = string.Empty;
            this.cbmNombreclientes.Text = string.Empty;
            this.txtTelefonocliente.Text = string.Empty;

            this.txtTipoCoches.Text = string.Empty;
            this.txtmatricula.Text = string.Empty;
            this.cmbTipoLavados.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtAtendidopor.Text = string.Empty;
        }


        private void Habilitar(bool valor)
        {
            this.cbmNombreclientes.Enabled = valor;
            this.txtTelefonocliente.ReadOnly = !valor;


            this.txtTipoCoches.ReadOnly = !valor;
            this.txtmatricula.ReadOnly = !valor;
            this.cmbTipoLavados.Enabled = valor;
            this.txtPrecio.ReadOnly = !valor;
            this.txtAtendidopor.ReadOnly = !valor;

            
            this.datefecha.Enabled = valor;


        }


        // habilitar botones

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        // Metodo oculat columnas

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

            this.dataListado.DataSource = NServicio.BuscarMatricula(txtBuscarMatricula.Text.ToUpper());
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:    " + dataListado.Rows.Count;


        }


        private void FrmServicios_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void txtBuscarMatricula_TextChanged(object sender, EventArgs e)
        {
            BuscarMatricula();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtTelefonocliente.Focus();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.datefecha.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(datefecha, "Ingrese la fecha");

                }

                if (this.cbmNombreclientes.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(cbmNombreclientes, "Ingrese el nombre del cliente");
                }
                if (this.txtTelefonocliente.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtTelefonocliente, "Ingrese el cell del cliente");
                }
                if (this.txtTipoCoches.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtTipoCoches, "Ingrese el tipo de coche ");
                }
                if (this.txtmatricula.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtTipoCoches, "Ingrese la matricula del coche ");
                }
                if (this.cmbTipoLavados.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(cmbTipoLavados, "Ingrese el tipo de lavado ");
                }
                if (this.txtPrecio.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtPrecio, "Ingrese el precio ");
                }
                if (this.txtAtendidopor.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(cmbTipoLavados, "Ingrese que trabajador lo atendera ");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //if (cmbTipoLavados.Text.ToUpper().Equals("BASICO EXTRA"))
                        //{
                        //    btnTipoLavados.Enabled = true;
                        //    rpta = NServicio.Insertar(this.txtNombreCliente.Text.Trim().ToUpper(), this.txtTelefonocliente.Text.Trim(), this.txtTipoCoches.Text.Trim().ToUpper(), this.txtmatricula.Text.Trim().ToUpper(), cmbTipoLavados.Text.Trim().ToUpper() + aux.Trim().ToUpper(), decimal.Parse(this.txtPrecio.Text), int.Parse(this.txtAtendidopor.Text), this.datefecha.Value);
                        //}
                        DataTable datos = NServicio.CantidadLavados(this.txtmatricula.Text);
                        if (datos.Rows.Count== 0)
                        {
                            rpta = NServicio.Insertar(this.cbmNombreclientes.Text.Trim().ToUpper(), this.txtTelefonocliente.Text.Trim(), this.txtTipoCoches.Text.Trim().ToUpper(), this.txtmatricula.Text.Trim().ToUpper(), cmbTipoLavados.Text.Trim().ToUpper(), decimal.Parse(this.txtPrecio.Text), int.Parse(this.txtAtendidopor.Text), this.datefecha.Value);
                        }
                        else
                        {
                            int lavados = int.Parse(datos.Rows[0][1].ToString());
                            if (lavados % 10 == 0)
                            {

                                DialogResult resultado = MessageBox.Show("Este cliente, ya le has lavado su coche 10 veces, te lo dejo en tus manos lo que quieras hacer", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (resultado == System.Windows.Forms.DialogResult.OK)
                                {
                                    rpta = NServicio.Insertar(this.cbmNombreclientes.Text.Trim().ToUpper(), this.txtTelefonocliente.Text.Trim(), this.txtTipoCoches.Text.Trim().ToUpper(), this.txtmatricula.Text.Trim().ToUpper(), cmbTipoLavados.Text.Trim().ToUpper(), decimal.Parse(this.txtPrecio.Text), int.Parse(this.txtAtendidopor.Text), this.datefecha.Value);
                                }
                            }
                            else if (lavados % 10 != 0)
                            {
                                rpta = NServicio.Insertar(this.cbmNombreclientes.Text.Trim().ToUpper(), this.txtTelefonocliente.Text.Trim(), this.txtTipoCoches.Text.Trim().ToUpper(), this.txtmatricula.Text.Trim().ToUpper(), cmbTipoLavados.Text.Trim().ToUpper(), decimal.Parse(this.txtPrecio.Text), int.Parse(this.txtAtendidopor.Text), this.datefecha.Value);
                            }
                        }
                        
                        
                       
                            
                        //rpta = NServicio.Insertar(dateFecha.Value, int.Parse(this.txtidclientecontransporte.Text), int.Parse(this.txtidtrabajador.Text.Trim()), int.Parse(this.txtiddetalleservicio.Text.Trim()));
                    }
                    else
                    {
                        rpta = NServicio.Editar(int.Parse(this.txtidservicios.Text), this.cbmNombreclientes.Text.Trim().ToUpper(), this.txtTelefonocliente.Text.Trim(), this.txtTipoCoches.Text.Trim().ToUpper(), this.txtmatricula.Text.Trim().ToUpper(), cmbTipoLavados.Text.Trim().ToUpper(), decimal.Parse(this.txtPrecio.Text), int.Parse(this.txtAtendidopor.Text), this.datefecha.Value);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.btnTipoLavados.Enabled = false;
                    this.txtidservicios.Visible = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnTipoLavados_Click(object sender, EventArgs e)
        {
            FrmTipoLavados frm = new FrmTipoLavados();
            frm.ShowDialog();
        }

        private void cmbTipoLavados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoLavados.Text.ToUpper().Equals("BASICO EXTRA"))
            {
                btnTipoLavados.Enabled = true;
            }
            else
            {
                btnTipoLavados.Enabled = false;
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidservicios.Text.Equals(""))
            {
                this.txtidservicios.Visible = true;
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro ha modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            btnTipoLavados.Enabled = false;
            this.txtidservicios.Visible = false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtidservicios.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idservicios"].Value);
            this.datefecha.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbmNombreclientes.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre_cliente"].Value);
            this.txtTelefonocliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono_cliente"].Value);

            this.txtTipoCoches.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_coche"].Value);
            this.txtmatricula.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["matricula"].Value);
            this.cmbTipoLavados.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_lavados"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio"].Value);
            this.txtAtendidopor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["atendido_por"].Value);
           



            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;

            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente Deseas Eliminar los Registros", "Autolavados Gomez", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NServicio.Eliminar(int.Parse(codigo));
                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTelefonocliente_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTelefonocliente.Text!=string.Empty)
            {
                DataTable datos = NServicio.buscarTelefonoCliente(this.txtTelefonocliente.Text);
                this.cbmNombreclientes.Items.Clear();
                if (datos.Rows.Count != 0)
                {
                    string nombre = datos.Rows[0][1].ToString();
                   
                    foreach (DataRow item in datos.Rows)
                    {
                        nombre = item.ItemArray[1].ToString();
                        if (!this.cbmNombreclientes.Items.Contains(nombre))
                        {
                            this.cbmNombreclientes.Items.Add(nombre);
                        }
                        
                    }
                    //this.cbmNombreclientes.Text = nombre;
                    nombre = "";
                }
                else
                    this.cbmNombreclientes.Items.Clear();
            }
            else
            {
                this.cbmNombreclientes.Items.Clear();
            }
           

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmRepoteFactura frm = new FrmRepoteFactura();
            frm.Idservicio = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idservicios"].Value);
            frm.ShowDialog();
        }
    }
}
