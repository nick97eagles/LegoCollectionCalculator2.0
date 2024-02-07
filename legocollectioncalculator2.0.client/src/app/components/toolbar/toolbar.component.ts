import { Component, OnInit } from '@angular/core';
import { SideNavService } from 'src/app/services/side-nav.service';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { UserDataService } from 'src/app/services/userData.service';
import { Router } from '@angular/router';

@Component({
  selector: 'toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  public menuIcon = faBars;
  public isSignedIn: boolean = false;
  public userName: string = '';

  constructor(
    private _router: Router,
    private _userDataService: UserDataService,
    private _sidenavService: SideNavService) {}

  ngOnInit(): void {
    this.isSignedIn = this._userDataService.isSignedIn;
    this.userName = this.isSignedIn
        ? this._userDataService.getUserData()!.userName
        : '';

    this._userDataService.isSignedInObserver.subscribe(isSignedIn => {
      this.isSignedIn = isSignedIn;  

      if (!isSignedIn) {
        this.userName = '';
      }
      else {
        this.userName = this._userDataService.getUserData()!.userName;
      }
    });
  }

  public toggleSidenav(): void {
    this._sidenavService.toggle();
  }

  public signOut(): void {
    this._userDataService.clearUserData();
    this._userDataService.isSignedIn = false;
    this._router.navigateByUrl("/sign-in");
  }

}
