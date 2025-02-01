import { Routes } from "@angular/router";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { BookingComponent } from "./booking/booking.component";
import { ProfileComponent } from "./profile/profile.component";

export const backOfficeRoutes: Routes = [
    { path: '', redirectTo: 'dashboard', pathMatch: 'prefix' },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'booking', component: BookingComponent },
    { path: 'profile', component: ProfileComponent },
];