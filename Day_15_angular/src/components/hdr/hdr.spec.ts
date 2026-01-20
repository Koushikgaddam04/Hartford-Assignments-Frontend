import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Hdr } from './hdr';

describe('Hdr', () => {
  let component: Hdr;
  let fixture: ComponentFixture<Hdr>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Hdr]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Hdr);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
