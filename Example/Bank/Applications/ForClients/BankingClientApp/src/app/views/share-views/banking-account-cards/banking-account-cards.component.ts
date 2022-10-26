import { Component, Input, OnInit } from '@angular/core';
import { BankingAccountSimple } from 'src/app/models/banking-accounts/banking-account-simple';

@Component({
  selector: 'app-banking-account-cards',
  templateUrl: './banking-account-cards.component.html',
  styleUrls: ['./banking-account-cards.component.scss']
})
export class BankingAccountCardsComponent implements OnInit {

  // Create property input that receives banking accounts simple

  @Input() public bankingAccountsSimple!: BankingAccountSimple;


  constructor() { }

  ngOnInit(): void {
  }

}
