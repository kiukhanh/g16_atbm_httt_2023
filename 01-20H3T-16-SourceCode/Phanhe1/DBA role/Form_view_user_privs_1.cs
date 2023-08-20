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

namespace Phanhe1
{
    public partial class Form_view_user_privs_1 : Form
    {

        public Form_view_user_privs_1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {

                Form_view_user_privs_2 newform = new Form_view_user_privs_2();
                DataGridView dgv1 = newform.GetDataGridView1();
                //DataGridView dgv2 = newform.GetDataGridView2();

                String username = textBox1.Text.ToUpper();
                
                string sql_stmt = "SELECT COUNT(*) FROM all_users WHERE UPPER(USERNAME) = '" + username+"'";

                

                Boolean check = Connectionfunction.check_username(sql_stmt);
                
                if (check == true)
                {
                    DataTable dt1 = Connectionfunction.GetDataToTable("SELECT * FROM DBA_sys_privs WHERE UPPER(GRANTEE) = '" + username+"'");
                    DataTable dt2 = Connectionfunction.GetDataToTable("SELECT * FROM DBA_tab_privs WHERE UPPER(GRANTEE) = '" + username+"'");
                    dgv1.DataSource = dt1;
                    //dgv2.DataSource = dt2;
                    
                    newform.ShowDialog();
                }
                else
                {
                    // the user does not exist
                    MessageBox.Show("The user " + textBox1.Text.ToUpper() + " does not exist in the database.");
                }


            }
            else
            {
                MessageBox.Show("Invalid Username");
            }
            textBox1.Clear();

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
