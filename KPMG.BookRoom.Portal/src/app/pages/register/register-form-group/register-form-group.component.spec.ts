import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterFormGroupComponent } from './register-form-group.component';

describe('RegisterFormGroupComponent', () => {
  let component: RegisterFormGroupComponent;
  let fixture: ComponentFixture<RegisterFormGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterFormGroupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterFormGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
