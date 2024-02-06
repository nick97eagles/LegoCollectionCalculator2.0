import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SetModel } from 'src/app/models/bricklink.models';
import { SetDataService } from 'src/app/services/set-data.service';
import { faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmModalComponent } from '../confirm-modal/confirm-modal.component';

@Component({
  selector: 'view-sets',
  templateUrl: './view-sets.component.html',
  styleUrls: ['./view-sets.component.scss']
})
export class ViewSetsComponent implements OnInit {

  shouldNavigate: boolean = true;
  deleteIcon = faTrashCan;
  setsList: SetModel[] = [];
  displayedColumns: string[] = ['S_No', 'setId', 'setName', 'setCondition', 'deleteSet'];

  constructor(
    private router: Router,
    private dialog: MatDialog,
    private _setDataService: SetDataService) {}

  ngOnInit(): void {
    this.setsList = this._setDataService.setListArray
  }

  public viewSetPage(row: SetModel) {
    if (this.shouldNavigate) {
      this.router.navigate(['/set-info'], { queryParams: {id: row.setId, type: 'SET', condition: row.setCondition}});
    }
  }

  public removeSet(setId: string): void {
    this.shouldNavigate = false;
    let confirmModal = this.dialog.open(ConfirmModalComponent, {
      width: '350px'
    });

    confirmModal.afterClosed().subscribe(shouldRemove => {
      this.shouldNavigate = true;
      if (shouldRemove == 'true') {
        const index = this.setsList.findIndex((object) => {
          return object.setId == setId;
        });
        this.setsList.splice(index, 1);
        this.setsList = [...this.setsList];
        //TODO: prompt to download new .csv
        this._setDataService.updateSetListArray(this.setsList, 'remove');
      }
    });
  }
}
