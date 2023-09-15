import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  userStatus: boolean=true;
  isAdmin: boolean=false;
  constructor(private router:Router){
    
  }
  ngOnInit(): void { 
    if(localStorage.getItem('userno')!=null)
    {

      this.userStatus=true;   
      var Role=localStorage.getItem('role');
      if(Role=="Admin")
      {
        this.isAdmin=true;
      } 
    }
    else{
      this.userStatus=false;
      this.router.navigateByUrl("/login");
    }
  }
  logout()
  {
    localStorage.removeItem('userno');  
    this.userStatus=false;
    this.router.navigateByUrl('/login')
  }
}
