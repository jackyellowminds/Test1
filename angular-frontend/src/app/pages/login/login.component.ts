import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpService } from 'src/services/http.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  itemForm: FormGroup;
  formModel:any={};
  showError:boolean=false;
  errorMessage:any;
  constructor(public router:Router, public httpService:HttpService, private formBuilder: FormBuilder) 
    {
      this.itemForm = this.formBuilder.group({
        Email: [this.formModel.Email,[ Validators.required]],
        Password: [this.formModel.Password,[ Validators.required]],
       
    });
  }

  ngOnInit(): void {
  }
  onLogin()
  {
    if(this.itemForm.valid)
    {
      this.showError=false;
      this.httpService.Login(this.itemForm.value).subscribe(data=>{    
        
        if(data.userNo!=0)
        {
          localStorage.setItem('userno',data.userNo)
          localStorage.setItem('role',data.role)
          this.router.navigateByUrl('/reservation');
          setTimeout(() =>{ 
            window.location.reload();
          },1000);
          
        }
        else{
          this.showError=true;
          this.errorMessage="Wrong User or Password";
        }
      },error=>{ })
    }
    else{
      this.itemForm.markAllAsTouched();
    }
  }
  signUp()
  {
    this.router.navigateByUrl('/sign-up');
  }
}
