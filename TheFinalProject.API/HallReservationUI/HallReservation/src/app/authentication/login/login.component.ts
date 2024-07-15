import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  constructor(private fb: FormBuilder) {}

  userForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: [''],
    address: this.fb.group({
      // <- another group of element
      street: [''],
      postCode: ['', Validators.required],
    }),
  });

  addUser() {
    console.log(this.userForm.value);
  }
}
