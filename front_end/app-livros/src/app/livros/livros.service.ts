import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Livro {
  id? : number;
  titulo: string;
  autor: string;
  genero: string;
  ano: number;
}

@Injectable({
  providedIn: 'root'
})
export class LivrosService {

  private apiUrl = 'https://localhost:7198/api/livros';

 constructor(private http: HttpClient) {}

  listar(): Observable<Livro[]> {
    return this.http.get<Livro[]>(this.apiUrl);
  }

  adicionar(livro: Livro): Observable<Livro> {
    // console.log("entrou aqui123");
    return this.http.post<Livro>(this.apiUrl, livro);
  }

  excluir(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }

  getPorCodigo(id: number): Observable<Livro> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Livro>(url);
  }

  atualizar(id: number, livro: Livro): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<void>(url, livro);
  }





}
