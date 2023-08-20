using ChangePasswordForm;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Phanhe1.NhanVien
{
    public partial class Form_NV_NV : Form
    {
        DataTable tbl_nv_info;
        public Form_NV_NV()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadData_nv() // tải dữ liệu vào DataGridView
        {

            string sql1 = "SELECT MANV,TENNV,PHAI,NGAYSINH,DIACHI,SDT,VAITRO,MANQL, PHG FROM COMPANY.NHANVIEN$";

            tbl_nv_info = Connectionfunction.GetDataToTable(sql1);
            dgv_nhanvien_info.DataSource= tbl_nv_info;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_nhanvien_info.AllowUserToAddRows = false;
            dgv_nhanvien_info.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Form_NV_NV_Load(object sender, EventArgs e)
        {
            LoadData_nv();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_sdt.Text) || string.IsNullOrEmpty(txt_diachi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    

            try
            {
                string ngaysinh = dt_ngaysinh.Value.ToString("dd-MM-yyyy"); // Format the date value


                string sql6 = $"BEGIN COMPANY.UPDATE_NV(TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_sdt.Text}', '{txt_diachi.Text}'); END;";
                Connectionfunction.RunORA(sql6);
                MessageBox.Show("Cập nhật thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Cập nhật thất bại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            LoadData_nv();
        }

        private void btn_thoát_ex_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_nhanvien_info_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nếu không có dữ liệu
            if (dgv_nhanvien_info.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string selectedMANV = dgv_nhanvien_info.CurrentRow.Cells["MANV"].Value.ToString();
            txt_diachi.Text = dgv_nhanvien_info.CurrentRow.Cells["DIACHI"].Value.ToString();
            txt_sdt.Text = dgv_nhanvien_info.CurrentRow.Cells["SDT"].Value.ToString();
            string sql1 = $"SELECT TO_CHAR(NGAYSINH, 'DD-MM-YYYY') FROM COMPANY.NHANVIEN$ WHERE MANV = '{selectedMANV}'";
            string temp = Connectionfunction.GetFieldValues(sql1);
            DateTime ngaySinh = DateTime.ParseExact(temp, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            // Đặt giá trị ngày lên DateTimePicker
            dt_ngaysinh.Value = ngaySinh;
        }

        private void btn_xemluong_Click(object sender, EventArgs e)
        {
            Form_Password dangnhap = new Form_Password();
            dangnhap.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ChangePwd_Form changepwd = new ChangePwd_Form();
            changepwd.Show();
        }
    }
}
