import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { faLock } from '@fortawesome/free-solid-svg-icons';
import { ApiCallService } from 'src/app/services/api-call.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { apiURL } from 'src/main';

@Component({
  selector: 'app-otp-validation',
  templateUrl: './otp-validation.component.html',
  styleUrls: ['./otp-validation.component.scss']
})
export class OtpValidationComponent implements OnInit {

  faLock = faLock;
  state: any;
  invalidOTP: boolean = false;
  loginForm = new FormGroup({
    otp: new FormControl('')
  });
  constructor(private auth: AuthService, private router: Router
    , private api: ApiCallService) { }

  ngOnInit(): void {
    if (this.auth.isLoggedIn()) {
      this.router.navigate(['admin']);
    }
  }
  onSubmit(): void {
    debugger
    this.state = window.history.state;

    if (this.loginForm.invalid) return
    const otp = {
      PhoneNumber: this.state?.phoneNumber,
      OTP: this.loginForm?.value.otp

    }

    this.loginService(otp);


  }

  loginService(login: any) {
    this.api.postwithoutHeader(apiURL.token, login)
      .subscribe(res => {
        debugger;
        localStorage.setItem('token', res.body?.token);
        localStorage.setItem('access', JSON.stringify(res.body?.access));
        //
        // based on Role Navigation Page will appear
        if (res.body?.access.portalUserRole_Name.toLowerCase() === 'patient') {
          this.router.navigate(['patient']);
        }

        if (res.body?.access.portalUserRole_Name.toLowerCase() === 'poraladmin') {
          this.router.navigate(['admin']);
        }

        if (res.body?.access.portalUserRole_Name.toLowerCase() === 'doctor') {
          this.router.navigate(['doctor']);
        }


      },
        error => {
          debugger
          // this.loading = false;
          if (error.status === 401) {
            this.invalidOTP = true;
          }
        }
      )
  }

}
