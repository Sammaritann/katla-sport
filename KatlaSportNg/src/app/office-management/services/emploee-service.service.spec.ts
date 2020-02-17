import { TestBed, inject } from '@angular/core/testing';

import { EmploeeServiceService } from './emploee-service.service';

describe('EmploeeServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EmploeeServiceService]
    });
  });

  it('should be created', inject([EmploeeServiceService], (service: EmploeeServiceService) => {
    expect(service).toBeTruthy();
  }));
});
