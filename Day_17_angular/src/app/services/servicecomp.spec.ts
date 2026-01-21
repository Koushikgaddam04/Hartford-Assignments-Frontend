import { TestBed } from '@angular/core/testing';

import { Servicecomp } from './servicecomp';

describe('Servicecomp', () => {
  let service: Servicecomp;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Servicecomp);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
