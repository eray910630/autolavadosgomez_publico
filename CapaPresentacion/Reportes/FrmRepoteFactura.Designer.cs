namespace CapaPresentacion
{
    partial class FrmRepoteFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepoteFactura));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsPrincipal = new CapaPresentacion.DsPrincipal();
            this.reporte_facturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_facturaTableAdapter = new CapaPresentacion.DsPrincipalTableAdapters.reporte_facturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporte_facturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporte_facturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptfacturas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(882, 512);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsPrincipal
            // 
            this.DsPrincipal.DataSetName = "DsPrincipal";
            this.DsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporte_facturaBindingSource
            // 
            this.reporte_facturaBindingSource.DataMember = "reporte_factura";
            this.reporte_facturaBindingSource.DataSource = this.DsPrincipal;
            // 
            // reporte_facturaTableAdapter
            // 
            this.reporte_facturaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRepoteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 512);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRepoteFactura";
            this.Text = "                                                                                 " +
    "                                    .:. Facturas .:.";
            this.Load += new System.EventHandler(this.FrmRepoteFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporte_facturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporte_facturaBindingSource;
        private DsPrincipal DsPrincipal;
        private DsPrincipalTableAdapters.reporte_facturaTableAdapter reporte_facturaTableAdapter;
    }
}