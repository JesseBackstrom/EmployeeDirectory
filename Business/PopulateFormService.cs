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
    public class PopulateFormService
    {
        public static DataTable getLocations()
        {
            //returns a datatable containing the locations from the database

            DataTable results = new DataTable();
            results.Columns.Add("Value");
            results.Columns.Add("Text");

            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetLocations", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                results.Rows.Add(reader[0], reader[1]);
            }

            EmployeeDatabaseConn.Close();

            return results;

        }

        public static DataTable getRoles()
        {
            //returns a datatable containing the locations from the database

            DataTable results = new DataTable();
            results.Columns.Add("Value");
            results.Columns.Add("Text");

            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetRoles", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                results.Rows.Add(reader[0], reader[1]);
            }

            EmployeeDatabaseConn.Close();

            return results;

        }

        public static DataTable getStatuses()
        {
            //returns a datatable containing the Statuses from the database

            DataTable results = new DataTable();
            results.Columns.Add("Value");
            results.Columns.Add("Text");

            //setup the connection
            string connString = ConfigurationManager.ConnectionStrings["EmpDirConn"].ConnectionString;
            SqlConnection EmployeeDatabaseConn = new SqlConnection(connString);

            //select the stored procedure and add parameters
            SqlCommand cmd = new SqlCommand("SP_GetStatuses", EmployeeDatabaseConn);
            cmd.CommandType = CommandType.StoredProcedure;

            //open the connection, execute, and convert to the necessary format
            EmployeeDatabaseConn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                results.Rows.Add(reader[0], reader[1]);
            }

            EmployeeDatabaseConn.Close();

            return results;

        }
    }
}