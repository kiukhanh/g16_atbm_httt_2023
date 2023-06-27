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
            string sql = "SELECT SESSIONID, OS_USERNAME, USERHOST, INSTANCE_ID, DBID, AUTHENTICATION_TYPE, DBUSERNAME, CLIENT_PROGRAM_NAME, ENTRY_ID,STATEMENT_ID ,EVENT_TIMESTAMP ,EVENT_TIMESTAMP_UTC ,ACTION_NAME ,OS_PROCESS ,SCN ,EXECUTION_ID ,OBJECT_SCHEMA ,OBJECT_NAME ,SQL_TEXT ,CURRENT_USER ,ADDITIONAL_INFO ,UNIFIED_AUDIT_POLICIES ,FGA_POLICY_NAME  FROM UNIFIED_AUDIT_TRAIL WHERE AUDIT_TYPE = 'FineGrainedAudit'";
            dtTableName = Connectionfunction.GetDataToTable(sql);
            dataGridView2.DataSource = dtTableName;

            string sql2 = "SELECT SESSIONID, OS_USERNAME, USERHOST, INSTANCE_ID, DBID, AUTHENTICATION_TYPE, DBUSERNAME, CLIENT_PROGRAM_NAME, ENTRY_ID,STATEMENT_ID ,EVENT_TIMESTAMP ,EVENT_TIMESTAMP_UTC ,ACTION_NAME ,OS_PROCESS ,SCN ,EXECUTION_ID ,OBJECT_SCHEMA ,OBJECT_NAME ,SQL_TEXT ,CURRENT_USER ,ADDITIONAL_INFO ,UNIFIED_AUDIT_POLICIES ,FGA_POLICY_NAME FROM UNIFIED_AUDIT_TRAIL WHERE AUDIT_TYPE = 'Standard'";
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
