import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, FormControl } from '@angular/forms';
import { BookingService } from '../_services/booking.service';


@Component({
  selector: 'app-booking-edit',
  templateUrl: './Booking-edit.component.html',
  styleUrls: ['./Booking-edit.component.css']
})

export class BookingEditComponent implements OnInit {
  BookingForm: FormGroup;
  customerId;
  bookings: any;
  model: any;
  hourpickers: string[] = [];
  getBooking: any;


  constructor(
    private authService: AuthService,
    private http: HttpClient,
    private alertify: AlertifyService,
    private bookingService: BookingService) { }

  ngOnInit() {
    this.customerId = localStorage.getItem('customerId');
    this.CreateForm();
    this.Timepicker();
    this.UpdateFormWithExistingData();
  }

  Timepicker() {
    for (let i = 0; i < 24; i++) {
      this.hourpickers[i] = i.toString();
    }
  }

  UpdateUser() {

    this.model = {
      Diet: this.BookingForm.value.Diet,
      Allergies: this.BookingForm.value.Allergies,
      Date: this.BookingForm.value.Date + ' ' + this.BookingForm.value.hour + ':00:00',
      AdditionalInfo: this.BookingForm.value.AdditionalInfo,
      TableNumber: this.BookingForm.value.TableNumber,
      NoPeople: this.BookingForm.value.NoPeople,
    };

    console.log(this.model);
    console.log('this is the customer id ' + this.customerId);

    this.bookingService.updateBooking(this.customerId, this.model).subscribe(next => {
        this.alertify.success('Update sucessful');
        console.log('successfully updated PUT request');
      }, error => {
        console.log('something went wrong with PUT request');
      });
  }

  UpdateFormWithExistingData() {
      this.bookingService.GetBookings(this.customerId).subscribe(data => {
      this.getBooking = data;
      console.log(this.getBooking);
    });
  }

  CreateForm() {
    this.BookingForm = new FormGroup({
      Allergies: new FormControl(''),
      Diet: new FormControl(''),
      Date: new FormControl(''),
      hour: new FormControl(''),
      AdditionalInfo: new FormControl(''),
      TableNumber: new FormControl(''),
      NoPeople: new FormControl('')
    });
  }

}
