using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Models
{
    public class AdminDetails
    {
        public string Department { get; set; }//department
        public string OfficeLocation { get; set; }//kpmg_officelocation
    }

    public class EmployeeDetails
    {
        public string JobTitle { get; set; } //jobtitle 
        public string DateOfJoining { get; set; } //kpmg_dateofjoining
        public string EmployeeId { get; set; } //employeeid string
        public string EmergencyContact { get; set; } //telephone1
    }

    public class CleaningStaffDetails
    {
        public string AreaAssigned { get; set; }//kpmg_areaassigned
    }

    public class RegistrationContactTypeBased
    {
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public AdminDetails AdminDetails { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
        public CleaningStaffDetails CleaningStaffDetails { get; set; }
    }
}
