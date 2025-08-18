import { Component, OnInit } from '@angular/core';
import { Livro, LivrosService } from '../livros.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent implements OnInit {
  livros: Livro[] = [];

  constructor(private livroService: LivrosService,
              private rota: Router
  ) {}

  ngOnInit(): void {
    this.livroService.listar().subscribe(data => this.livros = data);
  }

  addNovoLivro(): void{
    this.rota.navigate(['/novo']);
  }

  editarLivro(livro: Livro) {
    if (livro.id !== undefined) {
      this.rota.navigate(['/editar', livro.id]);
    }
  }

  excluirLivro(id: number): void {
    const confirmado = window.confirm('Tem certeza que deseja excluir este livro?');

    if (confirmado) {
      this.livroService.excluir(id).subscribe({
        next: () => {
          this.livros = this.livros.filter(l => l.id !== id);
        },
        error: err => {
          // console.error('Erro ao excluir livro:', err);
          alert('Erro ao excluir. Tente novamente.');
        }
      });
    }
  }


}
