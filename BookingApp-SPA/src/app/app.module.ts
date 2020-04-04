import { appRoutes } from './routes';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './_services/auth.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FoodItemComponent } from './FoodItem/FoodItem.component';
import { BookingComponent } from './Booking/Booking.component';
import {FormsModule} from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { BookingEditComponent } from './Booking-edit/Booking-edit.component';
import { NavComponent } from './nav/nav.component';
import { BlankPageComponent } from './BlankPage/BlankPage.component';
@NgModule({
   declarations: [
      AppComponent,
      FoodItemComponent,
      BookingComponent,
      HomeComponent,
      BookingEditComponent,
      NavComponent,
      BlankPageComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutingModule,
      FormsModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [],
   bootstrap: [
      AppComponent,
      AuthService
   ]
})
export class AppModule { }
