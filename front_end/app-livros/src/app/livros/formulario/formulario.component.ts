import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Livro, LivrosService } from '../livros.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent implements OnInit {

  livroId?: number;
  modoTela: string = "novo"

  form = this.fb.group({
    titulo: ['', [Validators.required, Validators.maxLength(100)]],
    autor: ['', [Validators.required, Validators.maxLength(100)]],
    genero: ['', [Validators.required, Validators.maxLength(100)]],
    ano: [new Date().getFullYear(), [Validators.required, Validators.min(1500), Validators.max(2025)]]
  });

  constructor(
    private fb: FormBuilder,
    private livroService: LivrosService,
    private route: ActivatedRoute,
    private rota: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.modoTela = "edit";
      this.livroId = +id;
      this.livroService.getPorCodigo(this.livroId).subscribe({
        next: (dados) => this.form.patchValue(dados),
        error: (err) => {
          console.error('Erro ao carregar livro:', err);
          alert('Livro não encontrado.');
        }
      });
    }
  }

  salvar(): void {
    if (this.form.invalid) {
      alert('Preencha todos os campos corretamente.');
      return;
    }

    const livro: Livro = {
      titulo: this.form.value.titulo ?? '',
      autor: this.form.value.autor ?? '',
      genero: this.form.value.genero ?? '',
      ano: this.form.value.ano ?? new Date().getFullYear()
    };


    if (this.livroId) {
      this.livroService.atualizar(this.livroId, livro).subscribe({
        next: () => {
          alert('Livro atualizado com sucesso!');
          this.rota.navigate(['/']);
        },
        error: () => alert('Erro ao atualizar livro.')
      });
    } else {
      this.livroService.adicionar(livro).subscribe({
        next: () => {
          alert('Livro adicionado com sucesso!');
          this.rota.navigate(['/']);
        },
        error: () => alert('Erro ao adicionar livro.')
      });
    }
  }
}
