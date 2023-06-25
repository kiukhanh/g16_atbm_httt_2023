using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Phanhe2
{
    internal class Connection
    {
        public static OracleConnection Con;
        public static void InitConnection(String username, String password)
        {
            String connectionString = @"Data Source=localhost:1521/XEPDB1" + ";User ID=" + username + ";Password=" + password;
            Con = new OracleConnection();
            Con.ConnectionString = connectionString;
            //Mở kết nối
            Con.Open();
            //Kiểm tra kết nối
            if (Con.State == ConnectionState.Open)
            {
                MessageBox.Show("Kết nối DB thành công");
            }
        }

        public static void InitConnection_DBA()
        {
            Con = new OracleConnection(); 
            String connectionString = @"Data Source=localhost:1521/XEPDB1;User ID=sys; Password=Oracle;DBA Privilege=SYSDBA;";
            Con.ConnectionString = connectionString;

            try
            {
                //Mở kết nối
                Con.Open();
            }
            catch (OracleException ex)
            {
                Con = null;
                throw new Exception(ex.Message);
                //MessageBox.Show("Không thể kết nối với DB");
            }
        }
        public static Boolean check_username(string ora)
        {

            using (OracleCommand command = new OracleCommand(ora, Con))
            {


                int userCount = Convert.ToInt32(command.ExecuteScalar());

                return userCount > 0 ? true : false;
            }
        }
        public static object GetDataToText(string ora)
        {
            object value = null;
            using (OracleCommand command = new OracleCommand(ora, Con))
            {
                value = command.ExecuteScalar();
            }
            return value;
        }
        public static DataTable GetDataToTable(string ora)
        {
            using (OracleCommand command = new OracleCommand(ora, Con))
            {
                using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}