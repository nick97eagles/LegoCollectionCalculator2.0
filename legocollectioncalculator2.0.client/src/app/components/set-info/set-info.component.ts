import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetSetRsModel } from 'src/app/models/bricklink.models';
import { BricklinkService } from 'src/app/services/bricklink.service';

@Component({
  selector: 'app-set-info',
  templateUrl: './set-info.component.html',
  styleUrls: ['./set-info.component.scss']
})
export class SetInfoComponent implements OnInit {

  public setInfo: GetSetRsModel | null;

  constructor(
    private _route: ActivatedRoute,
    private _bricklinkService: BricklinkService)
  {
      this.setInfo = null;
  }

  public ngOnInit(): void {
    var setId = this._route.snapshot.queryParamMap.get('setId');

    this._bricklinkService.GetSetInfo(setId!).subscribe((resp: GetSetRsModel) => {
      this.setInfo = resp;
      console.log(this.setInfo.imageUrl);
    });
  }

}
