import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgentDash } from './agent-dash';

describe('AgentDash', () => {
  let component: AgentDash;
  let fixture: ComponentFixture<AgentDash>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AgentDash]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgentDash);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
