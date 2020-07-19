import { ComprasFormComponent } from './compras-form/compras-form.component';
import { VendasFormComponent } from './../vendas/vendas-form/vendas-form.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '' , component: ComprasFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComprasRoutingModule { }
