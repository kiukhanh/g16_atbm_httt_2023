using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanhe1.Giám_đốc_thông_báo
{
    public partial class Form_GD_TB : Form
    {
        DataTable dtb = new DataTable();
        public Form_GD_TB()
        {
            InitializeComponent();
        }

        private void Loadannouncements()
        {
            string sql1 = "SELECT MESSAGE FROM COMPANY.ANNOUNCEMENTS";

            dtb = Connectionfunction.GetDataToTable(sql1);
            dgv_announcemnet.DataSource = dtb;
        }


        private void Form_GD_TB_Load(object sender, EventArgs e)
        {
            Loadannouncements();
        }
    }
}
