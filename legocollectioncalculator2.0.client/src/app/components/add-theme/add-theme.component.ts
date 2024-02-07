import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateThemeRsModel } from 'src/app/models/collection.models';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-add-theme',
  templateUrl: './add-theme.component.html',
  styleUrls: ['./add-theme.component.scss']
})
export class AddThemeComponent implements OnInit {

  public isSaving: boolean = false;
  public closeIcon = faXmark;

  public addThemeForm = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('')
  });

  constructor(
    private _http: HttpClient,
    public dialogRef: MatDialogRef<AddThemeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { collectionId: number }) { }

  ngOnInit(): void {
  }

  public save(): void {
    if (!this.addThemeForm.valid) {
      this.addThemeForm.markAllAsTouched();
      return;
    }

    this.isSaving = true;

    var newTheme: Object = {
      CollectionID: this.data.collectionId,
      ThemeName: this.addThemeForm.get('name')!.value,
      ThemeDescription: this.addThemeForm.get('description')?.value
    };

    this._http.post<CreateThemeRsModel>('https://localhost:7276/collection/theme/create', newTheme)
      .subscribe((result: CreateThemeRsModel) => {
        this.isSaving = false;
        this.dialogRef.close(true);
      });
  }

}
