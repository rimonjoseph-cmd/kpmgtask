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
import { CleaningStaffDashboardComponent } from './pages/Dashboards/cleaning-staff-dashboard/cleaning-staff-dashboard.component';
import { AllRoomsComponent } from './pages/room/all-rooms/all-rooms.component';

const routes: Routes = [
  {
    path : "",
    component: LoginComponent,
    canActivate : [IsAuthenticatedGuard],
  },
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
    path : "createbook",
    component: BookroomviewComponent,
    canActivate : [IsAuthenticatedGuard,HasroleGuard],
    data: {
      role: ['admin','employee']
    }
  },
  {
    path : "login",
    component: LoginComponent
  },
  {
    path : "signup",
    component: RegisterFormGroupComponent
  },
  {
    path : "mydashboard",
    component: CleaningStaffDashboardComponent
  }
  ,
  {
    path : "rooms",
    component: AllRoomsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
