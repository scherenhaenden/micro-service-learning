import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { ApiBaseService } from '../generic/api-base.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private apiBaseService: ApiBaseService) { }

  public async login(email: string, password: string): Promise<object> {

    const AuthenticateRequest = {
      Username:email, Password:password};
    // Call API to login
    const result = await this.apiBaseService.post('/Login/authenticate', AuthenticateRequest);
    return result;
  }
}
