import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

import { ModalService } from '../_modal';
@Component({
  selector: 'app-view-customer',
  templateUrl: './ViewCustomer.component.html',
  styleUrls: ['./ViewCustomer.component.css']
})
export class ViewCustomerComponent implements OnInit {
bookings: any;
bodyText: string;
selectedBooking: any;
  constructor(private authService: AuthService, private http: HttpClient, private alertify: AlertifyService
    ,         private modalService: ModalService) { }

  ngOnInit() {
    this.Bookings();
    console.log(this.Bookings());
    this.bodyText = 'This text can be updated in modal 1';
  }

//   openModal(id: string) {
//     this.modalService.open(id);
// }

// openModal(booking: any) {
//   this.modalService.Bookings = booking;
//   this.modalService.open(booking);
//   }

 openModal(booking: any) {
    this.modalService.Bookings = booking;
    this.modalService.open(booking);
  }


// openModal(booking: any) {
//   this.modalService.Bookings = booking;
//   this.modalService.open(booking);
//   }

closeModal(id: string) {
    this.modalService.close(id);
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
