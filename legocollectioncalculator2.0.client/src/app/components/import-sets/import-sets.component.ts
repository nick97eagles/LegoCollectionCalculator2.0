import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SetDataService } from 'src/app/services/set-data.service';

@Component({
  selector: 'import-sets',
  templateUrl: './import-sets.component.html',
  styleUrls: ['./import-sets.component.scss']
})
export class ImportSetsComponent implements OnInit {

  constructor(private _setDataService: SetDataService, private router: Router) { }

  ngOnInit(): void {
  }

  public convert(objArray: any) {
    this._setDataService.setListArray = objArray.result;
    this.router.navigate(['/view-sets']);
  }

  public onError(err: any) {
    console.error(err);
  }

}
