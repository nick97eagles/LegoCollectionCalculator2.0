import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule} from '@angular/material/input';
import { AddSetComponent } from './add-sets/add-sets.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatButtonModule} from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { ImportSetsComponent } from './import-sets/import-sets.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ViewSetsComponent } from './view-sets/view-sets.component';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { SetInfoComponent } from './set-info/set-info.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SideNavComponent } from './side-nav/side-nav.component';
import { ConfirmModalComponent } from './confirm-modal/confirm-modal.component';
import { NewUserComponent } from './user/new-user/new-user.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { CollectionComponent } from './collection/collection.component';


@NgModule({
  declarations: [
    AddSetComponent,
    ImportSetsComponent,
    HomeComponent,
    ViewSetsComponent,
    SetInfoComponent,
    ToolbarComponent,
    SideNavComponent,
    ConfirmModalComponent,
    NewUserComponent,
    SignInComponent,
    CollectionComponent,
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    MatButtonModule,
    ReactiveFormsModule,
    RouterModule,
    FontAwesomeModule,
    MatTableModule,
    MatDialogModule,
    MatToolbarModule,
    MatSidenavModule
  ],
  exports: [
    ToolbarComponent,
    SideNavComponent
  ]
})
export class ComponentsModule { }
