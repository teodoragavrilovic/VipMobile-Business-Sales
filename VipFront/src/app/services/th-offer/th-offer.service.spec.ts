import { TestBed } from '@angular/core/testing';

import { ThOfferService } from './th-offer.service';

describe('ThOfferService', () => {
  let service: ThOfferService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ThOfferService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
