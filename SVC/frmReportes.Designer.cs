namespace SVC
{
    partial class frmReportes
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
            this.Quejas_sugerenciasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.quejassugerenciasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sVCDsss = new SVC.SVCDsss();
            this.quejassugerenciasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quejas_sugerenciasTableAdapter1 = new SVC.SVCDsssTableAdapters.quejas_sugerenciasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Quejas_sugerenciasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quejassugerenciasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVCDsss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quejassugerenciasBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // Quejas_sugerenciasBindingSource
            // 
            this.Quejas_sugerenciasBindingSource.DataMember = "Quejas_sugerencias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(374, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Reportes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 44;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Quejas_sugerenciasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SVC.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 61);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(845, 417);
            this.reportViewer1.TabIndex = 45;
            // 
            // quejassugerenciasBindingSource
            // 
            this.quejassugerenciasBindingSource.DataMember = "quejas_sugerencias";
            // 
            // sVCDsss
            // 
            this.sVCDsss.DataSetName = "SVCDsss";
            this.sVCDsss.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quejassugerenciasBindingSource1
            // 
            this.quejassugerenciasBindingSource1.DataMember = "quejas_sugerencias";
            this.quejassugerenciasBindingSource1.DataSource = this.sVCDsss;
            // 
            // quejas_sugerenciasTableAdapter1
            // 
            this.quejas_sugerenciasTableAdapter1.ClearBeforeFill = true;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(869, 490);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Quejas_sugerenciasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quejassugerenciasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVCDsss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quejassugerenciasBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
       
        private System.Windows.Forms.BindingSource quejassugerenciasBindingSource;
        
private System.Windows.Forms.BindingSource Quejas_sugerenciasBindingSource;
        private SVCDsss sVCDsss;
        private System.Windows.Forms.BindingSource quejassugerenciasBindingSource1;
        private SVCDsssTableAdapters.quejas_sugerenciasTableAdapter quejas_sugerenciasTableAdapter1;
    }
}