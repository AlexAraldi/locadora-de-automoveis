import { Component, inject } from '@angular/core';
import { GrupoService } from '../grupo.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-listar-grupos',
  imports: [AsyncPipe],
  templateUrl: './listar-grupos.html',
})
export class ListarGrupos {
  protected readonly grupoService = inject(GrupoService);
  protected readonly grupos$ = this.grupoService.selecionarTodos();
}
