using Oracle.ManagedDataAccess.Client;
using Phanhe1.NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;
using Phanhe1.Nhân_sự;
using Phanhe2;
using WindowsFormsApp1;
using Phanhe1.Trường_phòng;
using System.Web.UI;

namespace Phanhe1
{
    public partial class Login : Form
    {
        Thread t;
        public string USERNAME_;
        String owner = "KHANH";
        string role;
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
            //Application.Run(new Form_Main(txt_username.Text));
            Application.Run(new Form_Main(USERNAME_));
        }
        public void open_form_main_nv(object obj)
        {

            //Application.Run(new Form_grant_userrole(username));
            Application.Run(new Form_MainNV());
        }
        public void open_form_main_ns(object obj)
        {

            Application.Run(new Form_Main_NS());
        }
        public void open_form_QL(object obj)
        {
            Application.Run(new Form_QL());
        }

        // xử lí mở form main
        public void open_grant(object obj)
        {

            Application.Run(new Form_grant_role_ro_user(USERNAME_));
        }
        public void open_form_TRUONG_PHONG(object obj)
        {
            Application.Run(new Form_Main_TP());
        }
        public void open_form_TC(object obj)
        {
            Application.Run(new Form_Main_TC());
        }
        public void open_form_TDA(object obj)
        {
            Application.Run(new Form_TDA());
        }

        public string getUsername()
        {
            return USERNAME_;
        }

        private void buton_login_Click(object sender, EventArgs e)
        {

            // xử lí login
            String username = txt_username.Text.Trim();
            String password = txt_password.Text.Trim();
            USERNAME_ = username;
            
            
            Connectionfunction.InitConnection_DBA();
            string ora = "SELECT COUNT(*) FROM DBA_ROLE_PRIVS WHERE UPPER(GRANTEE) = '" + txt_username.Text.ToUpper() + "' AND UPPER(GRANTED_ROLE) = 'DBA'";
            
            Boolean check = Connectionfunction.check_username(ora);
            if (check == true)
            {
                Connectionfunction.InitConnection(username, password);

                try
                {
                    if (username.Contains(username))
                    {
                        this.Hide();
                        t = new Thread(open_form_main);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();

                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                    string sql = "SELECT VAITRO FROM COMPANY.NHANVIEN WHERE MANV=:USERNAME";
                    OracleCommand command = new OracleCommand(sql, Connectionfunction.Con);
                    command.Parameters.Add(":USERNAME", OracleDbType.Varchar2).Value = username;
                    OracleDataReader reader = command.ExecuteReader();

                    bool isNVRole = false, isTCRole = false, isTDARole = false;
                    bool isNSRole = false, isQLRole = false, isTPRole = false;

                    while (reader.Read())
                    {
                        string role = reader["VAITRO"].ToString();
                        if (role == "NV")
                        {
                            isNVRole = true;
                            break;
                        }
                        else if (role == "NS")
                        {
                            isNSRole = true;
                            break;
                        }
                        else if (role == "QL")
                        {
                            isQLRole = true;
                            break;
                        }
                        else if (role == "TP")
                        {
                            isTPRole = true;
                            break;
                        }
                        else if (role == "TC")
                        {
                            isTCRole = true;
                            break;
                        }
                        else if (role == "TDA")
                        {
                            isTDARole = true;
                            break;
                        }
                    }

                    reader.Close();

                    if (isNVRole)
                    {
                        Connectionfunction.InitConnection(username, password);
                        try
                        {
                            if (username.Contains(username))
                            {
                                this.Hide();
                                t = new Thread(open_form_main_nv);
                                t.SetApartmentState(ApartmentState.STA);
                                t.Start();

                            }
                        }
                        catch (OracleException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (isNSRole)
                    {
                        Connectionfunction.InitConnection(username, password);
                        try
                        {
                            if (username.Contains(username))
                            {
                                this.Hide();
                                t = new Thread(open_form_main_ns);
                                t.SetApartmentState(ApartmentState.STA);
                                t.Start();

                            }
                        }
                        catch (OracleException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (isQLRole)
                    {
                        Connectionfunction.InitConnection(username, password);
                        try
                        {
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
                    else if (isTPRole)
                    {
                        Connectionfunction.InitConnection(username, password);
                        try
                        {
                            if (username.Contains(username))
                            {
                                this.Hide();
                                t = new Thread(open_form_TRUONG_PHONG);
                                t.SetApartmentState(ApartmentState.STA);
                                t.Start();

                            }
                        }
                        catch (OracleException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (isTCRole)
                    {
                        Connectionfunction.InitConnection(username, password);
                        try
                        {
                            if (username.Contains(username))
                            {
                                this.Hide();
                                t = new Thread(open_form_TC);
                                t.SetApartmentState(ApartmentState.STA);
                                t.Start();

                            }
                        }
                        catch (OracleException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (isTDARole)
                    {
                        Connectionfunction.InitConnection(username, password);
                        try
                        {
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
                    else
                    {
                        // Người dùng không có vai trò "NV"
                        MessageBox.Show("Người dùng không có vai trò NV");
                    }
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
