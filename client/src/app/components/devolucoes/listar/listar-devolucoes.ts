import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { DevolucaoService } from '../devolucao.service';

@Component({
  selector: 'app-listar-devolucoes',
  imports: [AsyncPipe],
  templateUrl: './listar-devolucoes.html',
})
export class ListarDevolucoes {
  protected readonly devolucaoService = inject(DevolucaoService);
  protected readonly devolucoes$ = this.devolucaoService.selecionarTodos();
}
