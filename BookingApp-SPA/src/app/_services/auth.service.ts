import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import {BehaviorSubject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/';
  userUrl = this.baseUrl + 'user/';
  MainUrl = 'http://localhost:5000/api/Book/';

  constructor(private http: HttpClient) { }


  login(model: any) {
    return this.http.post(this.userUrl + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            localStorage.setItem('customerId', JSON.stringify(user.id));
           // localStorage.setItem('customerId', user.id);

          }
        })
      );
  }

  updateUser(customerId: number, model: any) {
    return this.http.put(this.baseUrl + 'Book/' + customerId, model);
  }

   GetBooking(model: any) {
     return this.http.get(this.MainUrl + 'customerId', model);
   }


  Booking(model: any) {
    return this.http.post(this.baseUrl + 'Book', model);
  }

  Customer(model: any) {
    return this.http.post(this.baseUrl + 'Customer', model);
  }


  }



