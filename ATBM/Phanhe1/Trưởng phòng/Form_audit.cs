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
    public partial class Form_audit : Form
    {
        DataTable dtTableName = new DataTable();
        DataTable dtTableName2 = new DataTable();
        public Form_audit()
        {
            InitializeComponent();
        }

        private void Load_data()
        {
            string sql = "SELECT * FROM UNIFIED_AUDIT_TRAIL WHERE AUDIT_TYPE = 'FineGrainedAudit'";
            dtTableName = Connectionfunction.GetDataToTable(sql);
            dataGridView2.DataSource = dtTableName;

            string sql2 = "SELECT * FROM UNIFIED_AUDIT_TRAIL WHERE AUDIT_TYPE = 'Standard'";
            dtTableName2 = Connectionfunction.GetDataToTable(sql2);
            dataGridView1.DataSource = dtTableName2;
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
