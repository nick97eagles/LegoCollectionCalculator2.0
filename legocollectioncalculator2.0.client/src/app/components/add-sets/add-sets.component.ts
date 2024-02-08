import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormArray, FormBuilder } from '@angular/forms';
import { SetModel } from 'src/app/models/bricklink.models';
import { faCirclePlus, faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { SetDataService } from 'src/app/services/set-data.service';
import { Router } from '@angular/router';
import { AddSetsRqModel } from 'src/app/models/collection.models';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'add-set',
  templateUrl: './add-sets.component.html',
  styleUrls: ['./add-sets.component.scss']
})
export class AddSetComponent implements OnInit {

  public addBtn = faCirclePlus;
  public removeBtn = faTrashCan;
  public canRemoveRow: boolean = false;

  public form: FormGroup = this.fb.group({
    sets: this.fb.array([])
  });

  public themeID: number;
  public themeName: string;
  public isSaving: boolean = false;

  constructor(
    private fb: FormBuilder,
    private _router: Router,
    private _http: HttpClient,
    private _setDataService: SetDataService
  ) {
    this.themeID = history.state.themeID;
    this.themeName = history.state.themeName;
  }

  ngOnInit(): void {
    this.addRow();
  }

  get sets() {
    return this.form.controls['sets'] as FormArray;
  }

  public addRow(): void {
    const setForm = this.fb.group({
      identificationNum: ['', Validators.required],
      name: ['', Validators.required],
      condition: ['', Validators.required]
    });

    this.sets.push(setForm);
    this.canRemoveRow = this.hasOneRow();
  }

  public removeRow(index: number) {
    this.sets.removeAt(index);
    this.canRemoveRow = this.hasOneRow();
  }

  public resetForm(): void {
    this.form.reset();
  }

  public addSets(): void {
    this.isSaving = true;

    var rqBody: AddSetsRqModel = {
      themeID: this.themeID,
      sets: this.form.get('sets')?.value
    };

    this._http.post('https://localhost:7276/collection/set', rqBody).subscribe(resp => {
      this.isSaving = false;
      if (resp) {
        this._router.navigate(
          ['/sets'],
          {
            queryParams: { theme: this.themeName },
            state: { themeID: this.themeID, themeName: this.themeName}
          }
        )
      }
    });
  }

  private hasOneRow(): boolean {
    return this.sets.value.length > 1;
  }
}
