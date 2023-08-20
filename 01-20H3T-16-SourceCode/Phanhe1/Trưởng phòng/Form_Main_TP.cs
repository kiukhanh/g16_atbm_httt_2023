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

namespace Phanhe1.Trường_phòng
{
    public partial class Form_Main_TP : Form
    {
        public Form_Main_TP()
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
            main_tp_panel.Controls.Add(childForm);
            main_tp_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        
        

        DataTable table_NVTP = new DataTable();
        private void btn_nhanvien_Click_1(object sender, EventArgs e)
        {
            main_tp_panel.Hide();
            dgv_nhanvien_tp.Show();
            string sql = "SELECT * FROM COMPANY.NHANVIEN_TP";
            table_NVTP = Connectionfunction.GetDataToTable(sql);
            dgv_nhanvien_tp.DataSource= table_NVTP;
        }

        private void btn_canhan_Click(object sender, EventArgs e)
        {
            dgv_nhanvien_tp.Hide();
            main_tp_panel.Show();
            openChildForm(new Form_NV_NV());
        }

        private void btn_dean_Click(object sender, EventArgs e)
        {
            dgv_nhanvien_tp.Hide();
            main_tp_panel.Show();
            openChildForm(new Form_NV_DA());
        }

        private void btn_phongban_Click(object sender, EventArgs e)
        {
            dgv_nhanvien_tp.Hide();
            main_tp_panel.Show();
            openChildForm(new Form_NV_PB());
        }

        private void btn_phancong_Click(object sender, EventArgs e)
        {
            dgv_nhanvien_tp.Hide();
            main_tp_panel.Show();
            openChildForm(new FORM_TRUONG_PHONG());
        }
        
        private void Form_Main_TP_Load(object sender, EventArgs e)
        {
            btn_canhan.PerformClick();
            string query = "SELECT SYS_CONTEXT('USERENV','SESSION_USER') FROM DUAL";
            object value = Connectionfunction.GetDataToText(query);
            textBox_ID.Text = "ID: " + value.ToString();

        }
        /*-------------------NEW--------------------------*/
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
        }

    }

}
