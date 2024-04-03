import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetSetPriceGuideRsModel, GetSetRsModel } from '../models/bricklink.models';

@Injectable({
  providedIn: 'root'
})
export class BricklinkService {

  private baseUrl = 'https://localhost:7276/bricklink/';

  constructor(private _http: HttpClient) { }

  public GetSetInfo(setId: string): Observable<GetSetRsModel> {
    return this._http.get<GetSetRsModel>(this.baseUrl + `set/${setId}`);
  }

  public GetSetPriceGuide(setId: string, n_or_u: string): Observable<GetSetPriceGuideRsModel> {
    return this._http.get<GetSetPriceGuideRsModel>(this.baseUrl + `set/priceGuide/${setId}/${n_or_u}`);
  }
}
