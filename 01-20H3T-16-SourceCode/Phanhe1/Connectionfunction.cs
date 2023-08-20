using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Web.UI.WebControls;
using ChangePasswordForm;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace Phanhe1
{
    internal class Connectionfunction
    {
        public static OracleConnection Con;
        public static bool check_changepwd = false;

        private static string host_name = @"DESKTOP-2HQ1IDD";
        //String connectionString = @"DATA SOURCE = localhost:1521/XE; USER ID=sys;PASSWORD=admin;DBA Privilege=SYSDBA;Pooling=false;";

        public static void InitConnection(String username, String password)
        {
            String connectionString = @"Data Source=localhost:1521/XEPDB1" + ";User ID=" + username.ToUpper() + ";Password=" + password;
            Con = new OracleConnection();
            Con.ConnectionString = connectionString;
            int login_Count = 0;
            
            try
            {
                Con.Open();
            }
            catch {
                MessageBox.Show("Sai thông tin hoặc mật khẩu!!","Thông Báo");
            }
            try
            {
                //Mở kết nối
                
                string ora = "SELECT MAX(login_count) FROM COMPANY.USER_LOGIN_HISTORY WHERE UPPER(USERNAME) = '" + username.ToUpper() +"'";
                using (OracleCommand command = new OracleCommand(ora, Con))
                {

                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        login_Count = Convert.ToInt32(result);
                    }
                    
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
                   
                
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {

                    MessageBox.Show("Đăng nhập thành công!!", "Thông Báo");
                }
            }

        }
        

        public static void InitConnection_DBA()
        {
            String connectionString = @"Data Source=localhost:1521/XEPDB1;User ID = sys; Password= 20120305;DBA Privilege=SYSDBA;";
            Con = new OracleConnection();
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

       

        public static string GetFieldValues(string ora)
        {
            using (OracleCommand cmd = new OracleCommand(ora, Con))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    string ma = "";
                    while (reader.Read())
                    {
                        ma = reader.GetValue(0).ToString();
                    }
                    return ma;
                }
            }
        }

        public static void RunORA(string ora)
        {
            using (OracleCommand cmd = new OracleCommand(ora, Con))
            {
                //try
                //{
                    cmd.ExecuteNonQuery();
                
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
            }
        }
        public static bool RunSql(string sql)
        {
            using (OracleCommand cmd = new OracleCommand(sql, Con))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    return true; // SQL executed successfully
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error executing SQL: " + ex.ToString());
                    return false; // SQL execution failed
                }
            }
        }
        public static int RunORAwithResult(string ora)
        {

            using (OracleCommand cmd = new OracleCommand(ora, Con))
            {
                try
                {
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return 0;
                }
            }
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


        public static DataTable GetAllTableName()
        {

            OracleCommand command = new OracleCommand();
            command.CommandText = $"SELECT TABLE_NAME FROM ALL_TABLES WHERE UPPER(OWNER) LIKE SYS_CONTEXT('USERENV','SESSION_USER')";
            command.Connection = Con;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable dataTable = new DataTable(); //create a new table
            adapter.Fill(dataTable);
            return dataTable;

        }
        public static DataTable GetAll_colName(string table)
        {

            OracleCommand command = new OracleCommand();
            command.CommandText = $"SELECT COLUMN_NAME FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = '{table}'";
            command.Connection = Con;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable dataTable = new DataTable(); //create a new table
            adapter.Fill(dataTable);
            return dataTable;

        }
        public static DataTable GetPrivilegeOnTable(String username) // lất tất cả các quyền trên bảng của 1 user
        {
            username = username.ToUpper();
            OracleCommand command = new OracleCommand();
            command.CommandText = $"SELECT GRANTEE,TABLE_NAME,GRANTOR,PRIVILEGE,GRANTABLE,HIERARCHY,TYPE,INHERITED\r\n  FROM DBA_TAB_PRIVS  \r\n WHERE GRANTEE IN (SELECT granted_role \r\n FROM DBA_ROLE_PRIVS \r\n WHERE GRANTEE = '{username}')\r\nUNION \r\nSELECT GRANTEE,TABLE_NAME,GRANTOR,PRIVILEGE,GRANTABLE,HIERARCHY,TYPE,INHERITED\r\n  FROM DBA_TAB_PRIVS \r\n WHERE GRANTEE = '{username}'";
            command.Connection = Con;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable dataTable = new DataTable(); //create a new table
            adapter.Fill(dataTable);

            return dataTable;
        }

        public static DataTable GetAllRoles()
        {
            OracleCommand command = new OracleCommand();
            command.CommandText = "SELECT ROLE, ROLE_ID " +
                "FROM USER_ROLE_PRIVS US JOIN DBA_ROLES DR ON DR.ROLE = US.GRANTED_ROLE " +
                "WHERE DR.ROLE <> 'CONNECT' AND DR.ROLE <> 'RESOURCE' AND DR.ROLE <> 'DBA'";
            command.Connection = Con;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable dataTable = new DataTable(); //create a new table
            adapter.Fill(dataTable);

            return dataTable;
        }

        public static DataTable GetRoles(string usn)
        {
            OracleCommand command = new OracleCommand();
            command.CommandText = $"SELECT granted_role FROM dba_role_privs WHERE grantee = '{usn.ToUpper()}'";
            command.Connection = Con;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable dataTable = new DataTable(); //create a new table
            adapter.Fill(dataTable);

            return dataTable;
        }
        public static DataTable GetAllUsers_wasCreateByUser()
        {
            OracleCommand command = new OracleCommand();
            command.CommandText = $"SELECT USERNAME FROM DBA_USERS WHERE ACCOUNT_STATUS = 'OPEN' AND USERNAME  NOT LIKE '%SYS%'";
            command.Connection = Con;

            OracleDataAdapter adapter;
            DataTable dataTable;
            try
            {
                adapter = new OracleDataAdapter(command);
                dataTable = new DataTable(); //create a new table
                adapter.Fill(dataTable);
            }
            catch (OracleException ex)
            {
                throw new Exception(ex.Message);
            }

            return dataTable;
        }

       


        //Ham kiem tra xem role co ton tai trong he thong hay khong
        public static String CheckIfUserOrRoleExist(String userOrRole_name)
        {
            userOrRole_name = userOrRole_name.ToUpper();
            string result = "";


            //Kiem tra xem user co ton tai hay khong
            OracleCommand command1 = new OracleCommand();
            command1.CommandText = $"SELECT USERNAME FROM DBA_USERS";
            command1.Connection = Con;

            OracleDataAdapter adapter1 = new OracleDataAdapter(command1);
            DataTable dataTable1 = new DataTable(); //create a new table
            adapter1.Fill(dataTable1);

            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                if (dataTable1.Rows[i].Field<string>(0) == userOrRole_name)
                {
                    result = "User";
                    return result;
                }

            }

            //Kiem tra xem role co ton tai hay khong
            OracleCommand command2 = new OracleCommand();
            command2.CommandText = $"SELECT ROLE FROM DBA_ROLES";
            command2.Connection = Con;

            OracleDataAdapter adapter2 = new OracleDataAdapter(command2);
            DataTable dataTable2 = new DataTable(); //create a new table
            adapter2.Fill(dataTable2);

            for (int i = 0; i < dataTable2.Rows.Count; i++)
            {
                if (dataTable2.Rows[i].Field<string>(0) == userOrRole_name)
                {
                    result = "Role";
                    return result;
                }

            }

            result = "NoExist";
            return result;
        }


        public static void RevokeRoleFromUser_OR_Role(String role, String user_OR_role) // thu hồi quyền
        {
            role = role.ToUpper();
            user_OR_role = user_OR_role.ToUpper();


            OracleCommand command = new OracleCommand();
            command.CommandText = $"REVOKE {role} FROM {user_OR_role}";
            command.Connection = Con;
            command.ExecuteNonQuery();
            MessageBox.Show("Thu hoi quyen thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        
        //Ham Ktra xem quyen nay co thuoc ve user hay khong
        public static string CheckIfPrivilegeBelongToUser(String user_name, String table_name, String priv, String grant_opt)
        {
            user_name = user_name.ToUpper();
            table_name = table_name.ToUpper();
            priv = priv.ToUpper();
            grant_opt = grant_opt.ToUpper();
            string result = "";

            OracleCommand command1 = new OracleCommand();
            command1.CommandText = $"SELECT GRANTEE FROM DBA_TAB_PRIVS WHERE GRANTEE = '{user_name}' AND TABLE_NAME = '{table_name}' AND PRIVILEGE = '{priv}' AND GRANTABLE = '{grant_opt}'";
            command1.Connection = Con;

            OracleDataAdapter adapter1 = new OracleDataAdapter(command1);
            DataTable dataTable1 = new DataTable(); //create a new table
            adapter1.Fill(dataTable1);

            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                if (dataTable1.Rows[i].Field<string>(0) == user_name)
                {
                    result = "Yes";
                    return result;
                }
            }
            result = "No";
            return result;
        }

        //Ham ktra xem quyen nay co thuoc ve role dang xet hay khong
        public static string CheckIfPrivilegeBelongToRole(String role_name, String roleTable_name, String priv, String grant_opt)
        {
            role_name = role_name.ToUpper();
            roleTable_name = roleTable_name.ToUpper();
            priv = priv.ToUpper();
            grant_opt = grant_opt.ToUpper();
            string result = "";


            OracleCommand command1 = new OracleCommand();
            command1.CommandText = $"SELECT ROLE FROM ROLE_TAB_PRIVS WHERE ROLE = '{role_name}' AND TABLE_NAME = '{roleTable_name}' AND PRIVILEGE = '{priv}'";
            command1.Connection = Con;
            //command1.ExecuteNonQuery();

            OracleDataAdapter adapter1 = new OracleDataAdapter(command1);
            DataTable dataTable1 = new DataTable(); //create a new table
            adapter1.Fill(dataTable1);

            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                if (dataTable1.Rows[i].Field<string>(0) == role_name)
                {
                    result = "Yes";
                    return result;
                }
            }
            result = "No";

            return result;
        }

        //Ham revoke quyen bat ky ra khoi user/role
        public static void RevokePrivs(String table_name, String userOrRole_name, String priv)
        {
            table_name = table_name.ToUpper();
            userOrRole_name = userOrRole_name.ToUpper();
            priv = priv.ToUpper();

            OracleCommand command = new OracleCommand();
            command.CommandText = $"REVOKE {priv} ON {table_name} FROM {userOrRole_name}";
            command.Connection = Con;
            command.ExecuteNonQuery();


        }

        //Ham grant quyen bat ky cho user/role
        public static void GrantPrivs(String table_name, String userOrRole_name, String priv, string grant_opt)
        {
            table_name = table_name.ToUpper();
            userOrRole_name = userOrRole_name.ToUpper();
            priv = priv.ToUpper();
            grant_opt = grant_opt.ToUpper();

            OracleCommand command = new OracleCommand();
            command.CommandText = $"GRANT {priv} ON {table_name} TO {userOrRole_name} {grant_opt}";
            command.Connection = Con;
            command.ExecuteNonQuery();

        }


        //SP gan role cho user/role
        public static void grantRoleToUser_OR_Role(String role, String user_OR_role)
        {
            role = role.ToUpper();
            user_OR_role = user_OR_role.ToUpper();


            OracleCommand command = new OracleCommand();
            command.CommandText = $"GRANT {role} TO {user_OR_role}";
            command.Connection = Con;
            command.ExecuteNonQuery();

            MessageBox.Show("Cap quyen thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static int isUserValid(string username) // Hàm kiểm tra User có tồn tại hay không
        {
            OracleCommand cmd = new OracleCommand();

            //Gán kết nối
            cmd.Connection = Con;

            //Gán lệnh SQL
            string sql = "SELECT * FROM ALL_USERS WHERE USERNAME = " + "'" + username + "'";
            cmd.CommandText = sql;

            //Kiểm tra
            OracleDataReader reader = cmd.ExecuteReader();
            //bool exists = Convert.ToBoolean(cmd.ExecuteScalar());

            if (reader.Read())
            {
                //Giải phóng bộ nhớ
                cmd.Dispose();
                cmd = null;
                return 1;
            }
            else
            {
                //Giải phóng bộ nhớ
                cmd.Dispose();
                cmd = null;
                return 0;
            }
        }

        public static string cmd_reader_1row_1col(string cmd_reader)
        {
            string result;
            OracleCommand command = new OracleCommand();
            command.CommandText = cmd_reader;
            command.Connection = Con;
            OracleDataReader reader = command.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {

                    if (reader.GetValue(0).ToString() != null)
                    {
                        result = reader.GetValue(0).ToString();
                        return result;
                    }
                    else { break; }
                }
            }
            return "";
        }


    }
}
