import { Component, inject } from '@angular/core';
import { CondutorService } from '../condutor.service';
import { AsyncPipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-listar-condutores',
  imports: [MatButtonModule, MatIconModule, RouterLink, AsyncPipe],

  templateUrl: './listar-condutores.html',
})
export class ListarCondutores {
  protected readonly condutorService = inject(CondutorService);
  protected readonly condutores$ = this.condutorService.selecionarTodos();
}
