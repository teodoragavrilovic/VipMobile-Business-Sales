import { TestBed } from '@angular/core/testing';

import { TariffPackageService } from './tariff-package.service';

describe('TariffPackageService', () => {
  let service: TariffPackageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TariffPackageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
