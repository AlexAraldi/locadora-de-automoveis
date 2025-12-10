import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { DevolucaoService } from '../devolucao.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-listar-devolucoes',
  imports: [MatButtonModule, MatIconModule, RouterLink, AsyncPipe],

  templateUrl: './listar-devolucoes.html',
})
export class ListarDevolucoes {
  protected readonly devolucaoService = inject(DevolucaoService);
  protected readonly devolucoes$ = this.devolucaoService.selecionarTodos();
}
