import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SetModel } from '../models/bricklink.models';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class SetDataService {
  private _setListArray: SetModel[] = [];
  private rootUrl = '/api';

  constructor(private _localStorageService: LocalStorageService, private _httpService: HttpClient) { }

  public set setListArray(value: SetModel[]) {
    // Empty row gets added when converting json to csv in extension method
    if (value[value.length - 1].setId == null) {
      value.pop();
    }

    // Check if list already exists before creating new one
    this._setListArray = value;
    this._localStorageService.saveData('setList', JSON.stringify(value));
  }

  public get setListArray() {
    if (this._setListArray.length == 0) {
      this._setListArray = JSON.parse(this._localStorageService.getData('setList')?.toString()!);
      return this._setListArray;
    } else {
      return this._setListArray;
    }
  }

  public updateSetListArray(newSetList: any[], methodType: string): void {

    if (methodType == 'add') {
      newSetList.forEach(set =>  {
        this.setListArray.push(set);
        this._localStorageService.saveData('setList', JSON.stringify(this.setListArray));
      });
    }
    else if (methodType == 'remove') {
      this._localStorageService.clearData();
      // renumber S_No fields
      newSetList.forEach((set, index) => {
        set.S_No = (index + 1).toString();
      });
      this._localStorageService.saveData('setList', JSON.stringify(newSetList));
    }
  }

  public addSets(sets: any): Observable<any> {
    return this._httpService.post<any>(`${this.rootUrl}/sets`, { setList: sets });
  }
}
