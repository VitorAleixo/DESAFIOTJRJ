import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoVendasComponent } from './tipovendas.component';

describe('TipoVendasComponent  ', () => {
  let component: TipoVendasComponent;
  let fixture: ComponentFixture<TipoVendasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TipoVendasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TipoVendasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
