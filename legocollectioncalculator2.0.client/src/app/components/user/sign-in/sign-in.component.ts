import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRsModel, UserInfo } from 'src/app/models/user.models';
import { UserDataService } from 'src/app/services/userData.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  public isValidUser: boolean = true;
  public isCorrectPassword: boolean = true;
  public isSuccessfullLogin: boolean = false;

  public signInForm = new FormGroup({
    login: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  constructor(
    private _router: Router,
    private _httpClient: HttpClient,
    private _userDataService: UserDataService) { }

  ngOnInit(): void { }

  public reset(): void {
    this.signInForm.reset();
  }

  public signIn(): void {
    this.isCorrectPassword = true;
    this.isValidUser = true;

    // TODO: create service for http request
    const login = this.signInForm.controls.login.value!.trim();
    const password = this.signInForm.controls.password.value!.trim();
    var queryParams = new HttpParams()
        .append("Login", login)
        .append("Password", password);

    this._httpClient.get<LoginRsModel>('https://localhost:7276/user/login', {params: queryParams}).subscribe((result: LoginRsModel) => {
      this.updateUserPage(result);
    });
  }


  private updateUserPage(result: LoginRsModel): void {
    if (result.resultMessage === "No User Found") {
      this.isValidUser = false;
    }
    else if (result.resultMessage === "Incorrect Password") {
      this.isCorrectPassword = false;
    }
    else {
      this.isSuccessfullLogin = true;
      var userInfo: UserInfo = {
        userId: result.userId,
        userName: result.userName,
        userEmail: result.userEmail,
        userRole: result.userRole,
        collectionId: result.collectionId
      };

      this._userDataService.setUserData(userInfo);
      this._router.navigateByUrl('/collection');
    }
  }
}
