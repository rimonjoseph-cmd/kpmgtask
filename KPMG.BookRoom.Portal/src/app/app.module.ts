import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BuildingsComponent } from './pages/buildings/buildings.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AuthInterceptorProvider } from './Interceptors/auth.interceptor';
import { HasRoleDirective } from './directive/has-role.directive';

@NgModule({
  declarations: [
    AppComponent,
    BuildingsComponent,
    LoginComponent,
    RegisterComponent,
    HasRoleDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AuthInterceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
