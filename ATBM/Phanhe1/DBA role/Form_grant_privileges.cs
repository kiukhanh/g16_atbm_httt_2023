using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Phanhe1.DBA_Func
{
    public partial class Form_grant_privileges : Form
    {
       
        string checkUserOrRole;
        DataTable all_TableName;
        DataTable all_role;
        private void Fill_comboBox()
        {
            // lấy tất cả role của username này
            //all_role = Connectionfunction.GetRoles(username);
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

            all_TableName = Connectionfunction.GetAllTableName();

            foreach (DataRow row in all_TableName.Rows)
            {
                cbb_table.Items.Add(row["TABLE_NAME"].ToString());
            }
            

        }
        public Form_grant_privileges()
        {
            InitializeComponent();
            Fill_comboBox();
            
            
        }

        private void button_grant_Click(object sender, EventArgs e)
        {
            string userOrRole_name = box_user_role.Text.Trim();
            string table = cbb_table.Text.Trim();
            
            OracleCommand command = new OracleCommand();
            command.Connection = Connectionfunction.Con;

            if (check_select_opt.Checked == false)
            {
                if (check_selec.Checked == true)
                {
                    
                        check_selec.Checked = false;
                        command.CommandText = $"GRANT SELECT ON {table} TO {userOrRole_name}";
                        command.ExecuteNonQuery();
                    
                }
            }
            else
            {
               
                
                    check_selec.Checked = false;
                    command.CommandText = $"GRANT SELECT ON {table} TO {userOrRole_name} WITH GRANT OPTION";
                    command.ExecuteNonQuery();
             
            }
            
            if(check_insert_opt.Checked == false)
            {
                if (check_insert.Checked == true)
                {
                    command.CommandText = $"GRANT INSERT ON {table} TO {userOrRole_name}";
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                check_insert.Checked = false;
                command.CommandText = $"GRANT INSERT ON {table} TO {userOrRole_name} WITH GRANT OPTION";
                command.ExecuteNonQuery();
            }

            if(check_update_otp.Checked == false)
            {
                if (check_update.Checked == true)
                {
                    if (CBB_column.SelectedItem != null)
                    {
                        command.CommandText = $"GRANT UPDATE ({CBB_column.Text.Trim()}) ON {table}  TO {userOrRole_name}";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = $"GRANT UPDATE ON {table}  TO {userOrRole_name}";
                        command.ExecuteNonQuery();
                    }    

                }
            }
            else
            {
                if (CBB_column.SelectedItem != null)
                {
                    check_update.Checked = false;
                    command.CommandText = $"GRANT UPDATE ({CBB_column.Text.Trim()})  ON {table}  TO {userOrRole_name} WITH GRANT OPTION";
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.CommandText = $"GRANT UPDATE ON {table}  TO {userOrRole_name}  WITH GRANT OPTION";
                    command.ExecuteNonQuery();
                }
            }

            if(check_delete_otp.Checked == false)
            {
                if (check_delete.Checked == true)
                {
                    command.CommandText = $"GRANT DELETE ON {table} TO {userOrRole_name}";
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                check_delete.Checked = false;
                command.CommandText = $"GRANT DELETE  ON {table} TO {userOrRole_name} WITH GRANT OPTION";
                command.ExecuteNonQuery();
            }
            MessageBox.Show("GRANT QUYEN THANH CONG");


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string userOrRole_name = cbb_table.Text.Trim();
            DataTable all_col = Connectionfunction.GetAll_colName(userOrRole_name);
            foreach (DataRow row in all_col.Rows)
            {
                CBB_column.Items.Add(row["COLUMN_NAME"].ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string selectedItem = box_user_role.SelectedItem.ToString();

            string selectedRole = box_user_role.SelectedItem.ToString();
            DataRow[] foundRows = all_role.Select($"ROLE = '{selectedRole}'");

            if (foundRows.Length > 0)
            {
                check_select_opt.Enabled = false;
                check_insert_opt.Enabled = false;
                check_update_otp.Enabled = false;
                check_delete_otp.Enabled = false;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Check_Priv form = new Check_Priv(box_user_role.Text.Trim().ToUpper());
            form.Show();
        }
    }
}
