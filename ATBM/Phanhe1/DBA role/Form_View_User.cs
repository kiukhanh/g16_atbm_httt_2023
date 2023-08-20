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
    public partial class Form_View_User : Form
    {
        DataTable dtTableName = new DataTable();
        public Form_View_User()
        {
            InitializeComponent();
        }

        private void Load_data()
        {
            string sql = "SELECT USERNAME, USER_ID, ACCOUNT_STATUS, CREATED  FROM dba_users WHERE ACCOUNT_STATUS = 'OPEN' ORDER BY CREATED DESC";
            dtTableName = Connectionfunction.GetDataToTable(sql);
            dtg_view_user.DataSource = dtTableName;
            
            //Không cho người dùng thêm dữ liệu trực tiếp
            dtg_view_user.AllowUserToAddRows = false;
            dtg_view_user.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Form_View_User_Load(object sender, EventArgs e)
        {
            Load_data();
        }

       
    }
}
