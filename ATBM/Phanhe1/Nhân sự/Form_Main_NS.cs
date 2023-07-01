using Phanhe1.Nhân_sự;
using Phanhe1.NhanVien;
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
    public partial class Form_Main_NS : Form
    {
        public Form_Main_NS()
        {
            InitializeComponent();
            
        }
        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            main_ns_panel.Controls.Add(childForm);
            main_ns_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

       
        private void Form_Main_NS_Load(object sender, EventArgs e)
        {
            btn_nhanvien_ns.PerformClick();
            string query = "SELECT SYS_CONTEXT('USERENV','SESSION_USER') FROM DUAL";
            object value = Connectionfunction.GetDataToText(query);
            txt_ID.Text = "ID: " + value.ToString();
        }

        private void btn_nhanvien_ns_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NS_NV());
        }

        private void btn_phongban_ns_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NS_PB());
        }

        private void btn_dean_ns_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NV_DA());
        }

        private void btn_phancong_ns_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NV_PC());
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
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
