import { Routes } from "@angular/router";
import { LandingLayoutComponent } from "./_layout/landing-layout/landing-layout.component";
import { AppLayoutComponent } from "./_layout/app-layout/app-layout.component";
import { AuthGuard } from "@auth0/auth0-angular";
import { NotFoundComponent } from "./not-found/not-found.component";
import { backOfficeRoutes } from "./backoffice/backoffice.routes"
import { landingRoutes } from "./landing/landing.routes"

export const routes: Routes = [
    {
        path: '',
        component: LandingLayoutComponent,
        children: landingRoutes
    },
    {
        path: 'app',
        component: AppLayoutComponent,
        canActivate: [AuthGuard],
        children: backOfficeRoutes
    },
    {
        path: '**', 
        component: NotFoundComponent
    }
];