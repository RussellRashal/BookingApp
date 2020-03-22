import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Booking',
  templateUrl: './Booking.component.html',
  styleUrls: ['./Booking.component.css']
})
export class BookingComponent implements OnInit {
  Book: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getBooking();
  }

  getBooking() {
    this.http.get('http://localhost:5000/api/Book').subscribe(response => {
      this.Book = response;
    }, error => {
      console.log(error);
    });
  }

}
