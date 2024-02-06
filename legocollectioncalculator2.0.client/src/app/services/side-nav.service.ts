import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Injectable({
  providedIn: 'root'
})
export class SideNavService {

  private sidenav!: MatSidenav;

  public setSidenav(sidenave: MatSidenav) {
    this.sidenav = sidenave;
  }

  public open() {
    return this.sidenav.open();
  }

  public close() {
    return this.sidenav.close();
  }

  public toggle(): void {
    this.sidenav.toggle();
  }

  public isOpen(): boolean {
    return this.sidenav.opened;
  }
}
