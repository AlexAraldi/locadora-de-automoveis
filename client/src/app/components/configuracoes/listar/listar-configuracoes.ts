import { Component, inject } from '@angular/core';
import { ConfiguracaoService } from '../configuracao.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-listar-configuracoes',
  imports: [AsyncPipe],
  templateUrl: './listar-configuracoes.html',
})
export class ListarConfiguracoes {
  protected readonly configuracaoService = inject(ConfiguracaoService);
  protected readonly configuracoes$ = this.configuracaoService.selecionarTodos();
}
