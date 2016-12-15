/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LieferscheinPositionenComponent } from './lieferschein-positionen.component';

describe('LieferscheinPositionenComponent', () => {
  let component: LieferscheinPositionenComponent;
  let fixture: ComponentFixture<LieferscheinPositionenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LieferscheinPositionenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LieferscheinPositionenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
