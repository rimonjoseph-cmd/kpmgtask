import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { links } from '../environmentconfig';
import { BehaviorSubject, map, Observable, tap } from 'rxjs';
import { UserModel } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  logout()  {
    this.user = {
      firstname : '',
      role: '',
      unique_name: '',
      contactid: ''
    };
    this._isLoggedIn$.next(false);
    localStorage.removeItem(this.TOKEN_NAME);
  }
private _isLoggedIn$ = new BehaviorSubject<boolean>(false);
isLoggedIn$ = this._isLoggedIn$.asObservable();
private readonly TOKEN_NAME = 'token';
  user!: UserModel;
  
get token ():any {
  return localStorage.getItem(this.TOKEN_NAME);
}
  constructor(private http: HttpClient) { 
    this._isLoggedIn$.next(!!this.token);
    this.user = this.getUser(this.token);
  }

registerNewContact(obj:any){
  return this.http.post(links.contact.registernew,obj);
}
loginContact(obj : any){
  return this.http.post(links.contact.login, obj).pipe(
    tap((response: any) => {
        this._isLoggedIn$.next(true);
        localStorage.setItem(this.TOKEN_NAME, response.data); 
        this.user = this.getUser(response.data);
    })
);
}
private getUser(token : string) : UserModel{
  if(token == '' || token == undefined){
    return {
      firstname : '',
      role: '',
      unique_name: '',
      contactid: ''
    };
  }
  debugger;
  let v = JSON.parse(atob(token?.split('.')[1]));
  console.log(v);
  let y =  v as UserModel;
  console.log(y);

  return v as UserModel;
}
hasRole(role:string) :boolean{
  return this.user.role ==  role || false;
}
}
