import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { VeiculoService } from '../veiculo.service';

@Component({
  selector: 'app-listar-veiculos',
  imports: [AsyncPipe],
  templateUrl: './listar-veiculos.html',
})
export class ListarVeiculos {
  protected readonly veiculoService = inject(VeiculoService);
  protected readonly veiculos$ = this.veiculoService.selecionarTodos();
}
