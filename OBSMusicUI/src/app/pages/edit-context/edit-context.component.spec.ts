import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditContextComponent } from './edit-context.component';

describe('EditContextComponent', () => {
  let component: EditContextComponent;
  let fixture: ComponentFixture<EditContextComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditContextComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditContextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
