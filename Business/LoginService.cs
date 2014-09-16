using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;

namespace EmployeeDirectory.Business
{
    public static class LoginService
    {
        private static string ConvertMD5(string input)
        {
            // Encrypt a given string with Md5
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // return the hex
            return sBuilder.ToString();
        }

        public static bool isUniqueID(long ID)
        {
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_EmployeeIdIsUnique", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = ID;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            if (cmd.ExecuteScalar() == null)
                return true;
            else
                return false;
        }

        public static void updateUser(string FirstName, string LastName, long Employee_ID, int Role, int Location, string email, int Status)
        {

            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_UpdateAccount", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = Employee_ID;
            cmd.Parameters.Add("@Role", SqlDbType.SmallInt).Value = Role;
            cmd.Parameters.Add("@Location", SqlDbType.SmallInt).Value = Location;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = Status;

            //open the connection, execute
            EmployeeDatabaseConn.Open();
            cmd.ExecuteNonQuery();
            EmployeeDatabaseConn.Close();
        }

        public static void UpdatePassword(string password, long Employee_Id)
        {
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_UpdatePassword", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = Employee_Id;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

            //open the connection, execute
            EmployeeDatabaseConn.Open();
            cmd.ExecuteNonQuery();
            EmployeeDatabaseConn.Close();
        }

        public static User AuthenticateUser(long ID, string password)
        {
            //Checks the database to see if the given email/password matches any available records

            //Returns the role of the user to confirm success and inform authentication
            
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetEmployee", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = ID;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            byte[] data = null;

            //create a new User object to pass the results into
            User currentUser = new User();
            while (reader.Read())
            {
                if (!(reader["EmpPassword"] is DBNull))
                    data = (byte[])reader["EmpPassword"];
                currentUser.Role = (string)reader["Role"];
                currentUser.Status = (string)reader["Status"];
                currentUser.FirstName = (string)reader["FirstName"];
                currentUser.LastName = (string)reader["LastName"];
                currentUser.Location = (string)reader["Location"];
                currentUser.Email = (string)reader["Email"];
                currentUser.Employee_Id = (long)reader["Employee_ID"];
            }
            EmployeeDatabaseConn.Close();
            if (!(data == null))
            {
                string hashPass = BitConverter.ToString(data).Replace("-", "");

                //compare and return the User if they match, null if they don't
                if (hashPass.ToUpper().Equals(ConvertMD5(password).ToUpper()))
                    return currentUser;
                else
                    return null;
            }

            return currentUser;


        }
    }
}