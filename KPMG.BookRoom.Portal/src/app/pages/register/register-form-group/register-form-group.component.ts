import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistrationForm } from 'src/app/models/register.model';

@Component({
  selector: 'app-register-form-group',
  templateUrl: './register-form-group.component.html',
  styleUrls: ['./register-form-group.component.css']
})
export class RegisterFormGroupComponent {
  userTypes = ['Administration', 'Employee', 'CleaningStaff'];
  registrationForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.registrationForm = this.formBuilder.group({
      userType: [''],
      username: [''],
      email: [''],
      gender: [''],
      password: [''],
      passwordConfirm: [''],
      adminDetails: this.formBuilder.group({
        department: [''],
        role: [''],
        officeLocation: [''],
        phoneNumber: ['']
      }),
      employeeDetails: this.formBuilder.group({
        jobTitle: [''],
        dateOfJoining: [''],
        employeeId: [''],
        emergencyContact: ['']
      }),
      cleaningStaffDetails: this.formBuilder.group({
        areaAssigned: ['']
      })
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      // Implement registration logic here
      const formValues = this.registrationForm.value;
      const registrationForm: RegistrationForm = {
        userType: formValues.userType,
        email: formValues.email,
        password: formValues.password,
        gender: formValues.gender,
        adminDetails: {
            department: formValues.adminDetails.department,
            officeLocation: formValues.adminDetails.officeLocation,
        },
        employeeDetails: {
            jobTitle: formValues.employeeDetails.jobTitle,
            dateOfJoining: formValues.employeeDetails.dateOfJoining,
            employeeId: formValues.employeeDetails.employeeId,
            emergencyContact: formValues.employeeDetails.emergencyContact,
        },
        cleaningStaffDetails: {
            areaAssigned: formValues.cleaningStaffDetails.areaAssigned,
        }
    };
    console.log(registrationForm);
  }
}
}
