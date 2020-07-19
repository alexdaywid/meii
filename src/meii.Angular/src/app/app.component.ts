import { ItensDetails } from './shared/model/itensDetails';
import { environment } from './../environments/environment';
import { Component } from '@angular/core';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Meii';
  ambiente: string;
  itensMenu: ItensDetails[];
  id: string;
  label: string;

  constructor() {
    this.itensMenu = this.getItensMenuTipo('dashboard');
   }

  ngOnInit() {
  }

  OnClick(tipo: string) {
    switch (tipo) {
      case 'dashboard':
        this.id = 'nav-dashboard';
        this.label = 'nav-dashboard-tab';
        break;
      case 'vendas':
        this.id = 'nav-vendas';
        this.label = 'nav-vendas-tab';
        break;
      default:
        this.id = 'nav-dashboard';
        this.label = 'nav-dashboard-tab';
        break;
    }
    this.itensMenu = this.getItensMenuTipo(tipo);
  }

  // Retorna o itens da lista por tipo.
  getItensMenuTipo(tipo: string): ItensDetails[] {
    return this.getAllItensMenu().filter(itens => itens.tipo === tipo);
  }

  // Retorna lista itens do menu.
  getAllItensMenu(): ItensDetails[] {
    return this.itensMenu = [
      { link: '/vendas', icon: 'fas fa-tags', nome: 'Vendas', tipo: 'vendas'},
      { link: '/cliente', icon: 'fas fa-user', nome: 'Cliente', tipo: 'vendas'},
      { link: '/produto', icon: 'fas fa-box-open', nome: 'Produtos', tipo: 'vendas'},
      { link: '/servico', icon: 'fas fa-tools', nome: 'Serviços', tipo: 'vendas'},
      { link: '/agenda', icon: 'fas fa-calendar', nome: 'Calendar', tipo: 'vendas'},
      { link: '/fornecedores', icon: 'fas fa-users', nome: 'User', tipo: 'vendas'},
      { link: '/dashboard-vendas', icon: 'fas fa-calendar', nome: 'Calendar', tipo: 'dashboard'},
      { link: '/dashboard-clientes', icon: 'fas fa-users', nome: 'User', tipo: 'dashboard'},
    ];
  }

}
