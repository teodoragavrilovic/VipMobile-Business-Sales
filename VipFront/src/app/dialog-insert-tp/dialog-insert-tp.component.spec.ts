import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogInsertTPComponent } from './dialog-insert-tp.component';

describe('DialogInsertTPComponent', () => {
  let component: DialogInsertTPComponent;
  let fixture: ComponentFixture<DialogInsertTPComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogInsertTPComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogInsertTPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
