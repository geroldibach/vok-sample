/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RechnungenComponent } from './rechnungen.component';

describe('RechnungenComponent', () => {
  let component: RechnungenComponent;
  let fixture: ComponentFixture<RechnungenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RechnungenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RechnungenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
