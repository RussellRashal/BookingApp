import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Booking',
  templateUrl: './Booking.component.html',
  styleUrls: ['./Booking.component.css']
})
export class BookingComponent implements OnInit {



  makes = ['Mr' , 'Mrs', 'Ford'];

  @Input() valuesFromHome: any;
  @Output() cancelBooking = new EventEmitter();
  model: any = {};
  bookings: any;

  constructor(private authService: AuthService, private http: HttpClient, private alertify: AlertifyService) { }

  ngOnInit() {
    this.Bookings();
    this.Book();
  }


  Book() {
   this.authService.Booking(this.model).subscribe(() => {
    this.alertify.success('Booked successfully');
   }, error => {
     this.alertify.error('its already booked');
   });


  }
  Bookings() {
    this.http.get('http://localhost:5000/api/Book').subscribe(response => {
      this.bookings = response;
      console.log(this.bookings);
    }, error => {
      console.log(error);
    });
  }


 // cancel() {
   // this.cancelBooking.emit(false);
  //  console.log('cancel');
  }

