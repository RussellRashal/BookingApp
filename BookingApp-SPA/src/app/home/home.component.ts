import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  submitMode = false;
  values: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  SubmitToggle() {
    this.submitMode = true;
  }



cancelBookingMode(bookingMode: boolean) {
  this.submitMode = this.submitMode;
}



}
