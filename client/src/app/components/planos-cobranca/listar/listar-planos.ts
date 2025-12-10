import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { PlanoService } from '../plano.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-listar-planos',
  imports: [MatButtonModule, MatIconModule, RouterLink, AsyncPipe, MatCardModule],
  templateUrl: './listar-planos.html',
})
export class ListarPlanos {
  protected readonly planoService = inject(PlanoService);
  protected readonly planos$ = this.planoService.selecionarTodos();
}
