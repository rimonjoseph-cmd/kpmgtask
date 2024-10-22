import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { AuthenticationService } from '../core/services/authenticate/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class IsAuthenticatedGuard implements CanActivate {
  constructor(private authenticateService : AuthenticationService,
    private route: Router
  ){
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.authenticateService.isLoggedIn$.pipe(
      tap((isloggedin) => {
        if(!isloggedin){
          this.route.navigate(['login']);
        }
      })
    );
  }
  
}
