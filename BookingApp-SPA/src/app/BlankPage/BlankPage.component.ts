import { AuthService } from './../_services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-blankpage',
  templateUrl: './BlankPage.component.html',
  styleUrls: ['./BlankPage.component.css']
})
export class BlankPageComponent implements OnInit {
  customerId ;
  @Input() bookingFromHome: any;
  @Input() make: string;
  employee = [
    'Mr', 'Mrs', 'Shinglongfong'
  ];
  bookings: any;
  model: any = {};

  constructor(private authService: AuthService, private http: HttpClient) { }

  ngOnInit() {
    this.customerId = localStorage.getItem('id');
    this.Bookings();
    // console.log(this.getuser());
  }



  Bookings() {
    this.authService.GetBooking(this.model).subscribe(response => {
      this.bookings = response;
      console.log(this.bookings);
    }, error => {
      console.log(error);
    });
  }


  // getuser(): any {
  //   return localStorage.getItem('id');
  // }


}

