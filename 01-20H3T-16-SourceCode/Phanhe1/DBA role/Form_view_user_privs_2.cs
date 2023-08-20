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
    public partial class Form_view_user_privs_2 : Form
    {
        public DataGridView GetDataGridView1()
        {
           
            return dataGridView1;
        }

        /*//public DataGridView GetDataGridView2()
        {

            //return dataGridView2;
        }*/


        public Form_view_user_privs_2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
