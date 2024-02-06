import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { PriceGuideModel, SetApiRsModel } from 'src/app/models/bricklink.models';
import { BricklinkService } from 'src/app/services/bricklink.service';

@Component({
  selector: 'app-set-info',
  templateUrl: './set-info.component.html',
  styleUrls: ['./set-info.component.scss']
})
export class SetInfoComponent implements OnInit, OnDestroy {

  setId!: number;
  destroy$: Subject<boolean> = new Subject<boolean>();
  set!: SetApiRsModel;
  priceGuide!: PriceGuideModel;

  constructor(private route: ActivatedRoute, private _bricklinkService: BricklinkService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.getSetInfo(params['id'].toString());
      this.getPriceGuide(params['id'].toString(), params['type'].toString(), params['condition'].toString());
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }

  private getSetInfo(setId: string): void {
    this._bricklinkService.getSetInfo(setId).pipe(takeUntil(this.destroy$)).subscribe((resp: SetApiRsModel) => {
      this.set = resp;
      this.set.data.name = this.findAndReplaceCodedEntity(this.set.data.name);
    });
  }

  private getPriceGuide(setId: string, type: string, condition: string): void {
    this._bricklinkService.getPriceGuide(setId, type, condition).pipe(takeUntil(this.destroy$)).subscribe(resp => {
      this.priceGuide = resp.data;
    });
  }

  private findAndReplaceCodedEntity(string: string): string {
    // HTML Code entity starts with & and ends with ;
    let entityBeginning = string.indexOf('&');
    let entityEnd = string.indexOf(';');
    let codedEntity = string.substring(entityBeginning, entityEnd + 1)
    let decodedEntity = this.decodeEntities(codedEntity);
    return string.replace(codedEntity, decodedEntity!);
  }

  private decodeEntities = (s: any) => {
    const el = document.createElement('p');
    el.innerHTML = s;
    const str = el.textContent;

    return str;
  }

}
