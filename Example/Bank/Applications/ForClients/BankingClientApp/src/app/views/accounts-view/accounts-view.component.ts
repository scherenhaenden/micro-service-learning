import { SessionService } from 'src/app/services/session/session.service';
import { Component, OnInit } from '@angular/core';
import { BankingAccountSimple } from 'src/app/models/banking-accounts/banking-account-simple';
import { BankingTransaction } from 'src/app/models/banking-accounts/banking-transaction';
import { BankingAccountComplete } from 'src/app/models/banking-accounts/banking-account-complete';
import { BankingAccountCompactModel } from 'src/app/models/banking-accounts/banking-account-compact-model';

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

  public accountsV2: BankingAccountCompactModel [] = [];

  // Create method that logs user out
  public logout(): void {
    this.sessionService.clearUserSession();
  }

  public loadSomeData(): void {

  // Mock banking accounts simple V2 BankingAccountSimpleV2
  // Create one
  const accountV2_1 = new BankingAccountCompactModel();
  accountV2_1.userId = '123';
  accountV2_1.accountId = '123';
  accountV2_1.name = 'My account';
  accountV2_1.balance = 100;
  accountV2_1.currency = 'EUR';
  accountV2_1.isDefault = true;
  accountV2_1.isArchived = false;
  accountV2_1.isCurrencyTypeCode = 'EUR';
  accountV2_1.isDeleted = false;
  accountV2_1.type = 'Current';

  const accountV2_2 = new BankingAccountCompactModel();
  accountV2_2.userId = '123';
  accountV2_2.accountId = '123';
  accountV2_2.name = 'My account';
  accountV2_2.balance = 100;
  accountV2_2.currency = 'EUR';
  accountV2_2.isDefault = true;
  accountV2_2.isArchived = false;
  accountV2_2.isCurrencyTypeCode = 'EUR';
  accountV2_2.isDeleted = false;
  accountV2_2.type = 'Current';

  const accountV2_3 = new BankingAccountCompactModel();
  accountV2_3.userId = '123';
  accountV2_3.accountId = '123';
  accountV2_3.name = 'My account';
  accountV2_3.balance = 100;
  accountV2_3.currency = 'EUR';
  accountV2_3.isDefault = true;
  accountV2_3.isArchived = false;
  accountV2_3.isCurrencyTypeCode = 'EUR';
  accountV2_3.isDeleted = false;
  accountV2_3.type = 'Current';


  // Add to array

  this.accountsV2.push(accountV2_1);
  this.accountsV2.push(accountV2_2);
  this.accountsV2.push(accountV2_3);
















    // Mock banking accounts simple
    const bankingAccountSimple1 = new BankingAccountSimple();
    bankingAccountSimple1.id = '1';
    bankingAccountSimple1.name = 'Savings Account';
    bankingAccountSimple1.balance = 1000;
    bankingAccountSimple1.currency = 'USD';
    bankingAccountSimple1.isDefault = true;
    bankingAccountSimple1.isBlocked = false;
    bankingAccountSimple1.isArchived = false;
    bankingAccountSimple1.isCurrencyType = 'USD';
    bankingAccountSimple1.isCurrencyTypeCode = 'USD';
    bankingAccountSimple1.isDeleted = false;

    console.log('bankingAccountSimple1', bankingAccountSimple1);
    console.log('bankingAccountSimple1', JSON.stringify(bankingAccountSimple1));

    const bankingTransaction = new BankingTransaction();
    bankingTransaction.id = '1';
    bankingTransaction.date = new Date();
    bankingTransaction.description = 'Salary';
    bankingTransaction.amount = 1000;
    bankingTransaction.currency = 'USD';
    bankingTransaction.type = 'Credit';
    bankingTransaction.isBlocked = false;
    bankingTransaction.relatedTransactionAccountNumber = '123456789';


    console.log('bankingTransaction', bankingTransaction);
    console.log('bankingTransaction', JSON.stringify(bankingTransaction));

    const bankingAccountComplete : BankingAccountComplete = bankingAccountSimple1 as BankingAccountComplete;
    bankingAccountComplete.accountNumber = '123456789';
    bankingAccountComplete.transactions = [bankingTransaction];

    console.log('bankingAccountComplete', bankingAccountComplete);
    console.log('bankingAccountComplete', JSON.stringify(bankingAccountComplete));




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
