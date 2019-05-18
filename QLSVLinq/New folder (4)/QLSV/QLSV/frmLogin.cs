using QLSV.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text;
            string password = txtMatKhau.Text;
            if(Login(username,password))
            {
                frmAdmin ad = new frmAdmin();
                this.Hide();
                ad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                txtTenDN.Select();
            }
        }
        bool Login(string userName,string passWord)
        {
            BLAccount login = new BLAccount();
            return login.Login(userName, passWord);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtTenDN.Select();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
