import { afterNextRender, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  RememberMe = 'true';
  userForm = this.fb.group({
    userName: ['', Validators.required],
    password: ['', Validators.required],
    RememberMe: new FormControl<string[]>([]),
  });

  constructor(private fb: FormBuilder) {
    afterNextRender(() => {
      const userName = localStorage.getItem('userName');
      const password = localStorage.getItem('password');
      const rememberMe = localStorage.getItem('rememberMe');
      if (rememberMe) {
        const array = [];
        array.push('true');
        this.userForm.patchValue({ RememberMe: array });
      }
      if (userName && password) {
        try {
          this.userForm.patchValue({ userName: userName });
          this.userForm.patchValue({ password: password });
        } catch (err) {}
      }
    });
  }

  Submit() {
    if (this.userForm.value?.RememberMe?.length != 0) {
      localStorage.setItem('userName', this.userForm.value.userName!);
      localStorage.setItem('password', this.userForm.value.password!);
      localStorage.setItem('rememberMe', 'true');
    } else {
      localStorage.removeItem('userName');
      localStorage.removeItem('password');
      localStorage.removeItem('rememberMe');
    }
  }
}
