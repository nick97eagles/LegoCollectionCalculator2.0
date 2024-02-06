import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BricklinkService } from './services/bricklink.service';
import { ComponentsModule } from './components/components.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SetDataService } from './services/set-data.service';
import { LocalStorageService } from './services/local-storage.service';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SideNavService } from './services/side-nav.service';
import { SetInfoComponent } from './components/set-info/set-info.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ComponentsModule,
    BrowserAnimationsModule,
    MatSidenavModule
  ],
  providers: [
    LocalStorageService,
    SetDataService,
    BricklinkService,
    SideNavService,
    SetInfoComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
