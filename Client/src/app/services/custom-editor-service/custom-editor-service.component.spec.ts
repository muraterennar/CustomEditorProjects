import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomEditorServiceComponent } from './custom-editor-service.component';

describe('CustomEditorServiceComponent', () => {
  let component: CustomEditorServiceComponent;
  let fixture: ComponentFixture<CustomEditorServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomEditorServiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomEditorServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
