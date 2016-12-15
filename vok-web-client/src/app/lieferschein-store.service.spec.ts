/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LieferscheinStoreService } from './lieferschein-store.service';

describe('LieferscheinStoreService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LieferscheinStoreService]
    });
  });

  it('should ...', inject([LieferscheinStoreService], (service: LieferscheinStoreService) => {
    expect(service).toBeTruthy();
  }));
});
