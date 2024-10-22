import { Directive, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { AuthenticationService } from '../core/services/authenticate/authentication.service';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective  {

  @Input()
  set appHasRole(role:string){
    if(this.authenticateService.hasRole(role)){
      this.viewContainerRef.createEmbeddedView(this.templateRef);
    }else{
      this.viewContainerRef.clear();
    }

  }
  constructor(private templateRef: TemplateRef<any>, private viewContainerRef: ViewContainerRef,
    private authenticateService : AuthenticationService
  ) { }
}
