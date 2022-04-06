import { Injectable } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FormValidationService {

  constructor() { }

  // Global service  for Form Validation
  hasFieldError(fieldName: FormControl, submitted: boolean): boolean {
    return fieldName.invalid && (submitted || fieldName.touched || fieldName.dirty);
  }

}


// export function passwordMatchValidator(control: AbstractControl) {
//   const password: string = control.get('newPassword').value; // get password from our password form control
//   const confirmPassword: string = control.get('retryPassword').value; // get password from our confirmPassword form control
//   // compare is the password math
//   if (password !== confirmPassword) {
//     // if they don't match, set an error in our confirmPassword form control
//     control.get('retryPassword').setErrors({ NoPassswordMatch: true });
//   }
// }

// export function ConfirmPasswordValidator(controlName: string, matchingControlName: string) {
//   return (formGroup: FormGroup) => {
//     let control = formGroup.controls[controlName];
//     let matchingControl = formGroup.controls[matchingControlName]
//     if (
//       matchingControl?.errors &&
//       !matchingControl?.errors.confirmPasswordValidator
//     ) {
//       return;
//     }
//     if (control?.value !== matchingControl?.value) {
//       matchingControl?.setErrors({ confirmPasswordValidator: true });
//     } else {
//       matchingControl?.setErrors(null);
//     }
//   };
// }

// export function patternValidator(regex: RegExp, error: ValidationErrors): ValidatorFn {
//   return (control: AbstractControl): { [key: string]: any } => {
//     if (!control.value) {
//       // if control is empty return no error
//       return null;
//     }

//     // test the value of the control against the regexp supplied
//     const valid = regex.test(control.value);

//     // if true, return no error (no error), else return error passed in the second parameter
//     return valid ? null : error;
//   };
// }


export function sumOf100Percent(controlName: string, matchingControlName: string) {
  return (formGroup: FormGroup) => {
    let sum = 0;
    let controlForm2 = formGroup.controls[matchingControlName]
    sum = formGroup.controls[controlName]?.value + formGroup.controls[matchingControlName]?.value;
    return sum > 100 ? controlForm2?.setErrors({ notValidSum: true }) : controlForm2?.setErrors(null);
  }
}
