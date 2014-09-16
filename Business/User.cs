using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDirectory.Business
{
    public class User
    {
        public string FirstName
        {get;set;}
        public string LastName
        { get; set; }
        public long Employee_Id
        { get; set; }
        public string Role
        { get; set; }
        public string Status
        { get; set; }
        public string Location
        { get; set; }
        public string Email
        { get; set; }
        
    }
}