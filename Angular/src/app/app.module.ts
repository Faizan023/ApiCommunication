import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { logincomponent } from './logincomponent/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './Service/auth.service';
import { ListComponent } from './listcomponent/list.component';


@NgModule({
  declarations: [
    AppComponent, logincomponent, ListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, ReactiveFormsModule, HttpClientModule,
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
