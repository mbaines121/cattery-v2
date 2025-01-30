import { HttpEventType, HttpHandlerFn, HttpRequest } from "@angular/common/http";
import { tap } from "rxjs";

export function loggingInterceptor(request: HttpRequest<unknown>, next: HttpHandlerFn) {
    console.log('[Outgoing request]');
    console.log(request);
    return next(request).pipe(
        tap({
            next: event => {
                if (event.type === HttpEventType.Response) {
                    console.log('Incoming response');
                    console.log(event.status);
                    console.log(event.body);
                }
            }
        })
    );
}