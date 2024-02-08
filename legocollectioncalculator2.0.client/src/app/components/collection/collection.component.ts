import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserDataService } from 'src/app/services/userData.service';
import { AddThemeComponent } from '../add-theme/add-theme.component';
import { HttpClient, HttpParams } from '@angular/common/http';
import { GetThemesRsModel, Theme } from 'src/app/models/collection.models';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faMarker } from '@fortawesome/free-solid-svg-icons';
import { ConfirmModalComponent } from '../confirm-modal/confirm-modal.component';
import { EditThemeComponent } from './modals/edit-theme/edit-theme.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-collection',
  templateUrl: './collection.component.html',
  styleUrls: ['./collection.component.scss']
})
export class CollectionComponent implements OnInit {

  public themes: Theme[] = [];
  public trashIcon = faTrash;
  public editIcon = faMarker;

  private collectionId: number;
  private shouldOpenTheme: boolean = true;

  constructor(
    private _router: Router,
    private _http: HttpClient,
    private dialog: MatDialog,
    private _userDataService: UserDataService
  ) { 
    this.collectionId = this._userDataService.getUserData()!.collectionId;
  }

  ngOnInit(): void {
    this.getThemes(this.collectionId);
  }

  public addTheme(): void {
    var collectionId = this._userDataService.getUserData()!.collectionId;

    var modal = this.dialog.open(AddThemeComponent, {
      data: { collectionId: collectionId},
      disableClose: true,
      width: '300px',
      height: '350px'
    });

    modal.afterClosed().subscribe(isNewTheme => {
      if (isNewTheme) {
        this.getThemes(this.collectionId);
      }
    });
  }

  public openTheme(theme: Theme): void {
    if (this.shouldOpenTheme) {
      this._router.navigate(
        ['/sets'],
        {
          queryParams: { theme: theme.name },
          state: { 
            themeID: theme.themeID,
            themeName: theme.name
          }
        },

      )
    }
  }

  public editTheme(theme: Theme): void {
    this.shouldOpenTheme = false;
    
    var editThemeModal = this.dialog.open(EditThemeComponent, {
      data: {
        themeId: theme.themeID,
        name: theme.name,
        description: theme.description
      },
      disableClose: true
    });

    editThemeModal.afterClosed().subscribe(isSaved => {
      console.log(isSaved);
      if (isSaved === true) {
        this.getThemes(this.collectionId);
      }
    })

    setTimeout(() => {
      this.shouldOpenTheme = true;
      console.log('open');
    }, 3000)
  }

  public deleteTheme(themeId: number): void {
    this.shouldOpenTheme = false;

    var confirmModal = this.dialog.open(ConfirmModalComponent, {
      data: {
        title: "Permanent Action",
        message: "Are you sure you want to delete this theme?"
      },
      disableClose: true
    });

    confirmModal.afterClosed().subscribe(isConfirmed => {
      this.shouldOpenTheme = true;
      if (isConfirmed === "true") {
        this._http.delete(`https://localhost:7276/collection/theme/${themeId}`).subscribe(result => {
          this.getThemes(this.collectionId);
        })
      }
    });
  }

  private getThemes(collectionId: number): void {
    var queryParams = new HttpParams()
    .append("CollectionID", collectionId);

    this._http.get<GetThemesRsModel>('https://localhost:7276/collection/theme', {params: queryParams})
    .subscribe((result: GetThemesRsModel) => {
      this.themes = result.themes;
    });
  }

}
