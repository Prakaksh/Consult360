import { Router } from '@angular/router';
import { AuthService } from './../../services/auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { faLock } from '@fortawesome/free-solid-svg-icons';
import { ApiCallService } from 'src/app/services/api-call.service';
import { apiURL } from 'src/main';
import { FormValidationService } from 'src/app/services/form-validation.service';
import { state } from '@angular/animations';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  faLock = faLock;
  submitted: boolean = false;
  invalidPhoneNumber:boolean=false;
  loginForm = new FormGroup({
    phoneNumber: new FormControl('')
  });
  constructor(private auth: AuthService, private router: Router
    , private api: ApiCallService
    , private fv: FormValidationService) { }

  ngOnInit(): void {
    if (this.auth.isLoggedIn()) {
      this.router.navigate(['admin']);
    }
  }
  onSubmit(): void {
    debugger
    if (this.loginForm.invalid) return
    const phoneNumber = this.loginForm?.value.phoneNumber.toString();
    this.api.get(`${apiURL.validatePhoneNumber}/${phoneNumber}`).subscribe((res: any) => {
      debugger
      if (res.result) {
        this.router.navigate(['otp'],{ state: { phoneNumber: phoneNumber }});
      }
else{
  this.invalidPhoneNumber=true
}
    })



  }


  // convenience getter for easy access to form fields
  get f() {
    return this.loginForm.controls;
  }

  // Form Validation Call the Global service Method
  hasFieldError(fieldName: any): boolean {
    return this.fv.hasFieldError(fieldName, this.submitted);
  }

}
