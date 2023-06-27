using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanhe1.NhanVien
{
    public partial class Form_Password : Form
    {
        public Form_Password()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txt_taikhoan.Text;
            string matkhau = txt_matkhau.Text;
            Form_Luong_PC luong_PC= new Form_Luong_PC(taikhoan,matkhau);
            luong_PC.Show();
            this.Hide();
        }
    }
}
