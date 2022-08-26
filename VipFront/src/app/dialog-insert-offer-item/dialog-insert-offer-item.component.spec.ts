import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogInsertOfferItemComponent } from './dialog-insert-offer-item.component';

describe('DialogInsertOfferItemComponent', () => {
  let component: DialogInsertOfferItemComponent;
  let fixture: ComponentFixture<DialogInsertOfferItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogInsertOfferItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogInsertOfferItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
