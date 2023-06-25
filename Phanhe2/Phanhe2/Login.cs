using Phanhe2;
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
using Oracle.ManagedDataAccess.Client;

namespace Phanhe2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Thread t;
        public void open_form_QL(object obj)
        {
            Application.Run(new Form_QL());
        }
        public void open_form_TDA(object obj)
        {
            Application.Run(new Form_TDA());
        }
        private void buton_login_Click(object sender, EventArgs e)
        {
            String username = txt_username.Text.Trim();
            String password = txt_password.Text.Trim();
            Connection.InitConnection_DBA();
            string ora1 = "SELECT COUNT(*) FROM DBA_ROLE_PRIVS WHERE UPPER(GRANTEE) = '" + txt_username.Text.ToUpper() + "' AND UPPER(GRANTED_ROLE) = 'QL'";
            string ora2 = "SELECT COUNT(*) FROM DBA_ROLE_PRIVS WHERE UPPER(GRANTEE) = '" + txt_username.Text.ToUpper() + "' AND UPPER(GRANTED_ROLE) = 'TDA'";

            Boolean check1 = Connection.check_username(ora1);
            Boolean check2 = Connection.check_username(ora2);
            if (check1)
            {
                try
                {
                    Connection.InitConnection(username, password);
                    if (username.Contains(username))
                    {
                        this.Hide();
                        t = new Thread(open_form_QL);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (check2)
            {
                try
                {
                    Connection.InitConnection(username, password);
                    if (username.Contains(username))
                    {
                        this.Hide();
                        t = new Thread(open_form_TDA);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (check1 == false && check2 == false) 
            { 
                MessageBox.Show("This user isn't in system");
            }
            txt_username.Clear();
            txt_password.Clear();
        }

    }
}
