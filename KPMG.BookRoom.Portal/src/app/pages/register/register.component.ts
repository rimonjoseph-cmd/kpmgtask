import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authenticate/authentication.service';
interface ContactModel {
  id: string;
  firstName: string;
  username: string;
  lastName: string;
  // phone: string; // You can uncomment this line if you want to include the phone property
  email: string;
  password: string; // Corrected the typo in the property name
}
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
 
  registeredContact : ContactModel = {
    id: "",
    firstName: '',
    username : '',
    lastName : '',
    email:  '',
    password: ''
  };
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  constructor(private authenticateService : AuthenticationService,
    private router : Router){
  }
  register(){
    debugger;
    this.authenticateService.registerNewContact(this.registeredContact).subscribe((response :any) => {
      if(response.result){
        this.router.navigate(['login']);
      }
    });
  }
}
