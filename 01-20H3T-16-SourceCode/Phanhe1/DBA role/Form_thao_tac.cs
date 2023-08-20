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
using System.Xml.Linq;

namespace Phanhe1
{
    public partial class Form_thao_tac : Form
    {
        
        OracleConnection conn;
        DataTable table_role = new DataTable();
        DataTable table_user = new DataTable();

        private void clearUserInput()
        {
            textBox_UserName.Text = "";
            textBox1_Password.Text = "";
        }

        public Form_thao_tac()
        {
            InitializeComponent();
        }

       
        private void data_OfUser()
        {
            string sql = "SELECT * FROM DBA_USERS";
            table_user = Connectionfunction.GetDataToTable(sql);
            dvg_user_thaotac.DataSource = table_user;
        }

        private void data_OfRole()
        {
            
            string sql = "SELECT * FROM DBA_ROLES";
            table_role = Connectionfunction.GetDataToTable(sql);
            dvg_role_thao_tac.DataSource = table_role;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

      

      

       

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

       
      

        private void button_CreateUser_Click(object sender, EventArgs e)
        {
            string name = textBox_UserName.Text;
            string password = textBox1_Password.Text;
            try
            {
                string sql1 = "BEGIN\nGrant_NewUser('" + name +"','"+ password + "');"+"\nEND;";
                
                Connectionfunction.RunORA(sql1);
                MessageBox.Show("Create user successfully.");
               
                
                data_OfUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Create user unsuccessfully, error: "+ex.Message);
            }
            clearUserInput();
        }

        private void Form_thao_tac_Load(object sender, EventArgs e)
        {
            
            data_OfUser();
            data_OfRole();
        }

        private void button_CreateRole_Click_1(object sender, EventArgs e)
        {
            string name = textBox_UserName.Text;
            string password = password = textBox1_Password.Text;
           
           
            try
            {
                string sql2 = "BEGIN\nGrant_NewRole('" + name + "','" + password + "');" + "\nEND;";
               
                    Connectionfunction.RunORA(sql2);
                    MessageBox.Show("Create role successfully.");
                clearUserInput();
                data_OfRole();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Create role unsuccessfully, error: " + ex.Message);
            }
        }

        private void button_DeleteUser_Click_1(object sender, EventArgs e)
        {
            string name = textBox_UserName.Text;
            
            try
            {
                string sql3 = "BEGIN\nDrop_User('" + name + "');" + "\nEND;";
               
                    Connectionfunction.RunORA(sql3);
                    MessageBox.Show("Delete user successfully.");
                
                
                clearUserInput();
                data_OfUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete user unsuccessfully, error: " + ex.Message);
            }

        }

        private void button_DeleteRole_Click(object sender, EventArgs e)
        {
            string name = textBox_UserName.Text;

            try
            {
                string sql4 = "BEGIN\nDrop_Role('" + name + "');" + "\nEND;";
                
                    Connectionfunction.RunORA(sql4);
                    MessageBox.Show("Delete role successfully.");
                
                data_OfRole();
                clearUserInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete role unsuccessfully, error: "+ex.Message);
            }
        }

        private void button_ThayPassword_Click(object sender, EventArgs e)
        {
            string name = textBox_UserName.Text;
            string password = textBox1_Password.Text;
            
            try
            {
                string sql5 = "BEGIN\nAlter_User('" + name + "','" + password + "');" + "\nEND;";
                
                    Connectionfunction.RunORA(sql5);
                    MessageBox.Show("Change password successfully.");
                
                data_OfUser();
                clearUserInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Change password unsuccessfully, error: " + ex.Message);
            }

        }

        private void button_ThayPasswordRole_Click_1(object sender, EventArgs e)
        {
            string name = textBox_UserName.Text;
            string password = textBox1_Password.Text;
            
            try
            {
                string sql6 = "BEGIN\nAlter_Role('" + name + "','" + password + "');" + "\nEND;";
                
                    Connectionfunction.RunORA(sql6);
                    MessageBox.Show("Change password successfully.");
                
                data_OfRole();
                clearUserInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Change password unsuccessfully, error: " + ex.Message);
            }
        }
    }
}
