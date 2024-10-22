import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuildingsComponent } from './pages/buildings/buildings.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { IsAuthenticatedGuard } from './guards/is-authenticated.guard';
import { HasroleGuard } from './guards/hasrole.guard';

const routes: Routes = [
  {
    path : "buildings",
    component: BuildingsComponent,
    canActivate : [IsAuthenticatedGuard,HasroleGuard],
    data: {
      role: ['admin','employee']
    }
  },
  {
    path : "login",
    component: LoginComponent
  }
  ,
  {
    path : "signup",
    component: RegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
