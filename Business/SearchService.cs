using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace EmployeeDirectory.Business
{
    public class SearchService
    {
        public static string getRole(int id)
        {
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetRole", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            return (string)cmd.ExecuteScalar();
        }
        public static int getRoleID(string parameter)
        {
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetRoleID", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Role", SqlDbType.VarChar).Value = parameter;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            return (int)cmd.ExecuteScalar();
        }
        public static int getStatusID(string parameter)
        {
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetStatusID", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = parameter;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            return (int)cmd.ExecuteScalar();
        }
        public static int getLocationID(string parameter)
        {
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetLocationID", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = parameter;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            return (int)cmd.ExecuteScalar();
        }
        public static string getLocation(int id)
        {
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetLocation", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            return (string)cmd.ExecuteScalar();
        }
        public static string getStatus(int id)
        {
            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetStatus", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            return (string)cmd.ExecuteScalar();
        }
        public static DataSet search(string FirstName, string LastName, string email, long Employee_ID, int Location, int Role, int Status)
        {
            //returns a datatable containing the locations from the database

            DataSet results = new DataSet();

            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_SearchEmployee", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(FirstName))
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            if (string.IsNullOrEmpty(LastName))
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            if (string.IsNullOrEmpty(email))
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
            if (Location == 0)
                cmd.Parameters.Add("@Location", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Location", SqlDbType.SmallInt).Value = Location;
            if (Role == 0)
                cmd.Parameters.Add("@Role", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Role", SqlDbType.SmallInt).Value = Role;
            if (Status == 0)
                cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = Status;
            if (Employee_ID == 0)
                cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = Employee_ID;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            
            adapter.Fill(results);

            EmployeeDatabaseConn.Close();

            return results;
        }
    }
}