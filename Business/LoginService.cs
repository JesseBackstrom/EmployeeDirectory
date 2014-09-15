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
        public static bool AuthenticateUser(string email, string password)
        {

            MD5 md5Hash = MD5.Create();
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand("SP_GetPW", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

            EmployeeDatabaseConn.Open();
            byte[] data = (byte[])cmd.ExecuteScalar();
            string hashPass = BitConverter.ToString(data).Replace("-", "");

            if (hashPass.ToUpper().Equals(ConvertMD5(password).ToUpper()))
                return true;
            else
                return false;


        }
    }
}