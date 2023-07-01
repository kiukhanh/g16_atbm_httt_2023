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
using Phanhe1;
using Phanhe1.NhanVien;

namespace WindowsFormsApp1
{
    public partial class Form_Main_TC : Form
    {
 
        public Form_Main_TC()
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
            string query = "SELECT SYS_CONTEXT('USERENV','SESSION_USER') FROM DUAL";
            object value = Connectionfunction.GetDataToText(query);
            textBox_ID.Text = "ID: " + value.ToString();
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

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Connectionfunction.Con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "COMPANY.DECRYPT_LUONG_WITHOUT_PASS";
                cmd.ExecuteNonQuery();

            }
            catch (OracleException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                string query = "SELECT * FROM COMPANY.NHANVIEN_TC ORDER BY MANV ASC";
                OracleDataAdapter adapter = new OracleDataAdapter(query, Connectionfunction.Con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                string deleteQuery = "DELETE FROM COMPANY.NHANVIEN_TC";
                using (OracleCommand command = new OracleCommand(deleteQuery, Connectionfunction.Con))
                {
                    // Execute the delete query
                    command.ExecuteNonQuery();
                }

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
            string query = "SELECT * FROM COMPANY.PHANCONG ORDER BY THOIGIAN ASC";
            OracleDataAdapter adapter = new OracleDataAdapter(query, Connectionfunction.Con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = dataTable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            bonus_txtbox.Visible = false;
            input_bonus.Visible = false;


            btn_enter.Visible = true;
            input_sal.Visible = true;
            input_usn.Visible = true;
            sal_txtbox.Visible = true;
            usn_txtbox.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            input_sal.Visible = false;
            sal_txtbox.Visible = false;
            btn_enter.Visible = true;

            usn_txtbox.Visible = true;
            input_usn.Visible = true;

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
            string sal = null;
            string bonus = null;
            if(input_sal.Visible)
                sal = input_sal.Text;
            if (input_bonus.Visible)
                bonus = input_bonus.Text;

            try
            {
                
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Connectionfunction.Con;
                cmd.CommandType = CommandType.StoredProcedure;
                if (sal != null)
                {
                    cmd.CommandText = "COMPANY.update_encrypted_luong";
                    cmd.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = username.ToUpper();
                    cmd.Parameters.Add("p_LUONG", OracleDbType.Varchar2).Value = sal;
                }
                if(bonus != null)
                {
                    cmd.CommandText = "COMPANY.update_encrypted_phucap";
                    cmd.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = username.ToUpper();
                    cmd.Parameters.Add("p_PHUCAP", OracleDbType.Varchar2).Value = bonus;
                }


                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successfully!");
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                input_usn.Clear();
                input_sal.Clear();
                input_bonus.Clear();
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
      
        private void button1_Click(object sender, EventArgs e)
        {
            Form_NV_PB pB= new Form_NV_PB();
            pB.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           Form_NV_DA pb= new Form_NV_DA();
            pb.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form_NV_NV pb= new Form_NV_NV();
            pb.Show();
        }

        private void Form_Main_TC_Load(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
        }

        private void input_usn_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Enter1_Click(object sender, EventArgs e)
        {
            string username = input_usn.Text;
            string bonus = input_bonus.Text;

            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Connectionfunction.Con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "COMPANY.update_encrypted_phucap";

                cmd.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = username.ToUpper();
                cmd.Parameters.Add("p_PHUCAP", OracleDbType.Varchar2).Value = bonus;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successfully!");
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                input_usn.Clear();
                input_bonus.Clear();
            }
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
