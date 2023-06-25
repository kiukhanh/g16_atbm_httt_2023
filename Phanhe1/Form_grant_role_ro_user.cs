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
    public partial class Form_grant_role_ro_user : Form
    {
        public Form_grant_role_ro_user()
        {
            InitializeComponent();
            Fill_comboBox();
        }
        private void Fill_comboBox()
        {
            // lấy tất cả role của username này
            DataTable all_role = Connectionfunction.GetRoles();
            foreach (DataRow row in all_role.Rows)
            {
                box_ROLE.Items.Add(row["ROLE"].ToString());
            }

            // lấy tất cả user của username này
            DataTable all_user = Connectionfunction.GetAllUsers_wasCreateByUser();
            foreach (DataRow row in all_user.Rows)
            {
                box_USER.Items.Add(row["USERNAME"].ToString());
            }
        }
        private void Run_SP_GrantRoleToUser_OR_Role()
        {
            String role = box_ROLE.Text.Trim();
            String user_OR_role = box_USER.Text.Trim();

            if (!role.Equals(user_OR_role))
            {
                Connectionfunction.grantRoleToUser_OR_Role(role, user_OR_role);
            }
        }
        

        private void button_check_Click(object sender, EventArgs e)
        {

            if (box_USER.Text.Trim().Length == 0 | box_ROLE.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Run_SP_GrantRoleToUser_OR_Role();
        }
    }
}
