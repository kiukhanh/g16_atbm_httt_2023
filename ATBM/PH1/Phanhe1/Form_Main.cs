using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanhe1
{
    public partial class Form_Main : Form
    {
        Thread t;
        String username = "", password = "";
        public Form_Main()
        {
            //this.username = un;
            //this.password= pw;
            InitializeComponent();
        }

        public void open_form_view(object obj)
        {

            Application.Run(new Form_View_User());
        }
        public void open_form_grantprivileges(object obj)
        {

            Application.Run(new Form_grant_userrole(username));
        }
        public void open_form_grantroletouser(object obj)
        {

            Application.Run(new Form_grant_role_ro_user());
        }
        public void open_form_thao_tac(object obj)
        {

            Application.Run(new Form_thao_tac());
        }
        public void open_form_revoke(object obj)
        {

            Application.Run(new Form_Revoke_Privs());
        }
        private void open_form_view_user_privs(object obj)
        {
            Application.Run(new Form_view_user_privs_1());
        }
        private void open_form_view_role_privs(object obj)
        {
            Application.Run(new Form_view_role_privs_1());
        }
        private void Form_Main_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        

        private void button_view_user_Click(object sender, EventArgs e)
        {
 
            t = new Thread(open_form_view);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void view_phan_quyen_Click(object sender, EventArgs e)
        {
            
            t = new Thread(open_form_grantprivileges);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void view_phan_role_Click(object sender, EventArgs e)
        {
            
            t = new Thread(open_form_grantroletouser);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void view_thao_tac_Click_1(object sender, EventArgs e)
        {
            
            t = new Thread(open_form_thao_tac);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void view_thu_hoi_Click(object sender, EventArgs e)
        {

            t = new Thread(open_form_revoke);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void button_view_information_Click(object sender, EventArgs e)
        {
            t = new Thread(open_form_view_user_privs);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void view_kiem_tra_Click(object sender, EventArgs e)
        {
            t = new Thread(open_form_view_role_privs);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }
    
    }
}
