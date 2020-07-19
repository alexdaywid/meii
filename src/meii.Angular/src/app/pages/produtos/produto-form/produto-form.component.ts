import { ProdutoService } from './../produto.service';
import { Produto } from './../produto';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CategoriaService } from './../../categoria/categoria.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Categoria } from '../../categoria/categoria.model';
import { switchMap } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { parse } from 'path';

@Component({
  selector: 'app-produto-form',
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.css']
})
export class ProdutoFormComponent implements OnInit {

  btnDetailsForm = { link: ''};
  breadcrumpDetails = {name: 'Produto', link: 'produto'};
  produto: Produto;
  categorias: Categoria[] = [];
  produtoForm: FormGroup;
  acaoAtual: string;


  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private categoriaService: CategoriaService,
    private produtoService: ProdutoService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
  ) { }

  ngOnInit() {
    this.getAcaoAtual();
    this.criarProdutoForm();
    this.listarTodasCategorias();
    this.carregarCategoria();
  }

  onSubmit($event) {
    this.produto = this.produtoForm.value;
    if ($event === 'novo') {
      this.criarNovoProduto(this.produto);
    } else {
      this.editarProduto(this.produto);
    }
  }

  criarProdutoForm() {
    this.produtoForm = this.formBuilder.group({
      id: [null],
      nome: [null, [Validators.required]],
      descricao: [null, [Validators.required]],
      dataCadastro: [null],
      quantidade: [null, [Validators.required]],
      valor: [null],
      categoriaId: [null],
    });
  }

  atualizarProdutoForm(produto: Produto) {
    this.produtoForm.patchValue({
      id: produto.id,
      nome: produto.nome,
      descricao: produto.descricao,
      dataCadastro: produto.dataCadastro,
      quantidade: produto.quantidade,
      valor: produto.valor,
      categoriaId: produto.categoriaId,
    });
  }

  // private captura ação atual
  getAcaoAtual() {
    if (this.route.snapshot.url[0].path === 'novo') {
      this.acaoAtual = 'novo';
      this.btnDetailsForm = {
        link: this.acaoAtual,
      };
    } else {
      this.acaoAtual = 'editar';
      this.btnDetailsForm = {
        link: this.acaoAtual,
      };
    }
  }



  listarTodasCategorias() {
    this.categoriaService.listarTodasCategorias()
    .subscribe(categoria => {
      this.categorias = categoria;
    });
  }

  criarNovoProduto(produto: Produto) {
    this.produtoService.criarProduto(this.produto)
      .subscribe(res => {
        this.produto = res;
        this.toastr.success('Produto salvo com sucesso.');
        this.router.navigateByUrl('produto', {skipLocationChange: true}).then(
          () => this.router.navigate(['produto', 'editar' , this.produto.id])
        );
      });
  }

  editarProduto(produto: Produto) {
    this.produtoService.atualizarProduto(produto)
    .subscribe(res => {
      this.toastr.success('Produto atualizado com secesso.');
      this.router.navigateByUrl('produto');
    });
  }

  carregarCategoria() {
    if (this.acaoAtual === 'editar') {
      this.route.paramMap.pipe(
        switchMap(params => this.produtoService.buscarProdutoPorId(+params.get('id')))
      )
      .subscribe(produto => {
        this.produto = produto;
        this.produtoForm.patchValue(this.produto);
      });
    }
  }


}
