/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LieferscheinPositionStoreService } from './lieferschein-position-store.service';

describe('LieferscheinPositionStoreService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LieferscheinPositionStoreService]
    });
  });

  it('should ...', inject([LieferscheinPositionStoreService], (service: LieferscheinPositionStoreService) => {
    expect(service).toBeTruthy();
  }));
});
