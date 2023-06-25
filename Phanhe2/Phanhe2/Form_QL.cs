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
using Phanhe2;

namespace Phanhe2
{
    public partial class Form_QL : Form
    {
        public Form_QL()
        {
            InitializeComponent();
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Hide();
            guna2Button_Sua.Show();
            string query = "SELECT SYS_CONTEXT('USERENV','SESSION_USER') FROM DUAL";
            object value = Connection.GetDataToText(query);
            textBox_ID.Text = "ID: " + value.ToString();
        }

        private void guna2Button_CaNhan_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Show();
            guna2DataGridView_QL.Hide();
            guna2Button_Luu.Hide();
            guna2Button_Sua.Show();
            textBox_Hoten.Text = GetHoTen();
            textBox_Hoten.ReadOnly = true;
            textBox_Phai.Text = GetPhai();
            textBox_Phai.ReadOnly = true;
            textBox_Ngsinh.Text = GetNgSinh();
            textBox_Ngsinh.ReadOnly = true;
            textBox_DiaChi.Text = GetDiachi();
            textBox_DiaChi.ReadOnly = true;
            textBox_SDT.Text = GetSDT();
            textBox_SDT.ReadOnly = true;
            textBox_PHG.Text = GetPHG();
            textBox_PHG.ReadOnly = true;
            textBox_Luong.Text = GetLuong();
            textBox_Luong.ReadOnly = true;
            textBox_NQL.Text = GetNQL();
            textBox_NQL.ReadOnly = true;
            textBox_PhuCap.Text = GetPhucap();
            textBox_PhuCap.ReadOnly = true;
        }

        public string GetHoTen()
        {
            string query = "SELECT TENNV FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            return value.ToString();
        }
        public string GetPhai()
        {
            string query = "SELECT PHAI FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            if (Convert.ToInt32(value) == 0)
                return "Nam";
            return "Nữ";
        }
        public string GetNgSinh()
        {
            string query = "SELECT NGAYSINH FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            return value.ToString();
        }
        public string GetDiachi()
        {
            string query = "SELECT DIACHI FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            return value.ToString();
        }
        public string GetSDT()
        {
            string query = "SELECT SDT FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            return value.ToString();
        }
        public string GetLuong()
        {
            string query = "SELECT LUONG FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            return value.ToString();
        }
        public string GetPhucap()
        {
            string query = "SELECT PHUCAP FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            return value.ToString();
        }
        public string GetNQL()
        {
            string query = "SELECT MANQL FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return "Không có";
            return value.ToString();
        }
        public string GetPHG()
        {
            string query = "SELECT PHG FROM COMPANY.NHANVIEN$";
            object value = Connection.GetDataToText(query);
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return "Không có";
            return value.ToString();
        }

        private void guna2Button_Sua_Click(object sender, EventArgs e)
        {
            guna2Button_Luu.Show();
            guna2Button_Sua.Hide();
            textBox_Ngsinh.ReadOnly = false;
            textBox_SDT.ReadOnly = false;
            textBox_DiaChi.ReadOnly = false;
        }
        DataTable dtTableName = new DataTable();
        private void guna2Button_CongViec_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Show();
            string query = "SELECT * FROM COMPANY.PHANCONG$";
            dtTableName = Connection.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2Button_NhanVien_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Show();
            string query = "SELECT * FROM COMPANY.NHANVIEN_HIDE";
            dtTableName = Connection.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2Button_PhongBan_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Show();
            string query = "SELECT * FROM COMPANY.PHONGBAN";
            dtTableName = Connection.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2Button_DeAn_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Show();
            string query = "SELECT * FROM COMPANY.DEAN";
            dtTableName = Connection.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2Button_PhanCong_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Show();
            string query = "SELECT * FROM COMPANY.PHANCONG_QL";
            dtTableName = Connection.GetDataToTable(query);
            guna2DataGridView_QL.DataSource = dtTableName;
            guna2DataGridView_QL.AllowUserToAddRows = false;
            guna2DataGridView_QL.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}


