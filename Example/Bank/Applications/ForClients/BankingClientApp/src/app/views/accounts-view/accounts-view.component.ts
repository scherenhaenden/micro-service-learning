import { SessionService } from 'src/app/services/session/session.service';
import { Component, OnInit } from '@angular/core';
import { BankingAccountSimple } from 'src/app/models/banking-accounts/banking-account-simple';

@Component({
  selector: 'app-accounts-view',
  templateUrl: './accounts-view.component.html',
  styleUrls: ['./accounts-view.component.scss']
})
export class AccountsViewComponent implements OnInit {

  constructor(private sessionService: SessionService) { }

  ngOnInit(): void {
    this.loadSomeData();
  }

  public accounts: BankingAccountSimple [] = [];

  // Create method that logs user out
  public logout(): void {
    this.sessionService.clearUserSession();
  }

  public loadSomeData(): void {
    // Mock banking accounts simple
    const bankingAccountSimple1 = new BankingAccountSimple();
    bankingAccountSimple1.id = '1';
    bankingAccountSimple1.name = 'Savings Account';
    bankingAccountSimple1.balance = 1000;

    const bankingAccountSimple2 = new BankingAccountSimple();
    bankingAccountSimple2.id = '2';
    bankingAccountSimple2.name = 'Current Account';
    bankingAccountSimple2.balance = 2000;

    const bankingAccountSimple3 = new BankingAccountSimple();
    bankingAccountSimple3.id = '3';
    bankingAccountSimple3.name = 'Credit Card';
    bankingAccountSimple3.balance = 3000;

    this.accounts.push(bankingAccountSimple1);
    this.accounts.push(bankingAccountSimple2);
    this.accounts.push(bankingAccountSimple3);

  }




}
