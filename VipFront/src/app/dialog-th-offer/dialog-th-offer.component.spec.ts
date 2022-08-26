import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogThOfferComponent } from './dialog-th-offer.component';

describe('DialogThOfferComponent', () => {
  let component: DialogThOfferComponent;
  let fixture: ComponentFixture<DialogThOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogThOfferComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogThOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
