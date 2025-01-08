import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoVendaComponent  } from './tipovenda.component';

describe('TipoVendaComponent ', () => {
  let component: TipoVendaComponent;
  let fixture: ComponentFixture<TipoVendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TipoVendaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TipoVendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
