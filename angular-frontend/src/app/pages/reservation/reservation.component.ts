import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpService } from 'src/services/http.service';
declare var window: any;
@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss']
})
export class ReservationComponent implements OnInit {
  formModal: any
 
  accountModal: any={};
  menuList:any=[];
  errorMessage: any;
  message: any;
  successMessage: boolean=false;
  tableList: any=[];
  tableNumber: any;
  itemForm: FormGroup;
  selectedMenuMD:any;
  reservationList: any=[];
  orderMd: any={};
  selectedTable: any;
  orderList: any=[];
  cartList: any=[];
  recentReservationList: any=[];
  isAdmin: any;
  tableMD: any={};
  isValidPerson: boolean=false;
  constructor(public httpService:HttpService, public router:Router, private formBuilder: FormBuilder) {
    this.itemForm = this.formBuilder.group({
      MenuId: [this.accountModal.MenuId ,[ Validators.required]],
      Quantity: [this.accountModal.Quantity,[ Validators.required]],
      Price: [this.accountModal.Price],
      RTableId: [this.accountModal.RTableId],ReservationId: [this.accountModal.ReservationId],
      UserNo:[this.accountModal.UserNo],
      UserCapacity: [this.accountModal.UserCapacity,[ Validators.required]],
      
      
  });
   }

  ngOnInit(): void {
    
    this.isAdmin=localStorage.getItem("role");
    console.log(this.isAdmin);
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('myModal')
    );

