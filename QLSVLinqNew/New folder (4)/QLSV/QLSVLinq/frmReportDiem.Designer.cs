namespace QLSVLinq
{
    partial class frmReportDiem
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DuLieu = new QLSVLinq.DuLieu();
            this.ReportDiemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDiemTableAdapter = new QLSVLinq.DuLieuTableAdapters.ReportDiemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDiemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportDiemBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLSVLinq.ReportDiem.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-3, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(802, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DuLieu
            // 
            this.DuLieu.DataSetName = "DuLieu";
            this.DuLieu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportDiemBindingSource
            // 
            this.ReportDiemBindingSource.DataMember = "ReportDiem";
            this.ReportDiemBindingSource.DataSource = this.DuLieu;
            // 
            // ReportDiemTableAdapter
            // 
            this.ReportDiemTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportDiem";
            this.Text = "frmReportDiem";
            this.Load += new System.EventHandler(this.frmReportDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDiemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReportDiemBindingSource;
        private DuLieu DuLieu;
        private DuLieuTableAdapters.ReportDiemTableAdapter ReportDiemTableAdapter;
    }
}