import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { PlanoService } from '../plano.service';

@Component({
  selector: 'app-listar-planos',
  imports: [AsyncPipe],
  templateUrl: './listar-planos.html',
})
export class ListarPlanos {
  protected readonly planoService = inject(PlanoService);
  protected readonly planos$ = this.planoService.selecionarTodos();
}
