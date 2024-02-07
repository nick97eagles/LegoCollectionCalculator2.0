import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-edit-theme',
  templateUrl: './edit-theme.component.html',
  styleUrls: ['./edit-theme.component.scss']
})
export class EditThemeComponent implements OnInit {

  public closeIcon = faXmark;
  public isSaving: boolean = false;

  public editThemeForm = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('')
  });

  constructor(@Inject(MAT_DIALOG_DATA)
    public data: EditThemeModel,
    public dialogRef: MatDialogRef<EditThemeComponent>,
    private _http: HttpClient
  ) { }

  ngOnInit(): void {
    this.editThemeForm.get('name')?.setValue(this.data.name);
    this.editThemeForm.get('description')?.setValue(this.data.description);
  }

  public save(): void {
    if (!this.editThemeForm.valid) {
      return;
    }

    this.isSaving = true;
    var rqBody = {
      ThemeID: this.data.themeId,
      Name: this.editThemeForm.get('name')!.value,
      Description: this.editThemeForm.get('description')?.value
    };

    this._http.post('https://localhost:7276/collection/theme/edit', rqBody).subscribe(resp => {
      if (resp) {
        this.isSaving = false;
        this.dialogRef.close(true);
      }
    });
  }

  public reset(): void {
    this.editThemeForm.get('name')?.setValue(this.data.name);
    this.editThemeForm.get('description')?.setValue(this.data.description);
  }

}

export interface EditThemeModel {
  themeId: number;
  name: string;
  description: string;
}
