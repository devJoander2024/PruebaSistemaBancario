import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoprestamosComponent } from './tipoprestamos.component';

describe('TipoprestamosComponent', () => {
  let component: TipoprestamosComponent;
  let fixture: ComponentFixture<TipoprestamosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TipoprestamosComponent]
    });
    fixture = TestBed.createComponent(TipoprestamosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
