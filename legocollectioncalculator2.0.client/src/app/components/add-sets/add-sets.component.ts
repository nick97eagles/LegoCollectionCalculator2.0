import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormArray, FormBuilder } from '@angular/forms';
import { CSVExtensionMethods } from 'src/app/extensions/convertToCSV.extension';
import { SetModel } from 'src/app/models/bricklink.models';
import { faCirclePlus, faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { SetDataService } from 'src/app/services/set-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'add-set',
  templateUrl: './add-sets.component.html',
  styleUrls: ['./add-sets.component.scss']
})
export class AddSetComponent implements OnInit {

  form: FormGroup = this.fb.group({
    sets: this.fb.array([])
  });
  addBtn = faCirclePlus;
  removeBtn = faTrashCan;
  canRemoveRow: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private _setDataService: SetDataService,
    private _csvExtension: CSVExtensionMethods) {}

  ngOnInit(): void {
    this.addRow();
  }

  get sets() {
    return this.form.controls['sets'] as FormArray;
  }

  public addRow(): void {
    const setForm = this.fb.group({
      setId: ['', Validators.required],
      setName: ['', Validators.required],
      setCondition: ['', Validators.required]
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
    var jsonData: SetModel[] = this.form.value.sets;

    if (this._setDataService.setListArray) {
      this.addSetsToList(jsonData);
    }
    else {
      this._csvExtension.downloadCSV(jsonData, 'lego-sets', ['setId', 'setName', 'setCondition']);
    }
  }

  private addSetsToList(sets: SetModel[]): void {
    var currentSetLength = this._setDataService.setListArray.length;
    var newSetList: any = [];
    sets.forEach(set => {
      var setModel = {
        S_No: (currentSetLength + 1).toString(),
        setId: set.setId,
        setName: set.setName,
        setCondition: set.setCondition
      };
      newSetList.push(setModel);
      currentSetLength ++;
    });
    this._setDataService.addSets(newSetList).subscribe(resp => console.log(resp));
    // this._setDataService.updateSetListArray(newSetList, 'add');
    // this.router.navigate(['/view-sets']);
  }

  private hasOneRow(): boolean {
    return this.sets.value.length > 1;
  }
}
