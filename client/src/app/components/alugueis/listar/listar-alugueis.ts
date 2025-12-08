import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AluguelService } from '../aluguel.service';

@Component({
  selector: 'app-listar-alugueis',
  imports: [AsyncPipe],
  templateUrl: './listar-alugueis.html',
})
export class ListarAlugueis {
  protected readonly aluguelService = inject(AluguelService);
  protected readonly alugueis$ = this.aluguelService.selecionarTodos();
}
