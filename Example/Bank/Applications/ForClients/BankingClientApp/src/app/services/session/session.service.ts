import { Injectable } from '@angular/core';
import { TokenAuthenticationServiceService } from '../security/token-authentication-service.service';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor(private tokenAuthenticationServiceService: TokenAuthenticationServiceService) { }

  // Create method that checks if user is logged in
  public isLoggedIn(): boolean {
    return this.tokenAuthenticationServiceService.isTokenValid();
  }

  // Init session into app: Set token into local storage
  public tryInitSession(token: string): boolean {
    return this.tokenAuthenticationServiceService.validateTokenAndSetTokenInLocalStorage(token);
  }

  // Get token from local storage
  public getToken(): string | undefined {
    return localStorage.getItem('token') as string| undefined;
  }


  // Create method that gets user email from local storage
  public getSessionEmail(): string| undefined {
    // Get email from localStorage
    const email = localStorage.getItem('email');
    return email != null ? email : undefined;
  }

  // Create method that logs user out by clearing local storage
  public clearUserSession(): void {
    localStorage.clear();
  }

  // Create method that stores user login info into local storage
  public assignSessionInfo(email: string): void {
    localStorage.setItem('email', email);
  }

  // Create method that stores user token info into local storage
  public assignUserTokenInfo(token: string): void {
    localStorage.setItem('token', token);
  }
}
