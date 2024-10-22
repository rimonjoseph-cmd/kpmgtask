import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../core/services/authenticate/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class HasroleGuard implements CanActivate {
  constructor(private authenticateService : AuthenticationService,
    private router : Router){
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    debugger;
      //return this.authenticateService.user.role.includes(route.data['role']);
      let r =  this.authenticateService.user.role == route.data['role'];
      let u =  route.data['role'].includes(this.authenticateService.user.role);
      let isauthorized = u;
      if(!isauthorized){
        this.router.navigate(['']);
      }
      return isauthorized;
  }
  
}
