using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanhe1.NhanVien
{
    public partial class Form_Luong_PC : Form
    {
        private string taikhoan,matkhau;
        public Form_Luong_PC(string tk, string mk)
        {
            InitializeComponent();
            taikhoan= tk;
            matkhau= mk;
        }

        private void Form_Luong_PC_Load(object sender, EventArgs e)
        {
            
            try
            {
                OracleCommand command = new OracleCommand();
                command.Connection = Connectionfunction.Con; 
                command.CommandText = "COMPANY.DECRYPT_LUONG";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = taikhoan;
                command.Parameters.Add("p_Password", OracleDbType.Varchar2).Value = matkhau;

                command.Parameters.Add("result", OracleDbType.Varchar2, 2000).Direction = System.Data.ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                string decryptedLuong = command.Parameters["result"].Value.ToString();
                txt_luong.Text = decryptedLuong;
            }
            
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
    }
}
