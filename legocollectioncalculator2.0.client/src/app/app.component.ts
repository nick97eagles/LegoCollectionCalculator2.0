import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SideNavService } from './services/side-nav.service';
import { Router } from '@angular/router';
import { UserDataService } from './services/userData.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, AfterViewInit {

  private isSignedIn: boolean;
  
  @ViewChild('sidenav') public sidenav!: MatSidenav

  constructor(
    private _router: Router,
    private _sidenavService: SideNavService,
    private _userDataService: UserDataService) {
      this.isSignedIn = this._userDataService.isSignedIn;
     }

  ngOnInit(): void {
    this._userDataService.isSignedInObserver.subscribe(value => {
      this.isSignedIn = value;
    });


    if (this.isSignedIn) {
      this._router.navigateByUrl('/collection');
    }
    else {
      this._router.navigateByUrl('/sign-in');
    }
  }

  ngAfterViewInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
  }
}
