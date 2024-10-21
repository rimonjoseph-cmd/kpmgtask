import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './pages/users/users.component';
import { BuildingsComponent } from './pages/buildings/buildings.component';

const routes: Routes = [
  {
    path : "users",
    component: UsersComponent
  },
  {
    path : "buildings",
    component: BuildingsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
