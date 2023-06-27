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
    public partial class Form_NV_DA : Form
    {
        DataTable dtb_data_da;
        public Form_NV_DA()
        {
            InitializeComponent();
        }
        private void LoadData_nv() // tải dữ liệu vào DataGridView
        {

            string sql1 = "SELECT * FROM COMPANY.DEAN";

            dtb_data_da = Connectionfunction.GetDataToTable(sql1);
            dgv_nhanvien_info.DataSource = dtb_data_da;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_nhanvien_info.AllowUserToAddRows = false;
            dgv_nhanvien_info.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Form_NV_DA_Load(object sender, EventArgs e)
        {
            LoadData_nv();
        }
    }
}
