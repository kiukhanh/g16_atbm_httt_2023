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
    public partial class Form_table_view : Form
    {
        DataTable tbl_table_view;
        DataTable tbl_table_view1;
        public string username_ { get; set; }
        public Form_table_view(string un)
        {
            InitializeComponent();
            username_ = un;
            Load_table();
            Load_view();
        }

        private void Load_table()
        {
            string sql = $"SELECT OWNER,TABLE_NAME,TABLESPACE_NAME FROM DBA_TABLES WHERE OWNER ='{username_.ToUpper()}' ";
            tbl_table_view = Connectionfunction.GetDataToTable(sql);
            dvg_table_view.DataSource = tbl_table_view;
        }
        private void Load_view()
        {
            string sql1 = $"SELECT OWNER,VIEW_NAME,TEXT FROM DBA_VIEWS  WHERE OWNER ='{username_.ToUpper()}'";
            tbl_table_view1 = Connectionfunction.GetDataToTable(sql1);
            DVG_VIEW.DataSource = tbl_table_view1;
        }
    }
}
