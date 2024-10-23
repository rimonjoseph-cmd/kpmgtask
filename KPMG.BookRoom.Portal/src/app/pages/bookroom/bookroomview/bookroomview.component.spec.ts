import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookroomviewComponent } from './bookroomview.component';

describe('BookroomviewComponent', () => {
  let component: BookroomviewComponent;
  let fixture: ComponentFixture<BookroomviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookroomviewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookroomviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
