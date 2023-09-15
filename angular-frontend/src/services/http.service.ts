import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  public serverName = window.location.origin.replace("3000", "5000") + "/api/";
  constructor(private http: HttpClient) {}

   // TODO: Get All Table List
   GetTables():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: get Table status empty or occupied
  GetTableStatus():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }
  
  // TODO: get recent reservations
  GetRecentReservation():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }
  
  // TODO: Save table in Table 
  SaveTable(details:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: Delete table from DB 
  DeleteTable(id:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null
  }

  // TODO: Get all menu from DB
  GetMenu():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: Add new menu in DB through menucontroller
  AddMenu(details:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: Delete menu in db DB through menucontroller
  DeleteMenu(id:any):Observable<any> {  
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: add new reservation in DB through reservationcontroller
  AddReservations(details:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: get reservation with table from db through reservationcontroller
  GetReservationWithTable(id:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: delete reservation table item from db through reservationcontroller
  DeleteReservation(id:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: Cancel Reservation from db through reservationcontroller
  CancelReservation(id:any,userno:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: Cancel reservation from db  through reservationcontroller
  CancelReservationAdmin(id:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: Add new order in db through ordercontroller
  AddOrders(details:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: get All orders from db by ordercontroller
  Orders():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: get order by id from db by ordercontroller
  getOrdersById(id:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: delete order from db by ordercontroller
  DeleteOrder(id:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: update order in db by ordercontroller
  UpdateOrders(details:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: login user by login controller
  Login(details:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }

  // TODO: register new user by login controller
  registerUser(details:any):Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return null;
  }  
}
