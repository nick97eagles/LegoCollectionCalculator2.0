import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateUserRsModel, UserInfo } from 'src/app/models/user.models';
import { UserDataService } from 'src/app/services/userData.service';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.scss']
})
export class NewUserComponent implements OnInit {

  public newUserForm = new FormGroup({
    userName: new FormControl('', {validators:[Validators.required]}),
    password: new FormControl('', Validators.required),
    email: new FormControl('', {validators: [Validators.required]})
  });

  public newUser = {
    userId: 0,
    userName: '',
    userEmail: '',
    collectionId: 0,
    resultMessage: ''
  };

  public isDuplicateUsername: boolean = false;
  public isDuplicateEmail: boolean = false;

  constructor(
    private _router: Router,
    private _http: HttpClient,
    private _userDataService: UserDataService) { }

  ngOnInit(): void { }

  public reset(): void {
    this.newUserForm.reset();
    this.isDuplicateEmail = false;
    this.isDuplicateUsername = false;
  }

  public createUser(): void {
    if (!this.newUserForm.valid) {
      this.newUserForm.markAllAsTouched();
      return;
    }

    this.isDuplicateEmail = false;
    this.isDuplicateUsername = false;

    var newUser: Object = {
      userName: this.newUserForm.get('userName')?.value,
      password: this.newUserForm.get('password')?.value,
      email: this.newUserForm.get('email')?.value
    }

    this._http.post<CreateUserRsModel>('https://localhost:7276/User/create', newUser).subscribe((result: CreateUserRsModel) => {
      this.updateUserPage(result);
    });
  }

  private updateUserPage(result: CreateUserRsModel): void {
    switch(result.resultMessage) {
      case "UserName already exists":
        this.isDuplicateUsername = true
        break;

      case "Email already exists":
        this.isDuplicateEmail = true
        break;

      default:
        this._userDataService.setUserData(result);
        this._router.navigateByUrl("/collection");
        break;
    }


  }
}
