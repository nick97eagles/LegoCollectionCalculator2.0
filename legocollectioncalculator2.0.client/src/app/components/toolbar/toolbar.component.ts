import { Component, OnInit } from '@angular/core';
import { SideNavService } from 'src/app/services/side-nav.service';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { CSVExtensionMethods } from 'src/app/extensions/convertToCSV.extension';
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
    private _sidenavService: SideNavService,
    private _CSVService: CSVExtensionMethods) {}

  ngOnInit(): void {
  }

  public toggleSidenav(): void {
    this._sidenavService.toggle();
  }

  public downloadList(): void {
    this._CSVService.downloadCSV(this._setDataService.setListArray, 'lego-sets', ['setId', 'setName', 'setCondition']);
  }

}
