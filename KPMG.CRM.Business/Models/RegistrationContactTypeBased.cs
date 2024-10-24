using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Models
{

   public enum contactRoleEnum
    {
        admin = 0,
        employee = 1,
        cleaningstaff = 2
    }
    public class AdminDetails
    {
        public string department { get; set; }//department
        public string officeLocation { get; set; }//kpmg_officelocation
    }

    public class EmployeeDetails
    {
        public string jobTitle { get; set; } //jobtitle 
        public string employeeId { get; set; } //employeeid string
        public string emergencyContact { get; set; } //telephone1
    }

    public class CleaningStaffDetails
    {
        public string areaAssigned { get; set; }//kpmg_areaassigned
    }

    public class RegistrationContactTypeBased
    {
        public string? id { get; set; }
        public contactRoleEnum userType { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? gender { get; set; }
        public string? firstName { get; set; }
        public string? username { get; set; }
        public string? lastName { get; set; }
        public AdminDetails? adminDetails { get; set; }
        public EmployeeDetails? employeeDetails { get; set; }
        public CleaningStaffDetails? cleaningStaffDetails { get; set; }
    }
}
