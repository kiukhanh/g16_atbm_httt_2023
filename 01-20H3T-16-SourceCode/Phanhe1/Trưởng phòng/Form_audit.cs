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
using static System.ComponentModel.Design.ObjectSelectorEditor;

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


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            string sql = "SELECT SESSIONID, OS_USERNAME, USERHOST, INSTANCE_ID, DBID, AUTHENTICATION_TYPE, DBUSERNAME, CLIENT_PROGRAM_NAME, ENTRY_ID,STATEMENT_ID ,EVENT_TIMESTAMP ,EVENT_TIMESTAMP_UTC ,ACTION_NAME ,OS_PROCESS ,SCN ,EXECUTION_ID ,OBJECT_SCHEMA ,OBJECT_NAME ,SQL_TEXT ,CURRENT_USER ,ADDITIONAL_INFO ,UNIFIED_AUDIT_POLICIES ,FGA_POLICY_NAME  FROM UNIFIED_AUDIT_TRAIL WHERE AUDIT_TYPE = 'Standard'";
            dtTableName = Connectionfunction.GetDataToTable(sql);
            dataGridView1.DataSource = dtTableName;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            string sql = "SELECT SESSIONID, OS_USERNAME, USERHOST, INSTANCE_ID, DBID, AUTHENTICATION_TYPE, DBUSERNAME, CLIENT_PROGRAM_NAME, ENTRY_ID,STATEMENT_ID ,EVENT_TIMESTAMP ,EVENT_TIMESTAMP_UTC ,ACTION_NAME ,OS_PROCESS ,SCN ,EXECUTION_ID ,OBJECT_SCHEMA ,OBJECT_NAME ,SQL_TEXT ,CURRENT_USER ,ADDITIONAL_INFO ,UNIFIED_AUDIT_POLICIES ,FGA_POLICY_NAME FROM UNIFIED_AUDIT_TRAIL WHERE AUDIT_TYPE = 'FineGrainedAudit'";
            dtTableName = Connectionfunction.GetDataToTable(sql);
            dataGridView1.DataSource = dtTableName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            string sql = "SELECT * FROM COMPANY.aud_LUONG ORDER BY action_date DESC";
            dtTableName = Connectionfunction.GetDataToTable(sql);
            dataGridView1.DataSource = dtTableName;
        }
    }
}
