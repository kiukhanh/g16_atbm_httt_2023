using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanhe1.Nhân_sự
{
    public partial class Form_NS_PB : Form
    {
        DataTable dtb_pb;
        DataTable dtb_trgph;
        DataTable dtb_trgph1;
        string selectedpb;
        string mapb;
        public Form_NS_PB()
        {
            InitializeComponent();
        }
        private void LoadData_pb() // tải dữ liệu vào DataGridView
        {

            string sql1 = "SELECT * FROM COMPANY.PHONGBAN ORDER BY MAPB";

            dtb_pb = Connectionfunction.GetDataToTable(sql1);
            dgv_pb_info.DataSource = dtb_pb;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_pb_info.AllowUserToAddRows = false;
            dgv_pb_info.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Form_NS_PB_Load(object sender, EventArgs e)
        {
            LoadData_pb();
            int count = 0;
            string sql1 = "SELECT COUNT(*) FROM COMPANY.PHONGBAN";
            string temp = Connectionfunction.GetFieldValues(sql1);
            count = Int32.Parse(temp) + 1;
            mapb = " ";
            if (count < 10)
            {
                mapb = "PB0" + count;
            }
            else if (count < 100)
            {
                mapb = "PB" + count;
            }
            txt_maphongban.Text = mapb;
            


        }

        private void btn_them_pb_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(txt_tenpb.Text)/* ||
            string.IsNullOrEmpty(combobox_trgphg.Text)*/)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          
            try
            {
                string sql6 = $"BEGIN COMPANY.INSERT_PB('{mapb}','{txt_tenpb.Text}',NULL); END;";
                Connectionfunction.RunORA(sql6);
                MessageBox.Show("Cập nhật thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(txt_phongban_update.Text) /*||
            string.IsNullOrEmpty(comboboc_trg_capnhat.Text)*/)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            try
            {
                string sql6 = $"BEGIN COMPANY.UPDATE_PB_NS('{selectedpb}','{txt_phongban_update.Text}','{txt_truongphong.Text}'); END;";
                Connectionfunction.RunORA(sql6);
                MessageBox.Show("Cập nhật thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_pb_info_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nếu không có dữ liệu
            if (dgv_pb_info.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            selectedpb = dgv_pb_info.CurrentRow.Cells["MAPB"].Value.ToString();

            // set giá trị cho các mục    
            txt_phongban_update.Text = dgv_pb_info.CurrentRow.Cells["TENPB"].Value.ToString();
            string sql2 = $"SELECT MANV FROM COMPANY.NHANSU_INSERT_VIEW WHERE VAITRO = 'TP'AND PHG = '{selectedpb}'";
            object result = Connectionfunction.GetDataToText(sql2);
            string resultText = result != null ? result.ToString() : string.Empty;
            txt_truongphong.Text = resultText;
            /*string selectedValue = dgv_pb_info.CurrentRow.Cells["TRPHG"].Value.ToString();
            comboboc_trg_capnhat.SelectedItem = selectedValue;*/

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadData_pb();
        }
    }

}
