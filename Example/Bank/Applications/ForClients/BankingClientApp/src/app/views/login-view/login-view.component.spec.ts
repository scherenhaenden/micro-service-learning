import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ApiBaseService } from './../../services/api/generic/api-base.service';
import { FormBuilder } from '@angular/forms';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LoginViewComponent } from './login-view.component';
import { LoginService } from 'src/app/services/api/login/login.service';
import { SessionService } from 'src/app/services/session/session.service';
import { TokenAuthenticationServiceService } from 'src/app/services/security/token-authentication-service.service';
import { RouterTestingModule } from '@angular/router/testing';
import {HttpClientTestingModule} from '@angular/common/http/testing'

describe('LoginViewComponent', () => {
  let component: LoginViewComponent;
  let fixture: ComponentFixture<LoginViewComponent>;


  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginViewComponent ],
      providers:  [
        ApiBaseService,
        LoginService,
        HttpClient,
        TokenAuthenticationServiceService,
        SessionService,
        FormBuilder,
    ],
    imports: [
      RouterTestingModule,
      HttpClientTestingModule ,
      HttpClientModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
