import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BuildingsComponent } from './pages/buildings/buildings.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AuthInterceptorProvider } from './Interceptors/auth.interceptor';
import { HasRoleDirective } from './directive/has-role.directive';
import { BookroomComponent } from './pages/bookroom/bookroom.component';
import { BookroomviewComponent } from './pages/bookroom/bookroomview/bookroomview.component';
import { AvailableRoomsComponent } from './pages/room/rooms/available-rooms/available-rooms.component';
import { AllRoomsComponent } from './pages/room/all-rooms/all-rooms.component';
import { ViewRoomComponent } from './pages/room/view-room/view-room.component';
import { RegisterFormGroupComponent } from './pages/register/register-form-group/register-form-group.component';

@NgModule({
  declarations: [
    AppComponent,
    BuildingsComponent,
    LoginComponent,
    RegisterComponent,
    HasRoleDirective,
    BookroomComponent,
    BookroomviewComponent,
    AvailableRoomsComponent,
    AllRoomsComponent,
    ViewRoomComponent,
    RegisterFormGroupComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AuthInterceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
