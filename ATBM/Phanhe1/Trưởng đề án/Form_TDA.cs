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

namespace Phanhe2
{
    public partial class Form_TDA : Form
    {
        public Form_TDA()
        {
            InitializeComponent();
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Hide();
            panel_DeAn.Hide();
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
            panel_CaNhan.Controls.Add(childForm);
            panel_CaNhan.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void guna2Button_CaNhan_Click(object sender, EventArgs e)
        {
           
            panel_CaNhan.Show();
            guna2Button_Luu.Hide();
            guna2Button_Sua.Show();
            guna2DataGridView_QL.Hide();
            panel_DeAn.Hide();
            openChildForm(new Form_NV_NV());
        }
        DataTable dtTableName = new DataTable();
        private void guna2Button_CongViec_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Show();
            guna2DataGridView_QL.Hide();
            panel_DeAn.Hide();
            openChildForm(new Form_NV_PC());
        }

        private void guna2Button_PhongBan_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Show();
            guna2DataGridView_QL.Hide();
            panel_DeAn.Hide();
            openChildForm(new Form_NV_PB());
        }

        private void guna2Button_DeAn_Click(object sender, EventArgs e)
        {
            panel_CaNhan.Hide();
            guna2DataGridView_QL.Hide();
            panel_DeAn.Show();
            panel_ThemDA.Hide();
            panel_SuaDA.Hide();
            string query = "SELECT * FROM COMPANY.DEAN";
            dtTableName = Connectionfunction.GetDataToTable(query);
            guna2DataGridView_DeAn.DataSource = dtTableName;
            guna2DataGridView_DeAn.ReadOnly = true;
        }

        private void guna2Button_Sua_Click(object sender, EventArgs e)
        {
            guna2Button_Luu.Show();
            guna2Button_Sua.Hide();
            textBox_Ngsinh.ReadOnly = false;
            textBox_SDT.ReadOnly = false;
            textBox_DiaChi.ReadOnly = false;
        }

        private void addDataCbb(ComboBox cbb, string query, string column)
        {
            DataTable allColumn = Connectionfunction.GetDataToTable(query);
            foreach (DataRow row in allColumn.Rows)
            {
                cbb.Items.Add(row[column].ToString());
            }
        }

        private void guna2Button_DA_Sua_Click(object sender, EventArgs e)
        {
            panel_SuaDA.Show();
            string query = "SELECT MADA FROM COMPANY.DEAN";
            addDataCbb(comboBox_MaDA, query, "MADA");
            query = "SELECT MAPB FROM COMPANY.PHONGBAN";
            addDataCbb(comboBox_PHG_Sua, query, "MAPB");
        }

        private void guna2Button_DA_Them_Click(object sender, EventArgs e)
        {
            panel_ThemDA.Show();
            string query = "SELECT MAPB FROM COMPANY.PHONGBAN";
            addDataCbb(comboBox_PHG, query, "MAPB");
        }

        private void guna2Button_DA_Xoa_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView_DeAn.SelectedRows.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (guna2DataGridView_DeAn.SelectedRows.Count > 0)
                        {
                            // Lấy ra giá trị khóa chính của hàng cần xóa
                            string mada = (guna2DataGridView_DeAn.SelectedRows[0].Cells["MADA"].Value).ToString();

                            // Xóa dữ liệu trên cơ sở dữ liệu Oracle
                            string query = "DELETE FROM COMPANY.DEAN WHERE MADA = '" + mada + "'";
                            Connectionfunction.RunORA(query);

                            //
                            MessageBox.Show("Xóa thành công");
                            // Cập nhật lại dữ liệu trên DataGridView
                            string queryRefresh = "SELECT * FROM COMPANY.DEAN";
                            dtTableName = Connectionfunction.GetDataToTable(queryRefresh);
                            guna2DataGridView_DeAn.DataSource = dtTableName;
                        }
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void guna2Button_XN_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ra giá trị khóa chính của hàng cần xóa
                string mada = textBox_MaDA.Text;
                string tenda = textBox_TenDA.Text;
                DateTime ngaybd_date = dateTimePicker_NgBD.Value;
                string ngbd = ngaybd_date.ToString("dd-MM-yyyy");
                string phg = comboBox_PHG.Text;

                // Thêm dữ liệu trên cơ sở dữ liệu Oracle
                string query = "INSERT INTO COMPANY.DEAN VALUES ('" + mada + "','" + tenda + "',TO_DATE('" + ngbd + "','DD-MM-YYYY'),'" + phg + "')";
                Connectionfunction.RunORA(query);

                //
                MessageBox.Show("Thêm thành công");
                panel_ThemDA.Hide();
                // Cập nhật lại dữ liệu trên DataGridView
                string queryRefresh = "SELECT * FROM COMPANY.DEAN";
                dtTableName = Connectionfunction.GetDataToTable(queryRefresh);
                guna2DataGridView_DeAn.DataSource = dtTableName;

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox_MaDA.Clear();
            textBox_TenDA.Clear();
            comboBox_PHG.Items.Clear();
        }

        private void guna2Button_Huy_Click(object sender, EventArgs e)
        {
            panel_ThemDA.Hide();
        }

        private void guna2Button_Huy_Sua_Click(object sender, EventArgs e)
        {
            panel_SuaDA.Hide();
        }

        private void guna2Button_XN_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ra giá trị khóa chính của hàng cần xóa
                string mada = comboBox_MaDA.Text;
                string tenda = textBox_TenDA_Sua.Text;
                DateTime ngaybd_date = dateTimePicker_NgBD_Sua.Value;
                string ngbd = ngaybd_date.ToString("dd-MM-yyyy");
                string phg = comboBox_PHG_Sua.Text;

                // Sửa dữ liệu trên cơ sở dữ liệu Oracle
                string query = "UPDATE COMPANY.DEAN SET TENDA = '" + tenda + "', NGAYBD = TO_DATE('" + ngbd + "','DD-MM-YYYY'), PHONG = '" + phg + "' WHERE MADA = '" + mada + "'";
                Connectionfunction.RunORA(query);
                //
                MessageBox.Show("Sửa thành công");
                panel_SuaDA.Hide();
                // Cập nhật lại dữ liệu trên DataGridView
                string queryRefresh = "SELECT * FROM COMPANY.DEAN";
                dtTableName = Connectionfunction.GetDataToTable(queryRefresh);
                guna2DataGridView_DeAn.DataSource = dtTableName;

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox_MaDA.Items.Clear();
            textBox_TenDA.Clear();
            comboBox_PHG_Sua.Items.Clear();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
