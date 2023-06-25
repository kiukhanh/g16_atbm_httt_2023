using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanhe2
{
    public partial class Form_TDA : Form
    {
        public Form_TDA()
        {
            InitializeComponent();
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Hide();
            string query = "SELECT SYS_CONTEXT('USERENV','SESSION_USER') FROM DUAL";
            object value = Connection.GetDataToText(query);
            textBox_ID.Text = "ID: " + value.ToString();
        }

        private void guna2Button_CaNhan_Click(object sender, EventArgs e)
        {
            Form_QL ql = new Form_QL();
            panel_CaNhan.Show();
            guna2Button_Luu.Hide();
            guna2Button_Sua.Show();
            guna2DataGridView_QL.Hide();
            textBox_Hoten.Text = ql.GetHoTen();
            textBox_Hoten.ReadOnly = true;
            textBox_Phai.Text = ql.GetPhai();
            textBox_Phai.ReadOnly = true;
            textBox_Ngsinh.Text = ql.GetNgSinh();
            textBox_Ngsinh.ReadOnly = true;
            textBox_DiaChi.Text = ql.GetDiachi();
            textBox_DiaChi.ReadOnly = true;
            textBox_SDT.Text = ql.GetSDT();
            textBox_SDT.ReadOnly = true;
            textBox_PHG.Text = ql.GetPHG();
            textBox_PHG.ReadOnly = true;
            textBox_Luong.Text = ql.GetLuong();
            textBox_Luong.ReadOnly = true;
            textBox_NQL.Text = ql.GetNQL();
            textBox_NQL.ReadOnly = true;
            textBox_PhuCap.Text = ql.GetPhucap();
            textBox_PhuCap.ReadOnly = true;
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

        private void guna2Button_Sua_Click(object sender, EventArgs e)
        {
            guna2Button_Luu.Show();
            guna2Button_Sua.Hide();
            textBox_Ngsinh.ReadOnly = false;
            textBox_SDT.ReadOnly = false;
            textBox_DiaChi.ReadOnly = false;
        }
    }
}
