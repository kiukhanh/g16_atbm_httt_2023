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

        private void show_Luong()
        {
            try
            {
                OracleCommand command = new OracleCommand();
                command.Connection = Connectionfunction.Con;
                command.CommandText = "COMPANY.DECRYPT_LUONG_temp";
                command.CommandType = System.Data.CommandType.StoredProcedure;


                command.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = taikhoan;
                command.Parameters.Add("p_Password", OracleDbType.Varchar2).Value = matkhau;
                OracleParameter decryptedLuongParam = new OracleParameter();
                decryptedLuongParam.ParameterName = "p_decryptedLuong";
                decryptedLuongParam.OracleDbType = OracleDbType.Varchar2;
                decryptedLuongParam.Direction = ParameterDirection.Output;
                decryptedLuongParam.Size = 2000;
                command.Parameters.Add(decryptedLuongParam);

                command.ExecuteNonQuery();

                string decryptedLuong = command.Parameters["p_decryptedLuong"].Value.ToString();
                decimal number = decimal.Parse(decryptedLuong);
                string formattedString = number.ToString("N");
                txt_luong.Text = formattedString;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void show_Phucap()
        {
            try
            {
                OracleCommand command = new OracleCommand();
                command.Connection = Connectionfunction.Con;
                command.CommandText = "COMPANY.DECRYPT_PHUCAP_temp";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = taikhoan;
                command.Parameters.Add("p_Password", OracleDbType.Varchar2).Value = matkhau;
                OracleParameter decryptedPCParam = new OracleParameter();
                decryptedPCParam.ParameterName = "p_Decrypted_Phucap";
                decryptedPCParam.OracleDbType = OracleDbType.Varchar2;
                decryptedPCParam.Direction = ParameterDirection.Output;
                decryptedPCParam.Size = 2000;
                command.Parameters.Add(decryptedPCParam);

                command.ExecuteNonQuery();

                string decryptedPhucap= command.Parameters["p_Decrypted_Phucap"].Value.ToString(); 
                decimal number = decimal.Parse(decryptedPhucap);
                string formattedString = number.ToString("N");
                txt_phucap.Text = formattedString;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Luong_PC_Load(object sender, EventArgs e)
        {
            show_Luong();
            show_Phucap();
        }
    }
}
