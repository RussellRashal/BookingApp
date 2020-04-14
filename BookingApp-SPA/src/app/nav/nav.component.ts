import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { tokenName } from '@angular/compiler';
import { Router } from '@angular/router';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};



  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
   // this.loggedIn();

  }
   getuser() {
      return localStorage.getItem('id');
    // this.customerId = localStorage.getItem('id');
   }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('customerId');
    console.log('logged out');
    this.router.navigate(['/home']);

  }



  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('logged in sucessfully');
      console.log(this.getuser());
    }, error => {
        console.log('failed to log in');
    }, () => {
      this.router.navigate(['/Booking']);
    });
}

}
