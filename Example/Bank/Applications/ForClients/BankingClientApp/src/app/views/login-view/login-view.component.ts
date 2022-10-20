import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { LoginService } from 'src/app/services/api/login/login.service';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.scss']
})
export class LoginViewComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService) { }

  public checkoutForm = this.formBuilder.group({
    email: '',
    password: ''
  });


  ngOnInit(): void {
  }

  // Create method that checks if user is logged in
  public isLoggedIn(): boolean {

    if(this.isValueInLocalStorage("")) {
      return true;
    }



    return false;
  }

  // Create method that checks if value is in local storage
  public isValueInLocalStorage(value: string): boolean {
    // Get value from local storage
    const email = localStorage.getItem('email');
    if(email != null && email != undefined) {
      return true;
    }
    return false;
  }



  public onSubmit(): void {

    // Store in local storage for now (until we have a database)

    const email = this.checkoutForm.get('email')?.value;
    const password = this.checkoutForm.get('password')?.value;

    if(email != null && email != undefined && password != null && password != undefined) {
      this.loginService.login(email, password);/*.subscribe((response: any) => {
        console.log('response: ', response);
      });*/
    }



    // go to accounts page
    //window.location.href = '/accounts';



  }

}
