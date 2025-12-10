import { Component, inject } from '@angular/core';
import { ConfiguracaoService } from '../configuracao.service';
import { AsyncPipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-listar-configuracoes',
  imports: [MatButtonModule, MatIconModule, RouterLink, AsyncPipe],
  templateUrl: './listar-configuracoes.html',
})
export class ListarConfiguracoes {
  protected readonly configuracaoService = inject(ConfiguracaoService);
  protected readonly configuracoes$ = this.configuracaoService.selecionarTodos();
}
