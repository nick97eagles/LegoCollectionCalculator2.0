import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSetsComponent } from './view-sets.component';

describe('ViewSetsComponent', () => {
  let component: ViewSetsComponent;
  let fixture: ComponentFixture<ViewSetsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewSetsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewSetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
