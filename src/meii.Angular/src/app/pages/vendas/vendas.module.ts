import { SharedModule } from './../../shared/shared.module';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendasRoutingModule } from './vendas-routing.module';
import { VendasFormComponent } from './vendas-form/vendas-form.component';



@NgModule({
  declarations: [VendasFormComponent],
  imports: [
    CommonModule,
    VendasRoutingModule,
    SharedModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class VendasModule { }
