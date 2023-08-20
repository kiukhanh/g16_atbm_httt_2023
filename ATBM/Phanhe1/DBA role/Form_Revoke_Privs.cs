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
    public partial class Form_Revoke_Privs : Form
    {
        OracleConnection conn;

        DataTable table_obj_user = new DataTable();
        DataTable table_sys_user = new DataTable();
        DataTable table_obj_role = new DataTable();
        DataTable table_sys_role = new DataTable();
        public Form_Revoke_Privs()
        {
            InitializeComponent();
        }
        private void clearInput()
        {
            textBox1.Text = "";
            textBox2.Text = "";
           
            textBox5.Text = "";


        }
       
        private void data_OfObjPriv_Role()
        {
            
            string sql = "SELECT role, table_name, privilege FROM ROLE_TAB_PRIVS";
            table_obj_role = Connectionfunction.GetDataToTable(sql);
            dvg_roleobj.DataSource = table_obj_role;
        }

      

        private void data_OfObjPriv_User()
        {
           
            string sql3 = "SELECT grantee, table_name, privilege FROM USER_TAB_PRIVS";
            table_obj_user = Connectionfunction.GetDataToTable(sql3);
            dvg_userobj.DataSource = table_obj_user;
        }

        

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string priv = textBox2.Text;
            string obj = textBox5.Text;
            
            try
            {
                string sql6 = "BEGIN\nRevoke_Object_Privs_User('" + name + "','" + priv + "','" + obj + "');" + "\nEND;";
                Connectionfunction.RunORA(sql6);
                MessageBox.Show("Revoke object privilege of user successfully.");
                clearInput();
                data_OfObjPriv_User();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string priv = textBox2.Text;
            string obj = textBox5.Text;
            
            try
            {
                string sql6 = "BEGIN\nRevoke_Object_Privs_User('" + name + "','" + priv +"','"+ obj + "');" + "\nEND;";
                Connectionfunction.RunORA(sql6);
                MessageBox.Show("Revoke object privilege of user successfully.");
                clearInput();
                data_OfObjPriv_User();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

      

        private void Form_Revoke_Privs_Load(object sender, EventArgs e)
        {
            data_OfObjPriv_Role();
            data_OfObjPriv_User();
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
