using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Phanhe1;
using Phanhe1.NhanVien;
using Phanhe2;

namespace Phanhe2
{
    public partial class Form_QL : Form
    {
        public Form_QL()
        {
            InitializeComponent();
            main_quanli.Hide();
            guna2DataGridView_QL.Hide();
            main_quanli.Show();
            string query = "SELECT SYS_CONTEXT('USERENV','SESSION_USER') FROM DUAL";
            object value = Connectionfunction.GetDataToText(query);
            textBox_ID.Text = "ID: " + value.ToString();
        }
        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            main_quanli.Controls.Add(childForm);
            main_quanli.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void guna2Button_CaNhan_Click(object sender, EventArgs e)
        {
            guna2DataGridView_QL.Hide();
            main_quanli.Show();
            openChildForm(new Form_NV_NV());
        }

        public string GetHoTen()
        {
            string query = "SELECT TENNV FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            return value.ToString();
        }
        public string GetPhai()
        {
            string query = "SELECT PHAI FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            if (Convert.ToInt32(value) == 0)
                return "Nam";
            return "Nữ";
        }
        public string GetNgSinh()
        {
            string query = "SELECT NGAYSINH FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            return value.ToString();
        }
        public string GetDiachi()
        {
            string query = "SELECT DIACHI FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            return value.ToString();
        }
        public string GetSDT()
        {
            string query = "SELECT SDT FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            return value.ToString();
        }
        public string GetLuong()
        {
            string query = "SELECT LUONG FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            return value.ToString();
        }
        public string GetPhucap()
        {
            string query = "SELECT PHUCAP FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            return value.ToString();
        }
        public string GetNQL()
        {
            string query = "SELECT MANQL FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return "Không có";
            return value.ToString();
        }
        public string GetPHG()
        {
            string query = "SELECT PHG FROM COMPANY.NHANVIEN$";
            object value = Connectionfunction.GetDataToText(query);
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return "Không có";
            return value.ToString();
        }

       
        DataTable dtTableName = new DataTable();
        private void guna2Button_CongViec_Click(object sender, EventArgs e)
        {
            guna2DataGridView_QL.Hide();
            main_quanli.Show();
            openChildForm(new Form_NV_PC());
        }

        private void guna2Button_NhanVien_Click(object sender, EventArgs e)
        {
            main_quanli.Hide();
            guna2DataGridView_QL.Show();
            string query = "SELECT * FROM COMPANY.NHANVIEN_HIDE";
            dtTableName = Connectionfunction.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2Button_PhongBan_Click(object sender, EventArgs e)
        {
            main_quanli.Hide();
            guna2DataGridView_QL.Show();
            string query = "SELECT * FROM COMPANY.PHONGBAN";
            dtTableName = Connectionfunction.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2Button_DeAn_Click(object sender, EventArgs e)
        {
            guna2DataGridView_QL.Show();
            main_quanli.Hide();
            string query = "SELECT * FROM COMPANY.DEAN";
            dtTableName = Connectionfunction.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2Button_PhanCong_Click(object sender, EventArgs e)
        {
            main_quanli.Hide();
            guna2DataGridView_QL.Show();
            string query = "SELECT * FROM COMPANY.PHANCONG_QL";
            dtTableName = Connectionfunction.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Form_QL_Load(object sender, EventArgs e)
        {
           guna2Button_CaNhan.PerformClick();
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }
    }
}


