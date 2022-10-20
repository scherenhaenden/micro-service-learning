import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenAuthenticationServiceService {

  constructor() { }

  // Create method that checks if token is valid by inputstring token
  public isTokenValidByToken(token: string): boolean {

    if(token == null || token == undefined) {
      return false;
    }

    let decodedToken!: any;

    // Decode token
    try {
      decodedToken = jwt_decode(token) as any;
      if(decodedToken == null || decodedToken == undefined) {
        return false;
      }
    } catch (error) {
      return false;

    }

    // Get current time
    const currentTime = new Date().getTime() / 1000;
    // Check if token is expired
    if(decodedToken.exp < currentTime) {
      return false;
    }
    return true;
  }


  // Create method that checks if token is valid
  public isTokenValid(): boolean {
    // Get token from local storage
    const token = localStorage.getItem('token');

    return this.isTokenValidByToken(token!);
  }

  // Create method that to validate token and when valid set token in local storage
  public validateTokenAndSetTokenInLocalStorage(token: string): boolean {
    if(this.isTokenValidByToken(token)) {
      localStorage.setItem('token', token);
      return true;
    }
    return false;
  }
}
