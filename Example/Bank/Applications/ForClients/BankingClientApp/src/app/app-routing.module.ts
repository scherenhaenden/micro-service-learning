import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountsViewComponent } from './views/accounts-view/accounts-view.component';
import { LoginViewComponent } from './views/login-view/login-view.component';

const routes: Routes = [
  { path: 'login', component: LoginViewComponent  },
  { path: 'accounts', component: AccountsViewComponent  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
