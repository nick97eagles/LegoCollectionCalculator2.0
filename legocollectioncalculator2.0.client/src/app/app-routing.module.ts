import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSetComponent } from './components/add-sets/add-sets.component';
import { HomeComponent } from './components/home/home.component';
import { ImportSetsComponent } from './components/import-sets/import-sets.component';
import { SetInfoComponent } from './components/set-info/set-info.component';
import { ViewSetsComponent } from './components/view-sets/view-sets.component';
import { NewUserComponent } from './components/user/new-user/new-user.component';
import { SignInComponent } from './components/user/sign-in/sign-in.component';
import { CollectionComponent } from './components/collection/collection.component';
import { SetsComponent } from './components/sets/sets.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'add-sets',
    component: AddSetComponent
  },
  {
    path: 'import-sets',
    component: ImportSetsComponent
  },
  {
    path: 'set-info',
    component: SetInfoComponent
  },
  {
    path: 'new-user',
    component: NewUserComponent
  },
  {
    path: 'sign-in',
    component: SignInComponent
  },
  {
    path: 'collection',
    component: CollectionComponent
  },
  {
    path: 'sets',
    component: SetsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
