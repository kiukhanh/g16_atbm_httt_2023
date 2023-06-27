using ChangePasswordForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            input_usn.KeyDown += input_usn_KeyDown;
            input_bonus.KeyDown += input_sal_KeyDown;
            input_sal.KeyDown += input_sal_KeyDown;
            input_sal.KeyPress += txtbox_KeyPress;
            input_bonus.KeyPress += txtbox_KeyPress;

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            String conStr = @"DATA SOURCE=localhost:1521/XE" + ";User ID=NV025;Password=nv025";
            conn = new OracleConnection(conStr);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            input_sal.Visible = false;
            usn_txtbox.Visible = false;
            btn_enter.Visible = false;
            input_usn.Visible = false;
            sal_txtbox.Visible = false;
            bonus_txtbox.Visible = false;
            input_bonus.Visible = false;
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "company.DECRYPT_LUONG_WITHOUT_PASS";

                cmd.ExecuteNonQuery();

            }
            catch (OracleException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                string query = "SELECT * FROM COMPANY.NHANVIEN_TC ORDER BY MANV ASC";
                OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            input_sal.Visible = false;
            usn_txtbox.Visible = false;
            btn_enter.Visible = false;
            input_usn.Visible = false;
            sal_txtbox.Visible = false;
            bonus_txtbox.Visible = false;
            input_bonus.Visible = false;
            try
            {
                conn.Open();
            }
            catch (OracleException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                string query = "SELECT * FROM COMPANY.PHANCONG ORDER BY THOIGIAN ASC";
                OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            input_sal.Visible = true;
            input_usn.Visible = true;
            sal_txtbox.Visible = true;
            usn_txtbox.Visible = true;
            btn_enter.Visible = true;
            bonus_txtbox.Visible = false;
            input_bonus.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            input_sal.Visible = false;
            input_usn.Visible = true;
            sal_txtbox.Visible = false;
            usn_txtbox.Visible = true;
            btn_enter.Visible = true;
            bonus_txtbox.Visible = true;
            input_bonus.Visible = true;
        }
        private void input_usn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if(input_bonus.Visible)
                {
                    input_bonus.Focus();
                }
                if (input_sal.Visible)
                {
                    input_sal.Focus();
                }
            }
        }
        private void btn_enter_Click(object sender, EventArgs e)
        {
            string username = input_usn.Text;
            string sal = input_sal.Text;
            string bonus = input_bonus.Text;

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "company.update_encrypted_luong_phucap";

                cmd.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = username.ToUpper();
                if(input_sal.Visible)
                    cmd.Parameters.Add("p_LUONG", OracleDbType.Varchar2).Value = sal;
                else
                    cmd.Parameters.Add("p_LUONG", OracleDbType.Varchar2).Value = null;
                if (input_bonus.Visible)
                    cmd.Parameters.Add("p_PHUCAP", OracleDbType.Varchar2).Value = bonus;
                else
                    cmd.Parameters.Add("p_PHUCAP", OracleDbType.Varchar2).Value = null;


                cmd.ExecuteNonQuery();
                input_sal.Clear();
                input_bonus.Clear();
                MessageBox.Show("Update successful!");
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void input_sal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                btn_enter_Click(sender,e);
            }

        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }


    }

}
