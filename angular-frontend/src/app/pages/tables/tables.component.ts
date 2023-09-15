import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpService } from 'src/services/http.service';
declare var window: any;
@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss']
})
export class TablesComponent implements OnInit {
  formModal: any
  itemForm: FormGroup;
  accountModal: any={};
  tableList:any=[];
  errorMessage: any;
  message: any;
  successMessage: boolean=false;
  constructor(public httpService:HttpService, public router:Router, private formBuilder: FormBuilder) {

    this.itemForm = this.formBuilder.group({
      RTableId: [this.accountModal.RTableId],
      TableNumber: [this.accountModal.TableNumber,[ Validators.required]],
      Capacity: [this.accountModal.Capacity,[ Validators.required]]
  });
   }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('myModal')
    );
    this.getTables();
  }
  
  showModal()
  {
    this.formModal.show();
    this.itemForm.reset();
  }
  getTables()
  {
    this. tableList=[];
    this.httpService.GetTables().subscribe(data=>{    
      this.tableList=data;     
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
    this.httpService.SaveTable(this.itemForm.value).subscribe(data=>{    
      this.formModal.hide();
      this.getTables();
      this.successMessage=true;
      this.message="Save Successfully";
    },error=>{this.errorMessage=error.name+error.statusText})
    
  } 
  delete(val:any)
  { 
    confirm('Are you sure to delete this')
    {
      this.successMessage=false;
      this.message=null;
      this.httpService.DeleteTable(val.rTableId).subscribe(data=>{    
        this.formModal.hide();
        this.getTables();
        this.successMessage=true;
        this.message="Deleted Successfully";
      },error=>{this.errorMessage=error.name+error.statusText})
    }

  }
  edit(val:any)
  {
    console.log(val);
    this.formModal.show();
    this.itemForm.controls["RTableId"].setValue(val.rTableId);
    this.itemForm.controls["TableNumber"].setValue(val.tableNumber);
    this.itemForm.controls["Capacity"].setValue(val.capacity);
  }

}
