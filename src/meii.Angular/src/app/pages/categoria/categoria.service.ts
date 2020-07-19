import { catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categoria } from './categoria.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  private baseUrl: string = environment.urlApi + 'categoria';
  constructor(private http: HttpClient) { }

  listarTodasCategorias(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.baseUrl)
    .pipe(map((categoria) => categoria),
      catchError(this.handleError),
    );
  }

  handleError(error: any): Observable<any> {
    alert('Erro ' + error);
    return (error);
  }
}
