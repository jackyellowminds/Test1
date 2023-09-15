import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  public serverName=window.location.origin.replace("3000", "5000") + "/api/";
  constructor(private http: HttpClient) {

   }
   //Get All Table List
   GetTables():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return this.http.get(this.serverName+'Tables',{headers:headers});
  
  
  }
  //get Table status empty or occupied
  GetTableStatus():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
  return this.http.get(this.serverName+'GetTableStatus',{headers:headers});
  }
  //get recent reservations
  GetRecentReservation():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.get(this.serverName+'GetRecentReservations',{headers:headers});
  }
  
  //Save table in Table 
  SaveTable(details:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.post(this.serverName+'AddTable',details,{headers:headers});
  }
  //Delete table from DB 
  DeleteTable(id:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.delete(this.serverName+'Delete?id='+id,{headers:headers});
  }
  //Get all menu from DB
  GetMenu():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.get(this.serverName+'MenuItems',{headers:headers});
  }

  //Add new menu in DB through menucontroller
  AddMenu(details:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.post(this.serverName+'AddMenu',details,{headers:headers});
  }
  //Delete menu in db DB through menucontroller
  DeleteMenu(id:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.delete(this.serverName+'DeleteMenu?id='+id,{headers:headers});
  }
  //add new reservation in DB through reservationcontroller
  AddReservations(details:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.post(this.serverName+'AddReservations',details,{headers:headers});
  }
  //get reservation with table from db through reservationcontroller
  GetReservationWithTable(id:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.get(this.serverName+'GetReservationWithTable?Id='+id,{headers:headers});
  }
  //delte reservation table item from db through reservationcontroller
  DeleteReservation(id:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.delete(this.serverName+'DeleteReservation?id='+id,{headers:headers});
  }
  //Cancel Reservation from db through reservationcontroller
  CancelReservation(id:any,userno:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
  return this.http.delete(this.serverName+'CancelReservation?id='+id+'&userno='+userno,{headers:headers});
  }
  //Cancel reservation from db  through reservationcontroller
  CancelReservationAdmin(id:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.delete(this.serverName+'CancelReservationAdmin?id='+id,{headers:headers});
  }
  //Add new order in db through ordercontroller
  AddOrders(details:any):Observable<any> {
    debugger;
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.post(this.serverName+'SaveOrders',details,{headers:headers});
  }
  //get All orders from db by ordercontroller
  Orders():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.get(this.serverName+'Orders',{headers:headers});
  }
  //get order by id from db by ordercontroller
  getOrdersById(id:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
  return this.http.get(this.serverName+'OrderById?id='+id,{headers:headers});
  }
  //delete order from db by ordercontroller
  DeleteOrder(id:any):Observable<any> {
  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
  return this.http.delete(this.serverName+'DeleteOrder?id='+id,{headers:headers});
  }
  //update order in db by ordercontroller
  UpdateOrders(details:any):Observable<any> {
    debugger;
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.post(this.serverName+'UpdateOrders',details,{headers:headers});
  }
  //login user by login controller
  Login(details:any):Observable<any> {
    
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.post(this.serverName+'Login/LoginNow',details,{headers:headers});
  }
  //register new user by login controller
  registerUser(details:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
   return this.http.post(this.serverName+'Login/RegisterUser',details,{headers:headers});
  }
 
  
  
}


