import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnlineConversionComponent } from './online-conversion.component';

describe('OnlineConversionComponent', () => {
  let component: OnlineConversionComponent;
  let fixture: ComponentFixture<OnlineConversionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OnlineConversionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OnlineConversionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
