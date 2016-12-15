/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RechnungStoreService } from './rechnung-store.service';

describe('RechnungStoreService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RechnungStoreService]
    });
  });

  it('should ...', inject([RechnungStoreService], (service: RechnungStoreService) => {
    expect(service).toBeTruthy();
  }));
});
