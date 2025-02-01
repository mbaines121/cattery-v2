import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { provideAuth0 } from '@auth0/auth0-angular';
import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { loggingInterceptor } from './backoffice/interceptors/request.interceptor';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async'
import { authHttpInterceptorFn } from '@auth0/auth0-angular';

export const appConfig: ApplicationConfig = {
  providers: [
    provideAnimationsAsync(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideHttpClient(
      withInterceptors([loggingInterceptor, authHttpInterceptorFn])
    ),
    provideRouter(routes, withComponentInputBinding()),
    provideAuth0({
      domain: 'dev-w0se00pqcuvsqaeh.us.auth0.com',
      clientId: 'GR0l4Fvwy4GtIGqpXCDJAgfmoflc9oVa',
      authorizationParams: {
        redirect_uri: window.location.origin,
        audience: 'https://127.0.0.1:50557/',
        scope: 'read:admin profile'
      },
      httpInterceptor: {
        allowedList: [
          '/api/*',
          {
            uri: '/api/accounts/*',
            tokenOptions: {
              authorizationParams: {
                audience: 'https://127.0.0.1:50557/',
                scope: 'read:admin'
              }
            }
          }
        ]
      }
    }) 
  ]
};
