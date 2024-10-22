import { Component } from '@angular/core';
import { AuthenticationService } from './core/services/authenticate/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'KPMG.BookRoom.Portal';
  constructor(private authicateService : AuthenticationService, private route: Router){}

  onLogout() {
    localStorage.removeItem('token');
    localStorage.clear();
    this.authicateService.logout();
    this.route.navigate(['login']);
  //   .subscribe( s => {
       
  //  });
  }
}
