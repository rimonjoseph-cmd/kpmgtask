import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CleaningStaffDashboardComponent } from './cleaning-staff-dashboard.component';

describe('CleaningStaffDashboardComponent', () => {
  let component: CleaningStaffDashboardComponent;
  let fixture: ComponentFixture<CleaningStaffDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CleaningStaffDashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CleaningStaffDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
