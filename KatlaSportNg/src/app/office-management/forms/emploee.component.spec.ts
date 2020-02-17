import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmploeeComponent } from './emploee.component';

describe('EmploeeComponent', () => {
  let component: EmploeeComponent;
  let fixture: ComponentFixture<EmploeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmploeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmploeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
