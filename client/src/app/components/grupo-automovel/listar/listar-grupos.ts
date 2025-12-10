import { Component, inject } from '@angular/core';
import { GrupoService } from '../grupo.service';
import { AsyncPipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-listar-grupos',
  imports: [MatCardModule, MatButtonModule, MatIconModule, RouterLink, AsyncPipe],
  templateUrl: './listar-grupos.html',
})
export class ListarGrupos {
  protected readonly grupoService = inject(GrupoService);
  protected readonly grupos$ = this.grupoService.selecionarTodos();
}
