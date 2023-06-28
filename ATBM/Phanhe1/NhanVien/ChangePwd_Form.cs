using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChangePasswordForm;
using Oracle.ManagedDataAccess.Client;
using Phanhe1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChangePasswordForm
{
    public partial class ChangePwd_Form : Form
    {
        //OracleConnection conn;
        public static bool check = false;
        public ChangePwd_Form()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.Load += Form1_Load;

            input_usn.KeyDown += input_usn_KeyDown;
            input_newpwd.KeyDown += input_newpass_KeyDown;
            input_confirmpwd.KeyDown += input_cfpass_KeyDown;
            input_curpwd.KeyDown += input_curpass_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //String conStr = @"DATA SOURCE=localhost:1521/XE" + ";User ID=NV067;Password=nv067";
            //conn = new OracleConnection(conStr);

            input_usn.Select();
            input_newpwd.PasswordChar = '*';
            input_confirmpwd.PasswordChar = '*';
            input_curpwd.PasswordChar = '*';

        }



        private void input_usn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                input_newpwd.Focus();
            }


        }
        private void input_curpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                input_confirmpwd.Focus();
            }
           
        }
        private void input_newpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                input_curpwd.Focus();
            }

        }
        private void input_cfpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                button1_Click(sender, e);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string username = input_usn.Text;
            string old_password = input_curpwd.Text;
            string new_password = input_newpwd.Text;
            string confirm_passwod = input_confirmpwd.Text;

            if (new_password == confirm_passwod)
            {

                try
                {
                    //Connectionfunction.Con
                    if (Connectionfunction.Con.State != ConnectionState.Open)
                        Connectionfunction.Con.Open();

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = Connectionfunction.Con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Company.change_Key";

                    cmd.Parameters.Add("v_MANV", OracleDbType.Varchar2).Value = username;
                    cmd.Parameters.Add("old_Password", OracleDbType.Varchar2).Value = old_password;
                    cmd.Parameters.Add("new_Password", OracleDbType.Varchar2).Value = new_password;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Change password successfully");
                    check = true;
                    this.Close();

                }
                catch (OracleException ex)
                {

                    if (ex.Message.Contains("no data found"))
                    {
                        MessageBox.Show("Credential is invalid");
                        input_usn.Clear();
                    }
                    else if (ex.Message.Contains("MAT KHAU CU KHONG DUNG"))
                    {
                        MessageBox.Show("Current Password is not correct.");
                    }
                    else if (ex.Message.Contains("MAT KHAU CU KHONG DUOC TRUNG MAT KHAU MOI"))
                    {
                        MessageBox.Show("New password must be different from current password.");
                    }
                    else 
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    input_usn.Clear();
                    input_newpwd.Clear();
                    input_confirmpwd.Clear();
                    input_curpwd.Clear();
                    input_usn.Focus();
                }
            }
            else
            {
                input_usn.Clear();
                input_newpwd.Clear();
                input_confirmpwd.Clear();
                input_curpwd.Clear();
                input_usn.Focus();
                MessageBox.Show("New password and Confirm password do not match");
            }
                
            
        }

    }
}
