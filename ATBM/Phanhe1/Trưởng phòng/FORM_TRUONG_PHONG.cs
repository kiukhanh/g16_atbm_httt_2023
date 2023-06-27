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
                if (string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox11.Text)|| string.IsNullOrEmpty(textBox13.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sql = "INSERT INTO COMPANY.PHANCONG_TP VALUES ('" + textBox12.Text + "','" + textBox11.Text + "',TO_DATE('" + textBox13.Text + "','MM/DD/SYYYY HH24:MI:SS', 'NLS_DATE_LANGUAGE = American'))";
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
                string sql = "DELETE FROM COMPANY.PHANCONG_TP WHERE MADA = '" + textBox12.Text + "' AND MANV = '" + textBox11.Text + "'";
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
                string sql = "UPDATE COMPANY.PHANCONG_TP SET THOIGIAN = TO_DATE('" + textBox13.Text + "','MM/DD/SYYYY HH24:MI:SS', 'NLS_DATE_LANGUAGE = American') WHERE MADA = '" + textBox12.Text + "' AND MANV = '" + textBox11.Text + "'";
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
    }
}
