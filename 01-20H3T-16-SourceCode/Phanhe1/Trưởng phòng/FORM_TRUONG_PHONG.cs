using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Phanhe1
{

    public partial class FORM_TRUONG_PHONG : Form
    {

        public FORM_TRUONG_PHONG()
        {
            InitializeComponent();
            Fill_comboBox();
        }

        DataTable table_NVTP = new DataTable();
        DataTable table_PB = new DataTable();
        DataTable table_DA = new DataTable();
        DataTable table_PCTP = new DataTable();

        private void FORM_TRUONG_PHONG_Load(object sender, EventArgs e)
        {
            
            string sql = "SELECT * FROM COMPANY.PHANCONG_TP";
            table_PCTP = Connectionfunction.GetDataToTable(sql);
            dgv_phancong.DataSource = table_PCTP;

            this.AutoScroll = true;
            
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(guna2ComboBox1.Text) || string.IsNullOrEmpty(guna2ComboBox2.Text)|| string.IsNullOrEmpty(guna2DateTimePicker1.Value.ToString("dd/MM/yyyy")))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sql = "INSERT INTO COMPANY.PHANCONG_TP VALUES ('" + guna2ComboBox1.Text + "','" + guna2ComboBox2.Text + "',TO_DATE('" + guna2DateTimePicker1.Value.ToString("dd/MM/yyyy") + "','DD/MM/YYYY'))";
                Connectionfunction.RunORA(sql);
                MessageBox.Show("Insert succeed.");

                string sql2 = "SELECT * FROM COMPANY.PHANCONG_TP";
                table_PCTP = Connectionfunction.GetDataToTable(sql2);
                dgv_phancong.DataSource = table_PCTP;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "DELETE FROM COMPANY.PHANCONG_TP WHERE MADA = '" + guna2ComboBox3.Text + "' AND MANV = '" + guna2ComboBox4.Text + "'";
                Connectionfunction.RunORA(sql);
                MessageBox.Show("Delete succeed.");

                string sql2 = "SELECT * FROM COMPANY.PHANCONG_TP";
                table_PCTP = Connectionfunction.GetDataToTable(sql2);
                dgv_phancong.DataSource = table_PCTP;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string thoigian = guna2DateTimePicker2.Value.ToString("dd-MM-yyyy"); // Format the date value
                string sql = "UPDATE COMPANY.PHANCONG_TP SET THOIGIAN = TO_DATE('" + thoigian + "','MM/DD/YYYY') WHERE MADA = '" + guna2ComboBox3.Text + "' AND MANV = '" + guna2ComboBox4.Text + "'";
                Connectionfunction.RunORA(sql);
                MessageBox.Show("Update succeed.");

                string sql2 = "SELECT * FROM COMPANY.PHANCONG_TP";
                table_PCTP = Connectionfunction.GetDataToTable(sql2);
                dgv_phancong.DataSource = table_PCTP;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql2 = "SELECT * FROM COMPANY.PHANCONG_TP";
            table_PCTP = Connectionfunction.GetDataToTable(sql2);
            dgv_phancong.DataSource = table_PCTP;
        }

        private void Fill_comboBox()
        {
            // lấy tất cả MANV thuộc PB của TP này
            DataTable NV = new DataTable();
            string sql = "SELECT * FROM COMPANY.NHANVIEN_TP";
            NV = Connectionfunction.GetDataToTable(sql);
            foreach (DataRow row in NV.Rows)
            {
                guna2ComboBox2.Items.Add(row["MANV"].ToString());
            }


            DataTable DA = new DataTable();
            string sql2 = "SELECT * FROM COMPANY.DEAN";
            DA = Connectionfunction.GetDataToTable(sql2);
            foreach (DataRow row in DA.Rows)
            {
                guna2ComboBox1.Items.Add(row["MADA"].ToString());
            }

            DataTable DA_daPC = new DataTable();
            string sql3 = "SELECT DISTINCT MADA FROM COMPANY.PHANCONG_TP";
            DA_daPC = Connectionfunction.GetDataToTable(sql3);
            foreach (DataRow row in DA_daPC.Rows)
            {
                guna2ComboBox3.Items.Add(row["MADA"].ToString());
            }

            DataTable NV_daPC = new DataTable();
            string sql4 = "SELECT DISTINCT MANV FROM COMPANY.PHANCONG_TP";
            NV_daPC = Connectionfunction.GetDataToTable(sql4);
            foreach (DataRow row in NV_daPC.Rows)
            {
                guna2ComboBox4.Items.Add(row["MANV"].ToString());
            }
        }
    }
}
