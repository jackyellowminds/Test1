import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TablesComponent } from './pages/tables/tables.component';
import { ReservationComponent } from './pages/reservation/reservation.component';
import { MenuComponent } from './pages/menu/menu.component';
import { OrdersComponent } from './pages/orders/orders.component';
import { LoginComponent } from './pages/login/login.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { AppComponent } from './app.component';
const routes: Routes = [
  
    {
    
      path: 'login',
      component: LoginComponent,
      data: {
        title: 'login'
      }
    },
    {
    
      path: 'sign-up',
      component: SignUpComponent,
      data: {
        title: 'signup'
      }
    },
    {
    
      path: 'tables',
      component: TablesComponent,
      data: {
        title: 'Tables'
      }
    },
    {
    
      path: 'menu',
      component: MenuComponent,
      data: {
        title: 'Menu'
      }
    },
    {
    
      path: 'orders',
      component: OrdersComponent,
      data: {
        title: 'order'
      }
    },
    
  { path: '**', component: ReservationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
