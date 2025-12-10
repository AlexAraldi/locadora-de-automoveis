import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AluguelService } from '../aluguel.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-listar-alugueis',
  imports: [MatButtonModule, MatIconModule, RouterLink, AsyncPipe],
  templateUrl: './listar-alugueis.html',
})
export class ListarAlugueis {
  protected readonly aluguelService = inject(AluguelService);
  protected readonly alugueis$ = this.aluguelService.selecionarTodos();
}
