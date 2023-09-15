import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpService } from 'src/services/http.service';
declare var window: any;

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  formModal: any
  itemForm: FormGroup;
  accountModal: any={};
  menuList:any=[];
  errorMessage: any;
  message: any;
  successMessage: boolean=false;
  constructor(public httpService:HttpService, public router:Router, private formBuilder: FormBuilder) {

    this.itemForm = this.formBuilder.group({
      MenuId: [this.accountModal.MenuId],
      ItemName: [this.accountModal.ItemName,[ Validators.required]],
      Price: [this.accountModal.Price,[ Validators.required]]
  });
   }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('myModal')
    );
    this.getMenu();
  }
  showModal()
  {
    this.formModal.show();
    this.itemForm.reset();
  }
  getMenu()
  {
    this. menuList=[];
    this.httpService.GetMenu().subscribe(data=>{    
      this.menuList=data;     
      console.log(data);
    },error=>{this.errorMessage=error.name+error.statusText})
  }
  save()
  {
    if(this.itemForm.invalid)
    {
      this.itemForm.markAllAsTouched();
      return;
    }
    this.successMessage=false;
    this.message=null;
    this.httpService.AddMenu(this.itemForm.value).subscribe(data=>{    
      this.formModal.hide();
      this.getMenu();
      this.successMessage=true;
      this.message="Save Successfully";
    },error=>{this.errorMessage=error.name+error.statusText})
    
  } 
  delete(val:any)
  { 
    this.successMessage=false;
    this.message=null;
    this.httpService.DeleteMenu(val.menuId).subscribe(data=>{    
      this.formModal.hide();
      this.getMenu();
      this.successMessage=true;
      this.message="Deleted Successfully";
    },error=>{this.errorMessage=error.name+error.statusText})
  }
  
  edit(val:any)
  {
    console.log(val);
    this.formModal.show();
    this.itemForm.controls["MenuId"].setValue(val.menuId);
    this.itemForm.controls["ItemName"].setValue(val.itemName);
    this.itemForm.controls["Price"].setValue(val.price);
  }

}
