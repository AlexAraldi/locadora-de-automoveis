import { Component, inject } from '@angular/core';
import { FuncionarioService } from '../funcionario.service';
import { AsyncPipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { MatCardHeader, MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-listar-funcionarios',
  imports: [MatButtonModule, MatIconModule, RouterLink, AsyncPipe, MatCardHeader, MatCardModule],
  templateUrl: './listar-funcionarios.html',
})
export class ListarFuncionarios {
  protected readonly funcionarioService = inject(FuncionarioService);
  protected readonly funcionarios$ = this.funcionarioService.selecionarTodos();
}
