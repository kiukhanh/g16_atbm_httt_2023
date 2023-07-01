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
    public partial class Form_MainNV : Form
    {
        public Form_MainNV()
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
            main_nv_panel.Controls.Add(childForm);
            main_nv_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NV_NV());
        }

        private void Form_MainNV_Load(object sender, EventArgs e)
        {
            btn_nhanvien.PerformClick();
            string query = "SELECT SYS_CONTEXT('USERENV','SESSION_USER') FROM DUAL";
            object value = Connectionfunction.GetDataToText(query);
            textBox_ID.Text = "ID: " + value.ToString();
        }

        private void btn_phancong_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NV_PC());
        }

        private void btn_dean_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NV_DA());
        }

        private void btn_phongban_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NV_PB());
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
