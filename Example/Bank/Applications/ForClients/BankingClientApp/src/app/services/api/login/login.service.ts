import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiBaseService } from '../generic/api-base.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private apiBaseService: ApiBaseService) { }

  public async login(email: string, password: string): Promise<object> {

    const headers = new HttpHeaders({
      'Content-Type':  'application/json',
    });

    const AuthenticateRequest = {
      Username:email, Password:password};
    // Call API to login
    const result = await this.apiBaseService.post<any>('/Login/authenticate', AuthenticateRequest, headers);
    return result;
  }
}
