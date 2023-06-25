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

        public void Load_Infor()
        {
            string cmd = "SELECT MANV FROM COMPANY.NHANVIEN$";
            string MANV = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox2.Text = MANV;

            cmd = "SELECT TENNV FROM COMPANY.NHANVIEN$";
            string TENNV = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox1.Text = TENNV;

            //SELECT TO_CHAR(TO_DATE(NGAYSINH,'MM/DD/SYYYY HH24:MI:SS'))
            cmd = "SELECT NGAYSINH FROM COMPANY.NHANVIEN$";
            string NGAYSINH = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox3.Text = NGAYSINH;

            cmd = "SELECT DIACHI FROM COMPANY.NHANVIEN$";
            string DIACHI = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox6.Text = DIACHI;

            cmd = "SELECT SDT FROM COMPANY.NHANVIEN$";
            string SDT = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox4.Text = SDT;

            cmd = "SELECT VAITRO FROM COMPANY.NHANVIEN$";
            string VAITRO = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox8.Text = VAITRO;

            cmd = "SELECT MANQL FROM COMPANY.NHANVIEN$";
            string MANQL = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox7.Text = MANQL;

            cmd = "SELECT PHAI FROM COMPANY.NHANVIEN$";
            string PHAI = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox5.Text = PHAI;


            cmd = "SELECT PHG FROM COMPANY.NHANVIEN$";
            string PHONG = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox14.Text = PHONG;


            cmd = "SELECT LUONG FROM COMPANY.NHANVIEN$";
            string LUONG = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox9.Text = LUONG;


            cmd = "SELECT PHUCAP FROM COMPANY.NHANVIEN$";
            string PHUCAP = Connectionfunction.cmd_reader_1row_1col(cmd);
            textBox10.Text = PHUCAP;
        }



        DataTable table_NVTP = new DataTable();
        DataTable table_PB = new DataTable();
        DataTable table_DA = new DataTable();
        DataTable table_PCTP = new DataTable();

        private void FORM_TRUONG_PHONG_Load(object sender, EventArgs e)
        {
            Load_Infor();

            string sql = "SELECT * FROM COMPANY.NHANVIEN_TP";
            table_NVTP = Connectionfunction.GetDataToTable(sql);
            dataGridView1.DataSource = table_NVTP;

            sql = "SELECT * FROM COMPANY.PHONGBAN";
            table_PB = Connectionfunction.GetDataToTable(sql);
            dataGridView2.DataSource = table_PB;

            sql = "SELECT * FROM COMPANY.DEAN";
            table_DA = Connectionfunction.GetDataToTable(sql);
            dataGridView3.DataSource = table_DA;

            sql = "SELECT * FROM COMPANY.PHANCONG_TP";
            table_PCTP = Connectionfunction.GetDataToTable(sql);
            dataGridView4.DataSource = table_PCTP;

            this.AutoScroll = true;
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE COMPANY.NHANVIEN_UPDATE SET NGAYSINH = TO_DATE('" + textBox3.Text + "','MM/DD/SYYYY HH24:MI:SS', 'NLS_DATE_LANGUAGE = American'), SDT = '" + textBox4.Text + "', DIACHI = '" + textBox6.Text + "'";
                Connectionfunction.RunORA(sql);
                MessageBox.Show("Update succeed.");

                string sql2 = "SELECT * FROM COMPANY.NHANVIEN_TP";
                table_NVTP = Connectionfunction.GetDataToTable(sql2);
                dataGridView1.DataSource = table_NVTP;
            }
            catch (OracleException ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO COMPANY.PHANCONG_TP VALUES ('" + textBox12.Text + "','" + textBox11.Text + "',TO_DATE('" + textBox13.Text + "','MM/DD/SYYYY HH24:MI:SS', 'NLS_DATE_LANGUAGE = American'))";
                Connectionfunction.RunORA(sql);
                MessageBox.Show("Insert succeed.");

                string sql2 = "SELECT * FROM COMPANY.PHANCONG_TP";
                table_PCTP = Connectionfunction.GetDataToTable(sql2);
                dataGridView4.DataSource = table_PCTP;
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
                dataGridView4.DataSource = table_PCTP;
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
                dataGridView4.DataSource = table_PCTP;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
