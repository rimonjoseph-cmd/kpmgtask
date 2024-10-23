import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuildingsComponent } from './pages/buildings/buildings.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { IsAuthenticatedGuard } from './guards/is-authenticated.guard';
import { HasroleGuard } from './guards/hasrole.guard';
import { BookroomComponent } from './pages/bookroom/bookroom.component';
import { AvailableRoomsComponent } from './pages/room/rooms/available-rooms/available-rooms.component';
import { BookroomviewComponent } from './pages/bookroom/bookroomview/bookroomview.component';
import { RegisterFormGroupComponent } from './pages/register/register-form-group/register-form-group.component';

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
    path : "mybooks",
    component: BookroomComponent,
    canActivate : [IsAuthenticatedGuard,HasroleGuard],
    data: {
      role: ['admin','employee']
    }
  },
  {
    path : "availablerooms",
    component: AvailableRoomsComponent,
    canActivate : [IsAuthenticatedGuard,HasroleGuard],
    data: {
      role: ['admin','employee']
    }
  },
  {
    path : "createroom",
    component: BookroomviewComponent,
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
  ,
  {
    path : "signup2",
    component: RegisterFormGroupComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
