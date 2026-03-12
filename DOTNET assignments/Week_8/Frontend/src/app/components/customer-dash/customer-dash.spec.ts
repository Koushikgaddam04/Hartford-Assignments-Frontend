import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerDash } from './customer-dash';

describe('CustomerDash', () => {
  let component: CustomerDash;
  let fixture: ComponentFixture<CustomerDash>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerDash]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerDash);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
