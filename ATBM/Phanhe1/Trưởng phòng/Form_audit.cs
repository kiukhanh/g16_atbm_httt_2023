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
    public partial class Form_audit : Form
    {
        DataTable dtTableName = new DataTable();
        public Form_audit()
        {
            InitializeComponent();
        }

        private void Load_data()
        {
            string sql = "SELECT * FROM DBA_COMMON_AUDIT_TRAIL";
            dtTableName = Connectionfunction.GetDataToTable(sql);
            dataGridView1.DataSource = dtTableName;
        }
        private void Form_View_User_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
