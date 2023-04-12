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
    public partial class Form_grant_userrole : Form
    {
        DataTable DT_AllPrivileges = new DataTable(); // bảng chứa dữ liệu tất cả các quyền của 1 user
        String username = "";
        DataGridViewTextBoxColumn dgvc_TableName = new DataGridViewTextBoxColumn();
        string[] columnName = new string[] { "Select", "Select (WITH GRANT OPTION)",
                "Insert", "Insert (WITH GRANT OPTION)"
            ,"Update", "Update (WITH GRANT OPTION)"
            ,"Delete", "Delete (WITH GRANT OPTION)"};


        DataTable all_TableName;
        DataTable all_privilegesOnTable;

        string checkUserOrRole;
     
        private void init_Data()
        {
            // tạo các cột
            dgvc_TableName.HeaderText = "Table Name";
            dvg_grantprivileges.Columns.Add(dgvc_TableName);


            for (int i = 0; i < columnName.Length; i++)
            {
                DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                dgvCmb.HeaderText = columnName[i];
                dvg_grantprivileges.Columns.Add(dgvCmb);
            }

            // lấy tên tất cả bảng
            try
            {
                all_TableName = Connectionfunction.GetAll_TableName();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            for (int i = 0; i < all_TableName.Rows.Count; i++)
            {
                dvg_grantprivileges.Rows.Add(all_TableName.Rows[i].Field<string>(0), false, false,
                false, false,
                false, false,
                false, false);
            }

            // set kích thước cột
            dvg_grantprivileges.Columns[0].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dvg_grantprivileges.AllowUserToAddRows = false;

        }
        public Form_grant_userrole(string us)
        {
            this.username = us;
            InitializeComponent();
            Fill_comboBox();
        }

        private void Fill_comboBox()
        {
            // lấy tất cả role của username này
            DataTable all_role = Connectionfunction.GetRoles();
            foreach (DataRow row in all_role.Rows)
            {
                box_user_role.Items.Add(row["ROLE"].ToString());
            }

            // lấy tất cả user của username này
            DataTable all_user = Connectionfunction.GetAllUsers_wasCreateByUser();
            foreach (DataRow row in all_user.Rows)
            {
                box_user_role.Items.Add(row["USERNAME"].ToString());
            }
        }


        private void button_check_Click(object sender, EventArgs e)
        {
            dvg_grantprivileges.Rows.Clear();

         
            String userOrRole_name = box_user_role.Text.Trim().ToUpper();
            // Hien thi cac quyen ma user/role dang co
            all_privilegesOnTable = Connectionfunction.GetPrivilegeOnTable(userOrRole_name);

            for (int i = 0; i < all_TableName.Rows.Count; i++)
            {
                bool select = false, select_withGrantOption = false,
                    insert = false, insert_withGrantOption = false,
                    update = false, update_withGrantOption = false,
                    delete = false, delete_withGrantOption = false;

                foreach (DataRow row in all_privilegesOnTable.Rows)
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

                dvg_grantprivileges.Rows.Add(all_TableName.Rows[i].Field<string>(0), select, select_withGrantOption,
                    insert, insert_withGrantOption,
                    update, update_withGrantOption,
                    delete, delete_withGrantOption);

            }

            // set kích thước cột
            dvg_grantprivileges.Columns[0].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dvg_grantprivileges.AllowUserToAddRows = false;
        }

        private void button_grant_Click(object sender, EventArgs e)
        {
            string userOrRole_name = box_user_role.Text.Trim();

            //Cap nhat lai quyen cua user/role
            string[] privName = new string[] { "A", "SELECT", "SELECT",
                "INSERT", "INSERT"
            ,"UPDATE", "UPDATE"
            ,"DELETE", "DELETE"};


            for (int i = 0; i < dvg_grantprivileges.Rows.Count; i++)
            {

                string table_name = (string)dvg_grantprivileges.Rows[i].Cells[0].Value;
                for (int j = 1; j < columnName.Length; j++)
                {
                    //Neu la quyen WITH GRANT OPTION va dang xet la Role thi bo qua
                    if (j % 2 == 0 && checkUserOrRole == "Role")
                        continue;

                    string priv = privName[j];

                    bool isChecked = (bool)dvg_grantprivileges.Rows[i].Cells[j].Value;

                    //Ktra xem quyen nay co thuoc ve user/role dang xet hay khong
                    string privIsExist;
                    string grant_opt;
                    if (checkUserOrRole == "Role")
                        grant_opt = "NO";
                    else if (j % 2 == 0)
                        grant_opt = "YES";
                    else
                        grant_opt = "NO";

                    if (checkUserOrRole == "User")
                    {
                        privIsExist = Connectionfunction.CheckIfPrivilegeBelongToUser(userOrRole_name, table_name, priv, grant_opt);
                    }
                    else
                    {
                        privIsExist = Connectionfunction.CheckIfPrivilegeBelongToRole(userOrRole_name, table_name, priv, grant_opt);
                    }

                    //Ktra xem neu nguoi dung bo tick quyen nay thi tien hanh revoke quyen khoi user/role
                    if (isChecked == false && privIsExist == "Yes")
                    {
                        Connectionfunction.RevokePrivilegeOnTable(table_name, userOrRole_name, priv);
                        continue;
                    }

                    //Ktra neu nguoi dung tick quyen nay va quyen nay chua dc grant cho user/role thi tien hanh grant quyen vao
                    if (isChecked == true && privIsExist == "No")
                    {
                        if (checkUserOrRole == "Role")
                        {
                            Connectionfunction.GrantPrivilegeOnTable(table_name, userOrRole_name, priv, "");
                        }
                        else if (j % 2 == 0)
                        {
                            Connectionfunction.GrantPrivilegeOnTable(table_name, userOrRole_name, priv, "WITH GRANT OPTION");
                        }
                        else
                        {
                            Connectionfunction.GrantPrivilegeOnTable(table_name, userOrRole_name, priv, "");
                        }

                    }
                }
            }
            MessageBox.Show("Gan quyen thanh cong");
        }

        private void dvg_grantprivileges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_grant_userrole_Load(object sender, EventArgs e)
        {
            init_Data();
        }
    }
}
