using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanhe1.DBA_Func
{
    public partial class Check_Priv : Form
    {
        string box;
        public Check_Priv(string a)
        {
            InitializeComponent();
            box = a;
            Load();
        }
        DataTable all_privilegesOnTable;
        public void Load()
        {
            
            // Hien thi cac quyen ma user/role dang co
            all_privilegesOnTable = Connectionfunction.GetPrivilegeOnTable(box);
            dgv_check_privs.DataSource = all_privilegesOnTable;
        }
    }
}
