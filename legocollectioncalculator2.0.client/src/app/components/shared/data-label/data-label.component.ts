import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'data-label',
  templateUrl: './data-label.component.html',
  styleUrls: ['./data-label.component.scss']
})
export class DataLabelComponent implements OnInit {

  @Input() public label: string = '';
  @Input() public value: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
