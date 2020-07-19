import { map, catchError } from 'rxjs/operators';
import { Produto } from './produto';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private baseUrl: string = environment.urlApi + 'produto';
  constructor(private http: HttpClient) { }

  listarTodosProdutos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.baseUrl)
    .pipe(map((obj) => obj),
      catchError(this.handleError),
    );
  }

  criarProduto(novoProduto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this.baseUrl, novoProduto)
    .pipe(map((obj) => obj),
    catchError(this.handleError),
    );
  }

  buscarProdutoPorId( produtoId: number): Observable<Produto> {
    const url = `${this.baseUrl}/${produtoId}`;
    return this.http.get<Produto>(url)
    .pipe(map((obj) => obj),
    catchError(this.handleError)
    );
  }

  atualizarProduto(produto: Produto): Observable<Produto> {
    const url = `${this.baseUrl}/${produto.id}`;
    return this.http.put<Produto>(url, produto)
    .pipe(map((obj) => obj),
    catchError(this.handleError),
    );
  }


  handleError(error: any): Observable<any> {
    alert('Erro ' + error);
    return (error);
  }
}
