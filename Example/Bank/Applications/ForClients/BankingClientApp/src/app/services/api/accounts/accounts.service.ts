import { Injectable } from '@angular/core';
import { BankingAccountCompactModel } from 'src/app/models/banking-accounts/banking-account-compact-model';
import { ApiBaseService } from '../generic/api-base.service';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  constructor(private apiBaseService: ApiBaseService) { }

  public async getAccountsByUserId(userId: string): Promise<BankingAccountCompactModel[]> {
    // HttpParams userId
    return await this.apiBaseService.get(`/Accounts/GetAccountByUserId?userId=${userId}`);
  }
}
