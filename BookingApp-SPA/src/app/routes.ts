import { BlankPageComponent } from './BlankPage/BlankPage.component';
import { BookingEditComponent } from './Booking-edit/Booking-edit.component';
import { BookingComponent } from './Booking/Booking.component';
import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';


export const appRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'Booking', component: BookingComponent},
    {path: 'booking-edit', component: BookingEditComponent},
    {path: 'blankpage', component: BlankPageComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'},
];
