using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSVLinq.BS_Layer;
namespace QLSVLinq
{
    public partial class frmQLDiem : Form
    {
        bool Add;
        string err;
        BLSV dbSV = new BLSV();
        BLQLDiem dbDiem = new BLQLDiem();
        BLKhoa dbKhoa = new BLKhoa();
        BLLop dbLop = new BLLop();
        BLMon dbMon = new BLMon();
        Double tong = 0;
        int stc = 0;
        int stcDau = 0;
        int stcRot = 0;
        public frmQLDiem()
        {
            InitializeComponent();
        }

        private void LoadComboLop(string MaKhoa)
        {
            cboSLop.DataSource = dbLop.LayKhoaInLop(MaKhoa);
            cboSLop.ValueMember = "maLop";
            cboSLop.DisplayMember = "maLop";
        }

        private void LoadComboKhoa()
        {
            cboKhoaHoc.DataSource = dbKhoa.LayKhoa();
            cboKhoaHoc.ValueMember = "maKhoa";
            cboKhoaHoc.DisplayMember = "maKhoa";
        }
        private void resettextDiem()
        {
            this.txtdiemCK.ResetText();
            this.txtdiemGK.ResetText();
            this.txtDiemTB.ResetText();
            this.lbdau.ResetText();
            this.lbrot.ResetText();
            this.lbtb.ResetText();
            this.lbstc.ResetText();
            this.cbKQ.ResetText();

        }
        void LoadData()
        {
            dgvSV.DataSource = dbSV.LaySinhVien();
            dgvSV.Columns.Remove("ngaySinh");
            dgvSV.Columns.Remove("gioiTinh");
            dgvSV.Columns.Remove("diaChi");
            dgvSV.Columns["Lop"].Visible = false;
            dgvSV.Columns["maLop"].Visible = false;
            dgvSV.AllowUserToAddRows = false;
            dgvSV.ReadOnly = true;
            rdbMaSV.Checked = true;
            LoadComboKhoa();
            LoadComboLop(cboKhoaHoc.Text);
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.ReadOnly = true;
            cbLop.DataSource = dbLop.LayLop();
            cbLop.ValueMember = "maLop";
            cbLop.DisplayMember = "maLop";
            cbMon.DataSource = dbMon.LayMon();
            cbMon.ValueMember = "maMon";
            cbMon.DisplayMember = "maMon";
            // Không cho thao tác trên các nút Lưu / Hủy 
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            //this.groupBox2.Enabled = false;
            
            // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
            this.btnAdd.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnDel.Enabled = true;
            this.btnExit.Enabled = true;
            //resettextDiem();

        }
        private void frmQLDiem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                stc = 0;
                tong = 0;
                int stcDau = 0;
                int stcRot = 0;
                int r = dgvSV.CurrentCell.RowIndex;
                this.txtMaSV.Text = dgvSV.Rows[r].Cells["maSV"].Value.ToString();
                this.txtHoTen.Text = dgvSV.Rows[r].Cells["hoTen"].Value.ToString();
                this.cbLop.Text = dgvSV.Rows[r].Cells["maLop"].Value.ToString();
                cbMon.DataSource = dbMon.LoadMonTrongMaLop(cbLop.Text);
                QLSVDataContext qlSV = new QLSVDataContext();
                var tpQuery = (from tp in qlSV.KetQuas
                               from up in qlSV.Mons
                               where tp.maSV == txtMaSV.Text
                               && up.maMon == tp.maMon
                               select new
                               {
                                   tp.maMon,
                                   up.tenMon,
                                   tp.diemGiuaKi,
                                   tp.diemCuoiKi,
                                   tp.diemTB,
                                   up.hocKi,
                                   tp.ketQ,
                                   up.soTinChi
                               }
                              );
                dgvDiem.DataSource = tpQuery.ToList();
                resettextDiem();
                foreach (DataGridViewRow row in dgvDiem.Rows)
                {
                    DataGridViewCheckBoxCell kq = row.Cells["ketQ"] as DataGridViewCheckBoxCell;
                    if ((bool)kq.Value)
                        stcDau += Convert.ToInt32(row.Cells["soTinChi"].Value.ToString());
                    else
                        stcRot += Convert.ToInt32(row.Cells["soTinChi"].Value.ToString());
                    stc += Convert.ToInt32(row.Cells["soTinChi"].Value.ToString());
                    tong += Convert.ToDouble(row.Cells["diemTB"].Value.ToString()) * Convert.ToDouble(row.Cells["soTinChi"].Value.ToString());
                }
                if (tong != 0)
                {
                    Double t = Math.Round(tong / stc, 2);
                    
                    lbstc.Text = t.ToString();
                }
                lbdau.Text = stcDau.ToString();
                lbrot.Text = stcRot.ToString();
            }
            catch { }
        }

        private void dgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
                int r = dgvDiem.CurrentCell.RowIndex;
                this.cbMon.Text = dgvDiem.Rows[r].Cells["maMon"].Value.ToString();
                this.txtdiemGK.Text = dgvDiem.Rows[r].Cells["diemGiuaKi"].Value.ToString();
                this.txtdiemCK.Text = dgvDiem.Rows[r].Cells["diemCuoiKi"].Value.ToString();
                this.txtDiemTB.Text = dgvDiem.Rows[r].Cells["diemTB"].Value.ToString();
                this.lbhk.Text = dgvDiem.Rows[r].Cells["hocKi"].Value.ToString();
                this.lbstc.Text = dgvDiem.Rows[r].Cells["soTinChi"].Value.ToString();
                this.cbKQ.Checked = (bool)dgvDiem.Rows[r].Cells["ketQ"].Value;
            
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboLop(cboKhoaHoc.Text);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            
        }
    }
}
