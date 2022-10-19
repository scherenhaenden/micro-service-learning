import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.scss']
})
export class LoginViewComponent implements OnInit {

  constructor( private formBuilder: FormBuilder) { }

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
    // Process checkout data here
    console.warn('Your order has been submitted', this.checkoutForm);

    // Get value from control in form
    console.log('this.checkoutForm.get(\'email\')?.value: ', this.checkoutForm.get('email')?.value);

    // Store in local storage for now (until we have a database)

    const email = this.checkoutForm.get('email')?.value;

    if(email != null && email != undefined) {
      localStorage.setItem('email', email);
    }

    // go to accounts page
    window.location.href = '/accounts';



  }

}
