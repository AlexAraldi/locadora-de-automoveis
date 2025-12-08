import { A } from '@angular/cdk/keycodes';
import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { TaxaService } from '../taxa.service';

@Component({
  selector: 'app-listar-taxas',
  imports: [AsyncPipe],
  templateUrl: './listar-taxas.html',
})
export class ListarTaxas {
  protected readonly taxaService = inject(TaxaService);
  protected readonly taxas$ = this.taxaService.selecionarTodos();
}
