import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiBaseService {

  constructor(private http: HttpClient) { }
  public async get(route: string, host?: string): Promise<any> {

    const url = host ? host + route : environment.apiHost + route;

    return lastValueFrom(this.http.get(url));
  }

  // Write method to execute a POST request
  public async post(route: string, body: any, host?: string): Promise<any> {

    const httpOptionsNew = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        //Authorization: 'Bearer ' + localStorage.getItem('token')
      }),
    };

      const url = host ? host + route : environment.apiHost + route;

      return lastValueFrom(this.http.post(url, body));
  }
}
