import { Component, OnInit } from '@angular/core';
import { SideNavService } from 'src/app/services/side-nav.service';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { SetDataService } from '../../services/set-data.service';

@Component({
  selector: 'toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  menuIcon = faBars;

  constructor(
    private _setDataService: SetDataService,
    private _sidenavService: SideNavService) {}

  ngOnInit(): void {
  }

  public toggleSidenav(): void {
    this._sidenavService.toggle();
  }

}
