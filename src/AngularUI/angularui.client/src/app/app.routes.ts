import { Routes } from "@angular/router";
import { LandingLayoutComponent } from "./_layout/landing-layout/landing-layout.component";
import { AboutComponent } from "./landing/about/about.component";
import { ContactComponent } from "./landing/contact/contact.component";
import { AppLayoutComponent } from "./_layout/app-layout/app-layout.component";
import { DashboardComponent } from "./backoffice/dashboard/dashboard.component";
import { BookingComponent } from "./backoffice/booking/booking.component";
import { HomeComponent } from "./landing/home/home.component";

export const routes: Routes = [

    // layout routes
    {
        path: '',
        component: LandingLayoutComponent,
        children: [
            { path: '', component: HomeComponent },
            { path: 'about', component: AboutComponent },
            { path: 'contact', component: ContactComponent }
        ]
    },

    // app routes
    {
        path: '',
        component: AppLayoutComponent,
        children: [
            { path: 'dashboard', component: DashboardComponent },
            { path: 'booking', component: BookingComponent }
        ]
    },

    // no layout routes ...
    { path: '**', redirectTo: '' }
];