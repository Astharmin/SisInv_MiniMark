namespace MiniMarket.Reportes
{
    partial class Frm_Rpt_Almacenes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1_MiniMarket = new MiniMarket.Reportes.DataSet1_MiniMarket();
            this.uSPListadoalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_Listado_alTableAdapter = new MiniMarket.Reportes.DataSet1_MiniMarketTableAdapters.USP_Listado_alTableAdapter();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1_MiniMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadoalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.uSPListadoalBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MiniMarket.Reportes.Rpt_Almacenes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet1_MiniMarket
            // 
            this.dataSet1_MiniMarket.DataSetName = "DataSet1_MiniMarket";
            this.dataSet1_MiniMarket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPListadoalBindingSource
            // 
            this.uSPListadoalBindingSource.DataMember = "USP_Listado_al";
            this.uSPListadoalBindingSource.DataSource = this.dataSet1_MiniMarket;
            // 
            // uSP_Listado_alTableAdapter
            // 
            this.uSP_Listado_alTableAdapter.ClearBeforeFill = true;
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(12, 40);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(100, 20);
            this.txt_p1.TabIndex = 3;
            this.txt_p1.Visible = false;
            // 
            // Frm_Rpt_Almacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Almacenes";
            this.Text = "Frm_Rpt_Almacenes";
            this.Load += new System.EventHandler(this.Frm_Rpt_Almacenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1_MiniMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadoalBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPListadoalBindingSource;
        private DataSet1_MiniMarket dataSet1_MiniMarket;
        private DataSet1_MiniMarketTableAdapters.USP_Listado_alTableAdapter uSP_Listado_alTableAdapter;
        public System.Windows.Forms.TextBox txt_p1;
    }
}