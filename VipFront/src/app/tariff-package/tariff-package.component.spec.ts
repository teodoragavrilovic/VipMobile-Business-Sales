import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TariffPackageComponent } from './tariff-package.component';

describe('TariffPackageComponent', () => {
  let component: TariffPackageComponent;
  let fixture: ComponentFixture<TariffPackageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TariffPackageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TariffPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
