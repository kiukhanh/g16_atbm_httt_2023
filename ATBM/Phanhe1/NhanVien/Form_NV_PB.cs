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
    public partial class Form_NV_PB : Form
    {
        DataTable dtb_data_pb;
        public Form_NV_PB()
        {
            InitializeComponent();
        }
        private void LoadData_pb() // tải dữ liệu vào DataGridView
        {

            string sql1 = "SELECT * FROM COMPANY.PHONGBAN";

            dtb_data_pb = Connectionfunction.GetDataToTable(sql1);
            dgv_nhanvien_info.DataSource = dtb_data_pb;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_nhanvien_info.AllowUserToAddRows = false;
            dgv_nhanvien_info.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void Form_NV_PB_Load(object sender, EventArgs e)
        {
            LoadData_pb();
        }
    }
}
