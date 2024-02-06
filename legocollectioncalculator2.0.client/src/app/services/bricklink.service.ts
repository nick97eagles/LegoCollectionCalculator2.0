import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SetApiRsModel } from '../models/bricklink.models';

@Injectable({
  providedIn: 'root'
})
export class BricklinkService {

  rootUrl = '/api';

  constructor(private _httpService: HttpClient) { }

  public getMinifigInfo(minifigId: string): Observable<any> {
    const params = new HttpParams().set('minifigId', minifigId);
    return this._httpService.get(`${this.rootUrl}/minifig/info`, {params});
  }

  public getSetInfo(setId: string): Observable<SetApiRsModel> {
    const params = new HttpParams().set('setId', setId);
    return this._httpService.get<SetApiRsModel>(`${this.rootUrl}/set/info`, {params});
  }

  public getPriceGuide(id: string, type: string, condition: string): Observable<any> {
    const params = new HttpParams({
      fromObject: {
        id: id,
        type: type,
        condition: condition == 'Used' ? 'U' : 'N'
      }
    });
    
    return this._httpService.get(`${this.rootUrl}/priceguide`, {params});
  }
}
