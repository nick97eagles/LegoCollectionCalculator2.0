import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetSetRsModel } from '../models/bricklink.models';

@Injectable({
  providedIn: 'root'
})
export class BricklinkService {

  private baseUrl = 'https://localhost:7276/bricklink/';

  constructor(private _http: HttpClient) { }

  public GetSetInfo(setId: string): Observable<GetSetRsModel>{
    return this._http.get<GetSetRsModel>(this.baseUrl + `set/${setId}`);
  }

}
