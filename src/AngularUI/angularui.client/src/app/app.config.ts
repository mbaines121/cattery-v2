import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { provideAuth0 } from '@auth0/auth0-angular';
import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { loggingInterceptor } from './interceptors/request.interceptor';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async'

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideHttpClient(
      withInterceptors([loggingInterceptor])
    ),
    provideRouter(routes, withComponentInputBinding()),
    provideAuth0({
      domain: 'dev-w0se00pqcuvsqaeh.us.auth0.com',
      clientId: 'GR0l4Fvwy4GtIGqpXCDJAgfmoflc9oVa',
      authorizationParams: {
        redirect_uri: window.location.origin
      }
    }), provideAnimationsAsync()
  ]
};
