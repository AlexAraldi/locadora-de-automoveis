import { Component, inject } from '@angular/core';
import { CondutorService } from '../condutor.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-listar-condutores',
  imports: [AsyncPipe],
  templateUrl: './listar-condutores.html',
})
export class ListarCondutores {
  protected readonly condutorService = inject(CondutorService);
  protected readonly condutores$ = this.condutorService.selecionarTodos();
}
