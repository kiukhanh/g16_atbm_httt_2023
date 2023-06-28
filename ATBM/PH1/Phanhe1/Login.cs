using Oracle.ManagedDataAccess.Client;
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
    public partial class Login : Form
    {
        Thread t;

        String owner = "KHANH";
        public Login()
        {
            InitializeComponent();
        }
        private void Login_b(String username, String password)
        {

        }
        public void open_form_main(object obj)
        {

            //Application.Run(new Form_grant_userrole(username));
            Application.Run(new Form_Main());
        }

        // xử lí mở form main
        public void open_grant(object obj)
        {

            //Application.Run(new Form_grant_userrole(username));
            Application.Run(new Form_grant_role_ro_user());
        }

        private void buton_login_Click(object sender, EventArgs e)
        {

            // xử lí login
            String username = txt_username.Text.Trim();
            String password = txt_password.Text.Trim();
            Connectionfunction.InitConnection_DBA();
            string ora = "SELECT COUNT(*) FROM DBA_ROLE_PRIVS WHERE UPPER(GRANTEE) = '" + txt_username.Text.ToUpper() + "' AND UPPER(GRANTED_ROLE) = 'DBA'";
            Boolean check = Connectionfunction.check_username(ora);
            if (check == true)
            {
                try
                {
                    Connectionfunction.InitConnection(username,password);
                    if (username.Contains(username))
                    {
                        this.Hide();
                        t = new Thread(open_form_main);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();

                    }
                }
                catch(OracleException ex)
                {
                    MessageBox.Show(ex.Message);
                }
          


            }
            else
            {
                MessageBox.Show("This user isn't DBA");

            }
            txt_username.Clear();
            txt_password.Clear();





        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton_login_Click(sender, e);
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
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
