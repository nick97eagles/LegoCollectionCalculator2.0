import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GetSetModel, GetSetsRsModel } from 'src/app/models/collection.models';
import { faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmModalComponent } from '../confirm-modal/confirm-modal.component';

@Component({
  selector: 'app-sets',
  templateUrl: './sets.component.html',
  styleUrls: ['./sets.component.scss']
})
export class SetsComponent implements OnInit {

  public deleteIcon = faTrashCan;
  public setList: GetSetModel[] = []
  public themeName: string;
  public displayedColumns: string[] = [
    'setId', 'setName', 'setCondition', 'deleteSet'
  ];

  private themeID: number;

  constructor(
    private _router: Router,
    private _http: HttpClient,
    private _dialog: MatDialog
  ) {
    this.themeID = history.state.themeID;
    this.themeName = history.state.themeName;
   }

  ngOnInit(): void {
    this.getSets(this.themeID);
  }


  public addSets(): void {
    this._router.navigate(
      ['/add-sets'], {
        queryParams: { theme: this.themeName},
        state: {
          themeID: this.themeID,
          themeName: this.themeName
        }
      }
    );
  }

  public deleteSet(setID: number): void {
    var confirmModel = this._dialog.open(ConfirmModalComponent, {
      data: {
        title: 'Permanent Action',
        message: 'Are you sure you want to delete this set from your theme?'
      },
      disableClose: true
    });

    confirmModel.afterClosed().subscribe(isConfirmed => {
      if (isConfirmed === "true") {
        this._http.delete(`https://localhost:7276/collection/set/${setID}`).subscribe(resp => {
          if (resp) {
            this.getSets(this.themeID);
          }
        });
      }
    })
  }

  private getSets(themeID: number): void {
    var queryParams = new HttpParams()
    .append('themeID', this.themeID);

    this._http.get<GetSetsRsModel>('https://localhost:7276/collection/set', {params: queryParams}).subscribe((resp: GetSetsRsModel) => {
      console.log(resp);
      this.setList = resp.sets;
    });
  }
}
