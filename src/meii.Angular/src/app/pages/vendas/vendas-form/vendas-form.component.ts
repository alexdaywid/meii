import { ItensDetails } from './../../../shared/model/itensDetails';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendas-form',
  templateUrl: './vendas-form.component.html',
  styleUrls: ['./vendas-form.component.css']
})
export class VendasFormComponent implements OnInit {

  itensMenu: ItensDetails[];

  constructor() {
    this.itensMenu = [
      { link: '/cliente', icon: 'fas fa-user', nome: 'Cliente'},
      { link: '/produto', icon: 'fas fa-box-open', nome: 'Produtos'},
      { link: '/servico', icon: 'fas fa-tools', nome: 'Serviços'},
      { link: '/agenda', icon: 'fas fa-calendar', nome: 'Calendar'},
      { link: '/fornecedores', icon: 'fas fa-users', nome: 'User'},
    ];
   }

  ngOnInit() {
  }

}
