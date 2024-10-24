import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authenticate/authentication.service';
import { RegistrationForm } from 'src/app/models/register.model';

@Component({
  selector: 'app-register-form-group',
  templateUrl: './register-form-group.component.html',
  styleUrls: ['./register-form-group.component.css']
})
export class RegisterFormGroupComponent {
  userTypes = [
    {name:'Administration', val: 1},
    {name:'Employee', val: 2},
    {name:'CleaningStaff', val: 3},
    ];
  registrationForm: FormGroup;
  isLoader: boolean = false;

  constructor(private formBuilder: FormBuilder, private authenticateService : AuthenticationService,
    private router : Router) {
    this.registrationForm = this.formBuilder.group({
      userType: [''],
      username: [''],
      email: [''],
      gender: [''],
      password: [''],
      passwordConfirm: [''],
      firstname: [''],
      lastname: [''],
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
  this.isLoader= true;

    if (this.registrationForm.valid) {
      // Implement registration logic here
      const formValues = this.registrationForm.value;
      const registrationForm: RegistrationForm = {
        userType: parseInt(formValues.userType, 10) - 1,
        email: formValues.email,
        password: formValues.password,
        gender: formValues.gender,
        firstname: formValues.firstname,
        lastname: formValues.lastname,
        username: formValues.username,
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
    this.authenticateService.register(registrationForm).subscribe((response : any) => {
      this.isLoader = false;
      if(response.result){
        this.router.navigate(['login']);
      }
    })
  }
}
}
