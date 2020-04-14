import { RouterTestingModule } from '@angular/router/testing';
import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';


@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Booking',
  templateUrl: './Booking.component.html',
  styleUrls: ['./Booking.component.css']
})
export class BookingComponent implements OnInit {
  customerId;
  hourpickers: string[] = [];
  @Input() valuesFromHome: any;
  @Output() cancelBooking = new EventEmitter();
  model: any = {};
  bookings: any;
  BookComplete: FormGroup;

  constructor(private authService: AuthService, private http: HttpClient, private alertify: AlertifyService) { }


  ngOnInit() {
    this.customerId = localStorage.getItem('customerId');
    this.alterForm();
    this.Bookings();
    this.Book();
    this.Timepicker();
  }

  // getuser() {
  //     return localStorage.getItem('id');
  // }


  Timepicker() {
    for (let i = 0; i < 24; i++) {
      this.hourpickers[i] = i.toString();
    }
    console.log(this.hourpickers);
  }


  Book() {
    this.model.date = this.BookComplete.value.date + ' ' + this.BookComplete.value.hour + ':00:00';
    this.model.tableNumber = this.BookComplete.value.tableNumber;
    this.model.additionalInfo = this.BookComplete.value.additionalInfo;
    this.model.noPeople = this.BookComplete.value.noPeople;
    this.model.customerId = this.customerId;

    console.log(this.model);

    this.authService.Booking(this.model).subscribe(() => {
    this.alertify.success('Booked successfully');
   }, error => {
     this.alertify.error('This table is already booked at this time please try a different table');
   });


  }
  Bookings() {
    this.http.get('http://localhost:5000/api/Book/' + this.customerId).subscribe(response => {
      this.bookings = response;
      console.log(this.bookings);
    }, error => {
      console.log(error);
    });
  }


  alterForm() {
    this.BookComplete = new FormGroup({
      date: new FormControl(),
      hour: new FormControl(),
      tableNumber: new FormControl(),
      additionalInfo: new FormControl(),
      noPeople: new FormControl()
    });
  }


 // cancel() {
   // this.cancelBooking.emit(false);
  //  console.log('cancel');
  }

