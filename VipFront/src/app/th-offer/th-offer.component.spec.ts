import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThOfferComponent } from './th-offer.component';

describe('ThOfferComponent', () => {
  let component: ThOfferComponent;
  let fixture: ComponentFixture<ThOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThOfferComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
