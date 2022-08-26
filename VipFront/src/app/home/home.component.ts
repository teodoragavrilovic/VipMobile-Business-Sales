import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models/user/user.model';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  LoginForm!: FormGroup;
  actionBtn: string = "Priajvi se!";
  user: User = {
    username: "",
    password: ""
  };

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.LoginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    })
  }

  get username() { return this.LoginForm.get('username'); };

  get password() { return this.LoginForm.get('password'); };

  authenticate(): void {
    const params = {
      username: this.username?.value,
      password: this.password?.value
    }
    this.authService.login(params).subscribe(
      (response) => {
       // console.log(response.token);
        if (response) {
         const url = "/tariff-package";            
         localStorage.setItem('token', response.token);
         this.router.navigate([url]);
        }
      });

    }
}
