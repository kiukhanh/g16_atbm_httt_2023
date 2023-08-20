using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Phanhe1
{
    public partial class Form_grant_userrole : Form
    {
        String username = "";
        DataGridViewTextBoxColumn dgvc_TableName_USER = new DataGridViewTextBoxColumn();
       
        string[] columnNameuser = new string[] {
            "Select", "Select (WGO)",
            "Insert", "Insert (WGO)"
            ,"Update", "Update (WGO)"
            ,"Delete", "Delete (WGO)"};
      

        DataTable all_TableName;
        DataTable all_privs;


        private void init_Data()
        {
            // tạo các cột
            dgvc_TableName_USER.HeaderText = "Table Name";
            dvg_privs_user.Columns.Add(dgvc_TableName_USER);
            

            for (int i = 0; i < columnNameuser.Length; i++)
            {
                DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                check.HeaderText = columnNameuser[i];
                dvg_privs_user.Columns.Add(check);
            }
            

            // lấy tên tất cả bảng
            try
            {
                all_TableName = Connectionfunction.GetAllTableName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            for (int i = 0; i < all_TableName.Rows.Count; i++)
            {
                dvg_privs_user.Rows.Add(all_TableName.Rows[i].Field<string>(0), false, false, false, false, false, false, false, false);
               

            }

            dvg_privs_user.AllowUserToAddRows = false;

        }


        public Form_grant_userrole(string us)
        {
            username = us;
            InitializeComponent();
            Fill_comboBox();
        }

        private void Fill_comboBox()
        {
            // lấy tất cả role của username này
            DataTable all_role = Connectionfunction.GetRoles(username);
            foreach (DataRow row in all_role.Rows)
            {
                box_role.Items.Add(row["granted_role"].ToString());
            }

            // lấy tất cả user của username này
            DataTable all_user = Connectionfunction.GetAllUsers_wasCreateByUser();
            foreach (DataRow row in all_user.Rows)
            {
                box_user.Items.Add(row["USERNAME"].ToString());
            }
        }


        private void button_check_Click(object sender, EventArgs e)
        {
           
            dvg_privs_user.Rows.Clear();
            string userbox = box_user.Text.Trim().ToUpper();
           
            // Hien thi cac quyen ma user/role dang co
            all_privs = Connectionfunction.GetPrivilegeOnTable(userbox);

            for (int i = 0; i < all_TableName.Rows.Count; i++)
            {
                bool select = false, select_withGrantOption = false,
                    insert = false, insert_withGrantOption = false,
                    update = false, update_withGrantOption = false,
                    delete = false, delete_withGrantOption = false;

                foreach (DataRow row in all_privs.Rows)
                {
                    String table_name = row["TABLE_NAME"].ToString();
                    String privilege = row["PRIVILEGE"].ToString();
                    String grantable = row["GRANTABLE"].ToString();
                    if (table_name.Equals(all_TableName.Rows[i].Field<string>(0)))
                    {
                        if (privilege == "SELECT")
                        {
                            select = true;
                            if (grantable == "YES")
                                select_withGrantOption = true;
                        }
                        if (privilege == "INSERT")
                        {
                            insert = true;
                            if (grantable == "YES")
                                insert_withGrantOption = true;
                        }
                        if (privilege == "UPDATE")
                        {
                            update = true;
                            if (grantable == "YES")
                                update_withGrantOption = true;
                        }
                        if (privilege == "DELETE")
                        {
                            delete = true;
                            if (grantable == "YES")
                                delete_withGrantOption = true;
                        }
                    }
                }

                dvg_privs_user.Rows.Add(all_TableName.Rows[i].Field<string>(0), select, select_withGrantOption,
                    insert, insert_withGrantOption,
                    update, update_withGrantOption,
                    delete, delete_withGrantOption);

            }

        }

        string privIsExist;
        string grant_opt;
        string checkroleusser;
        private void button_grant_Click(object sender, EventArgs e)
        {
            string userbox = box_user.Text.Trim();
                
            //Cap nhat lai quyen cua user/role
            string[] privName = new string[] { "TABLE NAME", "SELECT", "SELECT", "INSERT", "INSERT", "UPDATE", "UPDATE", "DELETE", "DELETE" };

            for (int i = 0; i < dvg_privs_user.Rows.Count; i++)
            {

                string table_name = (string)dvg_privs_user.Rows[i].Cells[0].Value;
                for (int j = 1; j < columnNameuser.Length; j++)
                {
                    string priv = privName[j];

                    bool isChecked = (bool)dvg_privs_user.Rows[i].Cells[j].Value;

                    
                    if (j % 2 == 0)
                        grant_opt = "YES";
                    else
                        grant_opt = "NO";
                
                    privIsExist = Connectionfunction.CheckIfPrivilegeBelongToUser(userbox, table_name, priv, grant_opt);
                   

                    if (isChecked == false && privIsExist == "Yes")
                    {
                        Connectionfunction.RevokePrivs(table_name, userbox, priv);
                        continue;
                    }
                    if (isChecked == true && privIsExist == "No")
                    {

                        if (j % 2 == 0)
                        {
                            Connectionfunction.GrantPrivs(table_name, userbox, priv, "WITH GRANT OPTION");
                        }
                        else
                        {
                            Connectionfunction.GrantPrivs(table_name, userbox, priv, "");
                        }
                    }
                }

            }
            MessageBox.Show("Gan quyen thanh cong");
        }

        private void Form_grant_userrole_Load(object sender, EventArgs e)
        {
            init_Data();
        }

        private void btn_check_role_Click(object sender, EventArgs e)
        {
            dvg_privs_user.Rows.Clear();

            string role = box_role.Text.Trim();
            // Hien thi cac quyen ma user/role dang co
            all_privs = Connectionfunction.GetPrivilegeOnTable(role);

            for (int i = 0; i < all_TableName.Rows.Count; i++)
            {
                bool select = false, select_withGrantOption = false,
                    insert = false, insert_withGrantOption = false,
                    update = false, update_withGrantOption = false,
                    delete = false, delete_withGrantOption = false;

                foreach (DataRow row in all_privs.Rows)
                {
                    String table_name = row["TABLE_NAME"].ToString();
                    String privilege = row["PRIVILEGE"].ToString();
                    String grantable = row["GRANTABLE"].ToString();
                    if (table_name.Equals(all_TableName.Rows[i].Field<string>(0)))
                    {
                        if (privilege == "SELECT")
                        {
                            select = true;
                            if (grantable == "YES")
                                select_withGrantOption = true;
                        }
                        if (privilege == "INSERT")
                        {
                            insert = true;
                            if (grantable == "YES")
                                insert_withGrantOption = true;
                        }
                        if (privilege == "UPDATE")
                        {
                            update = true;
                            if (grantable == "YES")
                                update_withGrantOption = true;
                        }
                        if (privilege == "DELETE")
                        {
                            delete = true;
                            if (grantable == "YES")
                                delete_withGrantOption = true;
                        }
                    }
                }

                dvg_privs_user.Rows.Add(all_TableName.Rows[i].Field<string>(0), select, select_withGrantOption,
                    insert, insert_withGrantOption,
                    update, update_withGrantOption,
                    delete, delete_withGrantOption);

            }
        }

        private void btn_role_Click(object sender, EventArgs e)
        {
            String rolebx = box_role.Text.Trim();

            //Cap nhat lai quyen cua user/role
            string[] privName = new string[] { "TABLE NAME", "SELECT", "SELECT", "INSERT", "INSERT", "UPDATE", "UPDATE", "DELETE", "DELETE" };

            for (int i = 0; i < dvg_privs_user.Rows.Count; i++)
            {
               
                string table_name = (string)dvg_privs_user.Rows[i].Cells[0].Value;
                for (int j = 1; j < columnNameuser.Length; j++)
                {
                    //Neu la quyen WITH GRANT OPTION va dang xet la Role thi bo qua
                    if (j % 2 == 0)
                        continue;
                    string priv = privName[j];

                    bool isChecked = (bool)dvg_privs_user.Rows[i].Cells[j].Value;

                    grant_opt = "NO";

                    privIsExist = Connectionfunction.CheckIfPrivilegeBelongToRole(rolebx, table_name, priv, grant_opt);


                    if (isChecked == false && privIsExist == "Yes")
                    {
                        Connectionfunction.RevokePrivs(table_name, rolebx, priv);
                        continue;
                    }
                    if (isChecked == true && privIsExist == "No")
                    {
                       
                       Connectionfunction.GrantPrivs(table_name, rolebx, priv, "");
                      
                    }
                }

            }
            MessageBox.Show("Gan quyen thanh cong");
        }
    }
}
