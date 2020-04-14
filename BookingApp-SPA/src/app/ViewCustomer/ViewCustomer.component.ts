import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-view-customer',
  templateUrl: './ViewCustomer.component.html',
  styleUrls: ['./ViewCustomer.component.css']
})
export class ViewCustomerComponent implements OnInit {
bookings: any;
  constructor(private authService: AuthService, private http: HttpClient, private alertify: AlertifyService) { }

  ngOnInit() {
    this.Bookings();
    console.log(this.Bookings());
  }


  Bookings() {
    this.http.get('http://localhost:5000/api/Book/').subscribe(response => {
      this.bookings = response;
      console.log(this.bookings);
    }, error => {
      console.log(error);
    });
  }

}
