using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanhe1
{
    public partial class Form_view_role_privs_2 : Form
    {
        public Form_view_role_privs_2()
        {
            InitializeComponent();
        }
        public DataGridView GetDataGridView1()
        {
            return dataGridView1;
        }
        //public DataGridView GetDataGridView2() {  return dataGridView2;}
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
