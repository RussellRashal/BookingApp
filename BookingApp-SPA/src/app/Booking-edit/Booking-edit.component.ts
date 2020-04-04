import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-booking-edit',
  templateUrl: './Booking-edit.component.html',
  styleUrls: ['./Booking-edit.component.css']
})
export class BookingEditComponent implements OnInit {
  bookings: any;

  constructor( private http: HttpClient) { }

  ngOnInit() {
    this.Bookings();
  }




  Bookings() {
    this.http.get('http://localhost:5000/api/Book').subscribe(response => {
      this.bookings = response;
      console.log(this.bookings);
    }, error => {
      console.log(error);
    });
  }

}
