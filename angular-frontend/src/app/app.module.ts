import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TablesComponent } from './pages/tables/tables.component';
import { ReservationComponent } from './pages/reservation/reservation.component';
import { HttpService } from 'src/services/http.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MenuComponent } from './pages/menu/menu.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { OrdersComponent } from './pages/orders/orders.component';
import { LoginComponent } from './pages/login/login.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';

@NgModule({
  declarations: [
    AppComponent,
    TablesComponent,
    ReservationComponent,
    MenuComponent,
    OrdersComponent,
    LoginComponent,
    SignUpComponent
   
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,FormsModule, ReactiveFormsModule ,NgSelectModule
  ],
  providers: [HttpService,HttpClientModule ],
  bootstrap: [AppComponent]
})
export class AppModule { }
