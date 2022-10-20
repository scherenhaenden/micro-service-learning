import { HttpEvent, HttpHandler, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SessionService } from '../session/session.service';

@Injectable({
  providedIn: 'root'
})
export class JwtInterceptorService {

  constructor(private sessionService: SessionService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add auth header with jwt if account is logged in and request is to the api url
        //const account = this.sessionService.accountValue;
        //const isLoggedIn = account?.token;

        const isLogged = this.sessionService.isLoggedIn();
        const token = this.sessionService.getToken();


        const isApiUrl = request.url.startsWith(environment.apiHost);
        if (isLogged && isApiUrl) {
            request = request.clone({
                setHeaders: { Authorization: `Bearer ${token}` }
            });
        }

        return next.handle(request).pipe(
          tap((response) => {
            if (response instanceof HttpResponse) {
              //this.cache.set(request.url, response);
              console.log('Response from server: ', response);
            }
          })
        );
    }
}
