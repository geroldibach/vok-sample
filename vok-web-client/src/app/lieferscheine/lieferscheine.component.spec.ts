/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LieferscheineComponent } from './lieferscheine.component';

describe('LieferscheineComponent', () => {
  let component: LieferscheineComponent;
  let fixture: ComponentFixture<LieferscheineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LieferscheineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LieferscheineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
