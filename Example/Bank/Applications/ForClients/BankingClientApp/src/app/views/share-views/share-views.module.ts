import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainUpBarComponent } from './main-up-bar/main-up-bar.component';
import { MainSideBarComponent } from './main-side-bar/main-side-bar.component';
import { BankingAccountCardsComponent } from './banking-account-cards/banking-account-cards.component';



@NgModule({
  declarations: [
    MainUpBarComponent,
    MainSideBarComponent,
    BankingAccountCardsComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MainUpBarComponent,
    MainSideBarComponent,
    BankingAccountCardsComponent
  ]
})
export class ShareViewsModule { }
