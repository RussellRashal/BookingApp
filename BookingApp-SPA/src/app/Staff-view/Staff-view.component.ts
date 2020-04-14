import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-staff-view',
  templateUrl: './Staff-view.component.html',
  styleUrls: ['./Staff-view.component.css']
})
export class StaffViewComponent implements OnInit {
  model: any = {};
  Loggingin: FormGroup;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.alterForm();
    this.Login();
  }



  Login() {
    this.model.FirstName = this.Loggingin.value.FirstName;
    this.model.Password = this.Loggingin.value.Password;
    console.log(this.model);

    this.authService.login(this.model).subscribe(next => {
      console.log('logged in sucessfully');
    }, error => {
        console.log('failed to log in');
    }, () => {
        this.router.navigate(['/view-customer']);
    });
  }


  alterForm() {
    this.Loggingin = new FormGroup({
      FirstName: new FormControl(),
      Password: new FormControl()
    });
  }


}








