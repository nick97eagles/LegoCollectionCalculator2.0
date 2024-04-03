import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetSetPriceGuideRsModel, GetSetRsModel } from 'src/app/models/bricklink.models';
import { BricklinkService } from 'src/app/services/bricklink.service';

@Component({
  selector: 'app-set-info',
  templateUrl: './set-info.component.html',
  styleUrls: ['./set-info.component.scss']
})
export class SetInfoComponent implements OnInit {

  public setInfo: GetSetRsModel | null;
  public priceGuide: GetSetPriceGuideRsModel | null;

  constructor(
    private _route: ActivatedRoute,
    private _bricklinkService: BricklinkService)
  {
      this.setInfo = null;
      this.priceGuide = null;
  }

  public ngOnInit(): void {
    var setId = this._route.snapshot.queryParamMap.get('setId');
    var setCondition = this._route.snapshot.queryParamMap.get('setCondition');

    this._bricklinkService.GetSetInfo(setId!).subscribe((resp: GetSetRsModel) => {
      this.setInfo = resp;
      this.setInfo.name = this.convertStringWithCharCode(this.setInfo.name);
    });

    this._bricklinkService.GetSetPriceGuide(setId!, setCondition!).subscribe((resp: GetSetPriceGuideRsModel) => {
      this.priceGuide = resp;
    })
  }

  private getCharCode(value: string): string {
    return value.substring(
      value.indexOf('&') + 2,
      value.lastIndexOf(';')
    );
  }

  private convertStringWithCharCode(value: string): string {
    var newValue = value;

    if (value.includes('&') && value.includes(';')) {
      var charCode = this.getCharCode(value);
      var charCodeValue = String.fromCharCode(Number(charCode));
      var charCodeSubString = value.substring(
        value.indexOf('&'),
        value.lastIndexOf(';') + 1
      );

      newValue = value.replace(charCodeSubString, charCodeValue);
    }

    return newValue;
  }
}
