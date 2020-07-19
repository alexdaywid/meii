import { ProdutoService } from './../produto.service';
import { Produto } from './../produto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-produto-list',
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.css']
})
export class ProdutoListComponent implements OnInit {

  produtos: Produto[];
  btnDetailsForm = { name: 'Novo Produto', link: 'produto/novo'};
  breadcrumpDetails = {name: 'Produto', link: 'produto'};
  constructor(private produtoService: ProdutoService) { }

  ngOnInit() {
    this.listarTodosProdutos();
  }

  listarTodosProdutos(): Produto[] {
    this.produtoService.listarTodosProdutos()
    .subscribe( res => {
      this.produtos = res;
    });
    return this.produtos;
  }

}
