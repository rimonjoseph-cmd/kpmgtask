import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authenticate/authentication.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  loginContact  = {
    username: '',
    password: ''
  };
  constructor(private authenticateService : AuthenticationService,
    private router : Router){
  }
  ngOnInit(): void {
  }
  login(){
    debugger;
    this.authenticateService.loginContact(this.loginContact).subscribe((response : any) => {
      if(response.result){
        debugger;
        this.router.navigate(['/']);
      }
    })
  }

}
