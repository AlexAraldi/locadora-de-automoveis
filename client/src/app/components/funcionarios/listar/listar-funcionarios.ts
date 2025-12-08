import { Component, inject } from '@angular/core';
import { FuncionarioService } from '../funcionario.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-listar-funcionarios',
  imports: [AsyncPipe],
  templateUrl: './listar-funcionarios.html',
})
export class ListarFuncionarios {
  protected readonly funcionarioService = inject(FuncionarioService);
  protected readonly funcionarios$ = this.funcionarioService.selecionarTodos();
}
