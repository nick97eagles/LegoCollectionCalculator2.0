import { Component, OnInit } from '@angular/core';
import { SideNavService } from 'src/app/services/side-nav.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {

  constructor(private _sidenavService: SideNavService) { }

  ngOnInit(): void {
  }

  public isOpen(): void {
    if (this._sidenavService.isOpen()) {
      this._sidenavService.close();
    }
  }

}
