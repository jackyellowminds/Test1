import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpService } from 'src/services/http.service';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  itemForm: FormGroup;
  formModel:any={};
  showMessage:boolean=false;

  responseMessage: any;
  constructor(public router:Router, private bookService:HttpService, private formBuilder: FormBuilder) { 
    
      this.itemForm = this.formBuilder.group({
        Email: [this.formModel.Email,[ Validators.required]],
        Password: [this.formModel.Password,[ Validators.required]],
        FirstName: [this.formModel.FirstName,[ Validators.required]],
        LastName: [this.formModel.LastName,[ Validators.required]],
       
    });
  }

  ngOnInit(): void {
  }
  onRegister()
  {
    if(this.itemForm.valid)
    {
      this.showMessage=false;
      this.bookService.registerUser(this.itemForm.value).subscribe(data=>{    
        this.showMessage=true;
        this.responseMessage=data;
        this.itemForm.reset();
        
      },error=>{ })
    }
    else{
      this.itemForm.markAllAsTouched();
    }
  }
  signIn()
  {
    this.router.navigateByUrl('login')
  }

}
