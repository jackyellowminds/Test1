import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpService } from 'src/services/http.service';
declare var window: any;

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent {
  formModal: any
  itemForm: FormGroup;
  accountModal: any={};
  orderList:any=[];
  errorMessage: any;
  message: any;
  successMessage: boolean=false;
  menuList: any=[];
  selectedMenuMD:any={};
  cartList:any=[];
  cardMd:any= {};
  orderMd:any= {};
  selectedTable: any;
  selectedOrderNo: any;
  printModal: any;
  orderList2: any=[];
  cartList2: any=[];
  constructor(public httpService:HttpService, public router:Router, private formBuilder: FormBuilder) {
    this.itemForm = this.formBuilder.group({
      MenuId: [this.accountModal.MenuId ,[ Validators.required]],
      Quantity: [this.accountModal.Quantity,[ Validators.required]],
      Price: [this.accountModal.Price],
      RTableId: [this.accountModal.RTableId],ReservationId: [this.accountModal.ReservationId],
      OrderId: [this.accountModal.OrderId],
  });
  
   }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('myModal')
    );
    this.printModal = new window.bootstrap.Modal(
      document.getElementById('printModal')
    );
    
    this.getOrders();
    this.getMenu();
  }
  getMenu()
  {
    this. menuList=[];
    this.httpService.GetMenu().subscribe(data=>{    
      this.menuList=data;     
      console.log(data);
    },error=>{this.errorMessage=error.name+error.statusText})
  }
  showModal()
  {
    this.formModal.show();
    this.itemForm.reset();
  }
  getOrders()
  {
    this. orderList=[];
    this.httpService.Orders().subscribe(data=>{    
      this.orderList=data;     
      console.log(data);
    },error=>{this.errorMessage=error.name+error.statusText})
  }
  saveOrder()
  {
    if(this.cartList.length>0)
    {
      this.successMessage=false;
      this.message=null;
      this.orderMd={};
      this.orderMd.rTableId=this.selectedTable;
      this.orderMd.cartList=this.cartList;
      this.orderMd.orderId=this.itemForm.controls["OrderId"].value;
      this.orderMd.totalAmount=0;
      this.orderMd.dateTime="2023-05-21T12:37:56.780Z";
      this.httpService.UpdateOrders(this.orderMd).subscribe(data=>{    
        this.formModal.hide();
        this.getOrders();
        this.successMessage=true;
        this.message="Save Successfully";
     
      },error=>{this.errorMessage=error.name+error.statusText})
    }
    else
    {
      alert('Please choose Menu');
    }
  }
  delete(val:any)
  { 
    {
      this.successMessage=false;
      this.message=null;
      this.httpService.DeleteOrder(val.orderId).subscribe(data=>{    
        this.formModal.hide();
        this.getOrders();
        this.successMessage=true;
        this.message="Deleted Successfully";
      },error=>{this.errorMessage=error.name+error.statusText})
    }

  }
  edit(val:any)
  {
    this.selectedOrderNo=val.orderId;
    console.log(val);
    this.formModal.show();
    this.cartList=[];
    this.cartList=val.cartList;
    this.itemForm.controls["OrderId"].setValue(val.orderId);
    this.itemForm.controls["RTableId"].setValue(val.rTableId);
    this.selectedTable=val.rTableId;
   
  }
  addToList()
  {
    if(this.itemForm.invalid)
    {
      this.itemForm.markAllAsTouched();
      return;
    }
    this.cardMd={};
    this.cardMd.menuId=this.selectedMenuMD.menuId;
    this.cardMd.quantity=this.itemForm.controls["Quantity"].value;
    this.cardMd.price=this.itemForm.controls["Price"].value;
    this.cardMd.rTableId=this.itemForm.controls["RTableId"].value;

    this.cardMd.itemName=this.selectedMenuMD.itemName;
    this.cardMd.price=this.selectedMenuMD.price;
    this.cartList.push(this.cardMd);

  }
  changeMenu()
  {
    console.log(this.selectedMenuMD);
    this.itemForm.controls["Price"].setValue(0);
  }
  print(val:any)
  {
    this.printModal.show();
    this. orderList2=[];
    this.cartList=[];
    this.httpService.getOrdersById(val.orderId).subscribe(data=>{    
      this.orderList2=data;  
     
      this.cartList2=this.orderList2[0].cartList;  
      console.log(this.cartList2);
    },error=>{this.errorMessage=error.name+error.statusText})
  }
}
