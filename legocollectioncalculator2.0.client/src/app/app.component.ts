import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SideNavService } from './services/side-nav.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit {
  
  @ViewChild('sidenav') public sidenav!: MatSidenav

  constructor(private _sidenavService: SideNavService) {}

  ngAfterViewInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
  }
}
