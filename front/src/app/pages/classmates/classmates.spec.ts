import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Classmates } from './classmates';

describe('Classmates', () => {
  let component: Classmates;
  let fixture: ComponentFixture<Classmates>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Classmates],
    }).compileComponents();

    fixture = TestBed.createComponent(Classmates);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
