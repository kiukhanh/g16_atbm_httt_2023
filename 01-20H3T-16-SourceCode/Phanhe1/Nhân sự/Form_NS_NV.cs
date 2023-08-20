using Phanhe1.NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Phanhe1.Nhân_sự
{
    public partial class Form_NS_NV : Form
    {
        DataTable dtb_nv;
        private string selectedMANV;
        public Form_NS_NV()
        {
            InitializeComponent();
        }

        private void LoadData_nv() // tải dữ liệu vào DataGridView
        {

            string sql1 = "SELECT * FROM COMPANY.NHANSU_INSERT_VIEW ORDER BY MANV";

            dtb_nv = Connectionfunction.GetDataToTable(sql1);
            dgv_ds_nv.DataSource = dtb_nv;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_ds_nv.AllowUserToAddRows = false;
            dgv_ds_nv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_nv_form_Click(object sender, EventArgs e)
        {
            Form_NV_NV nhanvien = new Form_NV_NV();
            nhanvien.Show(); // Sử dụng phương thức Show để hiển thị Form
        }

        private void Form_NS_NV_Load(object sender, EventArgs e)
        {
            LoadData_nv();
        }



        private void btn_them_Click(object sender, EventArgs e)
        {
            int count = 0;
            string sql1 = "SELECT COUNT(*) FROM COMPANY.NHANSU_INSERT_VIEW";
            string temp = Connectionfunction.GetFieldValues(sql1);
            count = Int32.Parse(temp);
            string manv;
            if (count < 10)
            {
                manv = "NV00" + count;
            }
            else if (count < 100)
            {
                manv = "NV0" + count;
            }
            else
            {
                manv = "NV" + count;
            }

            if (string.IsNullOrEmpty(txt_tennv.Text) ||
            string.IsNullOrEmpty(txt_gioitinh.Text) || string.IsNullOrEmpty(txt_sdt_nv.Text) ||
            string.IsNullOrEmpty(txt_vaitro.Text) || string.IsNullOrEmpty(txt_diachi_nv.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string ngaysinh = dt_ns_nv.Value.ToString("dd-MM-yyyy");
                string manql = string.IsNullOrEmpty(txt_manql.Text) ? "NULL" : $"'{txt_manql.Text}'";
                string phong = string.IsNullOrEmpty(txt_phong.Text) ? "NULL" : $"'{txt_phong.Text}'";
                string sql6;
                string gioitinh = string.IsNullOrEmpty(txt_gioitinh.Text) ? "NULL" : txt_gioitinh.Text;
                if (manql != "NULL" && phong != "NULL")
                {
                    sql6 = $"BEGIN COMPANY.INSERT_NV('{manv}','{txt_tennv.Text}',{gioitinh},TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_diachi_nv.Text}', '{txt_sdt_nv.Text}','{txt_vaitro.Text}',{manql},{phong}); END;";
                }
                else if (manql == "NULL" && phong == "NULL")
                {
                    sql6 = $"BEGIN COMPANY.INSERT_NV('{manv}','{txt_tennv.Text}',{gioitinh},TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_diachi_nv.Text}', '{txt_sdt_nv.Text}','{txt_vaitro.Text}',NULL,NULL); END;";
                }
                else if (manql == "NULL" && phong != "NULL")
                {
                    sql6 = $"BEGIN COMPANY.INSERT_NV('{manv}','{txt_tennv.Text}',{gioitinh},TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_diachi_nv.Text}', '{txt_sdt_nv.Text}','{txt_vaitro.Text}',NULL,{phong}); END;";
                }
                else
                {
                    sql6 = $"BEGIN COMPANY.INSERT_NV('{manv}','{txt_tennv.Text}',{gioitinh},TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_diachi_nv.Text}', '{txt_sdt_nv.Text}','{txt_vaitro.Text}',{manql},NULL); END;";
                }
                Connectionfunction.RunORA(sql6);
                MessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Thêm thất bại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void dgv_ds_nv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //Nếu không có dữ liệu
            if (dgv_ds_nv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            selectedMANV = dgv_ds_nv.CurrentRow.Cells["MANV"].Value.ToString();

            // set giá trị cho các mục    
            txt_tennv.Text = dgv_ds_nv.CurrentRow.Cells["TENNV"].Value.ToString();
            txt_gioitinh.Text = dgv_ds_nv.CurrentRow.Cells["PHAI"].Value.ToString();
            txt_diachi_nv.Text = dgv_ds_nv.CurrentRow.Cells["DIACHI"].Value.ToString();
            txt_sdt_nv.Text = dgv_ds_nv.CurrentRow.Cells["SDT"].Value.ToString();
            txt_vaitro.Text = dgv_ds_nv.CurrentRow.Cells["VAITRO"].Value.ToString();
            txt_manql.Text = dgv_ds_nv.CurrentRow.Cells["MANQL"].Value.ToString();
            txt_phong.Text = dgv_ds_nv.CurrentRow.Cells["PHG"].Value.ToString();

            string sql1 = $"SELECT TO_CHAR(NGAYSINH, 'DD-MM-YYYY') FROM COMPANY.NHANSU_INSERT_VIEW WHERE MANV = '{selectedMANV}'";
            string temp = Connectionfunction.GetFieldValues(sql1);
            DateTime ngaySinh = DateTime.ParseExact(temp, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            // Đặt giá trị ngày lên DateTimePicker
            dt_ns_nv.Value = ngaySinh;
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tennv.Text) ||
            string.IsNullOrEmpty(txt_gioitinh.Text) || string.IsNullOrEmpty(txt_sdt_nv.Text) ||
            string.IsNullOrEmpty(txt_vaitro.Text) || string.IsNullOrEmpty(txt_diachi_nv.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string ngaysinh = dt_ns_nv.Value.ToString("dd-MM-yyyy");
                string manql = string.IsNullOrEmpty(txt_manql.Text) ? "NULL" : $"'{txt_manql.Text}'";
                string phong = string.IsNullOrEmpty(txt_phong.Text) ? "NULL" : $"'{txt_phong.Text}'";
                string sql6;
                string gioitinh = string.IsNullOrEmpty(txt_gioitinh.Text) ? "NULL" : txt_gioitinh.Text;
                if (manql != "NULL" && phong != "NULL")
                {
                    sql6 = $"BEGIN COMPANY.UPDATE_NV_NS('{selectedMANV}','{txt_tennv.Text}',{gioitinh},TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_diachi_nv.Text}', '{txt_sdt_nv.Text}','{txt_vaitro.Text}',{manql},{phong}); END;";

                }
                else if(manql == "NULL" && phong == "NULL")
                {
                    sql6 = $"BEGIN COMPANY.UPDATE_NV_NS('{selectedMANV}','{txt_tennv.Text}',{gioitinh},TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_diachi_nv.Text}', '{txt_sdt_nv.Text}','{txt_vaitro.Text}',NULL,NULL); END;";
                }
                else if (manql== "NULL" && phong != "NULL")
                {
                    sql6 = $"BEGIN COMPANY.UPDATE_NV_NS('{selectedMANV}','{txt_tennv.Text}',{gioitinh},TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_diachi_nv.Text}', '{txt_sdt_nv.Text}','{txt_vaitro.Text}',NULL,{phong}); END;";
                }
                else 
                {
                    sql6 = $"BEGIN COMPANY.UPDATE_NV_NS('{selectedMANV}','{txt_tennv.Text}',{gioitinh},TO_DATE('{ngaysinh}', 'DD-MM-YYYY'), '{txt_diachi_nv.Text}', '{txt_sdt_nv.Text}','{txt_vaitro.Text}',{manql},NULL); END;";
                }
                    
                Connectionfunction.RunORA(sql6);
                MessageBox.Show("Cập nhật thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch 
            {
                MessageBox.Show("Cập nhật thất bại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadData_nv();
        }
    }
}
