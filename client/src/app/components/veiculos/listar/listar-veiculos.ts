import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { VeiculoService } from '../veiculo.service';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';

@Component({
  selector: 'app-listar-veiculos',
  imports: [
    MatCardModule,
    MatCheckboxModule,
    MatButtonModule,
    MatIconModule,
    RouterLink,
    AsyncPipe,
  ],
  templateUrl: './listar-veiculos.html',
})
export class ListarVeiculos {
  protected readonly veiculoService = inject(VeiculoService);
  protected readonly veiculos$ = this.veiculoService.selecionarTodos();
}
