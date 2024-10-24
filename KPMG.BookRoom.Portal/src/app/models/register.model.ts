export interface AdminDetails {
    department: string;
    officeLocation: string;
}

export interface EmployeeDetails {
    jobTitle: string;
    dateOfJoining: string;
    employeeId: string;
    emergencyContact: string;
}

export interface CleaningStaffDetails {
    areaAssigned: string;
}

export interface RegistrationForm {
    userType: number;
    email: string;
    password: string;
    gender: string;
    firstname: string;
    lastname: string;
    username:string;
    adminDetails: AdminDetails;
    employeeDetails: EmployeeDetails;
    cleaningStaffDetails: CleaningStaffDetails;
}