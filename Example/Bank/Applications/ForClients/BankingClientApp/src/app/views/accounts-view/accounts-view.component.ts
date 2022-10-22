import { SessionService } from 'src/app/services/session/session.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-accounts-view',
  templateUrl: './accounts-view.component.html',
  styleUrls: ['./accounts-view.component.scss']
})
export class AccountsViewComponent implements OnInit {

  constructor(private sessionService: SessionService) { }

  ngOnInit(): void {
  }

  // Create method that logs user out
  public logout(): void {
    this.sessionService.clearUserSession();
  }




}