    this.getTables();
    this.getMenu();
    this.getRecentReservations();
  }

  getTables()
  {
    this. tableList=[];
    this.httpService.GetTableStatus().subscribe(data=>{    
      this.tableList=data;     
      console.log(data);
    },error=>{this.errorMessage=error.name+error.statusText})
  }

  getRecentReservations()
  {
    this. recentReservationList=[];
    this.httpService.GetRecentReservation().subscribe(data=>{    
      this.recentReservationList=data;     
      console.log(data);
    },error=>{this.errorMessage=error.name+error.statusText})
  }

  getMenu()
  {
    this. menuList=[];
    this.httpService.GetMenu().subscribe(data=>{    
      this.menuList=data;     
      console.log(data);
    },error=>{this.errorMessage=error.name+error.statusText})
  }

  addMeal(val:any)
  {
    this.isValidPerson=false;
    this.itemForm.controls["UserCapacity"].setValue('');
    this.tableNumber=val.tableNumber;
    this.itemForm.controls["RTableId"].setValue(val.rTableId);
    this.tableMD=val;
    // this.formModal.show();
    this.getTableReservation(val.rTableId);
    this.selectedTable=val.rTableId;
  }

  getTableReservation(TableId:any)
  {
    this. reservationList=[];
   
    this.httpService.GetReservationWithTable(TableId).subscribe(data=>{    
      this.reservationList=data;
      if(this.reservationList.length>0)
      {
        this.itemForm.controls["UserCapacity"].setValue(this.reservationList[0].userCapacity);
        this.isValidPerson=true;
        
      }
      if(this.tableMD.status==true)
      {
        this.isValidPerson=true;
      }
     
      
      console.log(data);
    },error=>{this.errorMessage=error.name+error.statusText})
    
  }
  addToList()
  {
    if(this.itemForm.invalid)
    {
      this.itemForm.markAllAsTouched();
      return;
    }
    this.successMessage=false;
    this.message=null;
    var userNo= localStorage.getItem("userno");;
    this.itemForm.controls["UserNo"].setValue(parseInt(userNo || '0'));
    this.httpService.AddReservations(this.itemForm.value).subscribe(data=>{    
      this.getTableReservation(this.selectedTable);
      this.itemForm.controls["Quantity"].setValue('');
      this.successMessage=true;
      this.message="Save Successfully";
      this.getTables();
      this.getRecentReservations();
    },error=>{this.errorMessage=error.name+error.statusText})

  }
  changeMenu()
  {
   
    this.itemForm.controls["Price"].setValue(0);
   

  }
  edit(val:any)
  {
    this.itemForm.controls["Price"].setValue(val.price);
    this.itemForm.controls["Quantity"].setValue(val.quantity);
    this.itemForm.controls["ReservationId"].setValue(val.reservationId);  
    this.itemForm.controls["MenuId"].setValue(val.menuId);
    
  }
  delete(val:any)
  {
    this.successMessage=false;
    this.message=null;
    this.httpService.DeleteReservation(val.reservationId).subscribe(data=>{    
      this.formModal.hide();
      this.getTableReservation(val.rTableId);
      this.successMessage=true;
      this.message="Deleted Successfully";
    },error=>{this.errorMessage=error.name+error.statusText})
  }

  saveOrder()
  {
    if(this.reservationList.length>0)
    {
      
      this.successMessage=false;
      this.message=null;
      this.orderMd={};
      this.orderMd.rTableId=this.selectedTable;
      this.orderMd.cartList=this.reservationList;
      this.orderMd.orderId=0;
      this.orderMd.totalAmount=0;
      var userNo= localStorage.getItem("userno");;
      this.orderMd.UserNo=parseInt(userNo || '0');
      this.orderMd.dateTime="2023-05-21T12:37:56.780Z";
      this.httpService.AddOrders(this.orderMd).subscribe(data=>{    
     
        this.formModal.hide();
        this.getTables();
        this.successMessage=true;
        this.message="Save Successfully";
        this.reservationList=[];
        this.formModal.show();
        this.getRecentReservations();
        this.getOrderDetails(data.value);
        this.isValidPerson=false;
        this.itemForm.controls["UserCapacity"].setValue('');
      },error=>{this.errorMessage=error.name+error.statusText})
    }
    else
    {
      console.log('Please choose Menu');
    }
  }
  getOrderDetails(id:any) {
    this. orderList=[];
    this.cartList=[];
    this.httpService.getOrdersById(id).subscribe(data=>{    
      this.orderList=data;  
      this.cartList=this.orderList[0].cartList;  
      console.log(data);
    },error=>{this.errorMessage=error.name+error.statusText})
  }

  cancelReservation()
  {
    this.successMessage=false;
    this.message=null;
    this.httpService.CancelReservation(this.itemForm.controls["RTableId"].value, localStorage.getItem("userno")).subscribe(data=>{    
      this.formModal.hide();
      this.getRecentReservations();
      this.getTables();
      this.successMessage=true;
      this.message="Deleted Successfully";
      this.tableNumber='';
      this.reservationList=[];
    },error=>{this.errorMessage=error.name+error.statusText})
  }

  reserveTable()
  {
    this.successMessage=false;
    this.message=null;
    var userNo= localStorage.getItem("userno");;
    this.itemForm.controls["MenuId"].setValue(0);
    this.itemForm.controls["Quantity"].setValue(0);
    this.itemForm.controls["Price"].setValue(0);
    this.itemForm.controls["UserNo"].setValue(parseInt(userNo || '0'));
    this.httpService.AddReservations(this.itemForm.value).subscribe(data=>{    
      this.getTableReservation(this.selectedTable);
      this.itemForm.controls["Quantity"].setValue('');
      this.successMessage=true;
      this.message="Save Successfully";
      this.getTables();
      this.getRecentReservations();

    },error=>{this.errorMessage=error.name+error.statusText})
  }

  cancelReservationAdmin()
  {
    this.successMessage=false;
    this.message=null;
    this.httpService.CancelReservationAdmin(this.itemForm.controls["RTableId"].value).subscribe(data=>{    
      this.formModal.hide();
      this.getRecentReservations();
      this.getTables();
      this.successMessage=true;
      this.message="Deleted Successfully";
      this.tableNumber='';
      this.reservationList=[];
    },error=>{this.errorMessage=error.name+error.statusText})
  }

  onChangeCapacity(val:any)
  {
    var capacity=val.target.value;
    this.tableMD;

    if(this.tableMD.capacity>=parseInt( capacity))
    {
      this.isValidPerson=true;
    }
    else
    {
      this.itemForm.controls["UserCapacity"].setValue('');
      console.log('Capacity of '+ this.tableNumber +' has been exceeded..');
      this.isValidPerson=false;
    }
  }

}
