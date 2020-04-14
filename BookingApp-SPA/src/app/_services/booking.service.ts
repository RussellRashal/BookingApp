import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  baseUrl = 'http://localhost:5000/api/Book/';

  constructor(private http: HttpClient) { }

  updateBooking(customerId, model: any) {
    return this.http.put(this.baseUrl + customerId, model);
  }


  GetBookings(customerId) {
    return this.http.get(this.baseUrl + customerId);
  }
}
