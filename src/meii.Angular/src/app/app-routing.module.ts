

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '', redirectTo: 'dashboard', pathMatch: 'full'
  },
  {
    path: 'cliente', loadChildren: () => import('./pages/cliente/cliente.module')
    .then(a => a.ClienteModule),
  },
  {
    path: 'endereco', loadChildren: () => import('./pages/endereco/endereco.module')
    .then(a => a.EnderecoModule),
  },
  {
    path: 'produto', loadChildren: () => import('./pages/produtos/produtos.module')
    .then(a => a.ProdutosModule),
  },
  {
    path: 'dashboard', loadChildren: () => import('./pages/dashboard/dashboard.module')
    .then(a => a.DashboardModule),
  },
  {
    path: 'vendas', loadChildren: () => import('./pages/vendas/vendas.module')
    .then(a => a.VendasModule),
  },
  {
    path: 'compras', loadChildren: () => import('./pages/compras/compras.module')
    .then(a => a.ComprasModule)
  }
];

@NgModule({
  imports:
  [
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
