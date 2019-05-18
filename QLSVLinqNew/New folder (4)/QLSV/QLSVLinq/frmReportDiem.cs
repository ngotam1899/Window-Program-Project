using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVLinq
{
    public partial class frmReportDiem : Form
    {
        private string maSV;
        public frmReportDiem()
        {
            InitializeComponent();
        }
        public frmReportDiem(string masv) : this()
        {
            this.maSV = masv;
        }
        private void frmReportDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DuLieu.ReportDiem' table. You can move, or remove it, as needed.
            this.ReportDiemTableAdapter.Fill(this.DuLieu.ReportDiem, maSV);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
