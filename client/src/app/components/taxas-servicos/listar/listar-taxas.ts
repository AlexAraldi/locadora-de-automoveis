import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { TaxaService } from '../taxa.service';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-listar-taxas',
  imports: [MatCardModule, MatButtonModule, MatIconModule, RouterLink, AsyncPipe],
  templateUrl: './listar-taxas.html',
})
export class ListarTaxas {
  protected readonly taxaService = inject(TaxaService);
  protected readonly taxas$ = this.taxaService.selecionarTodos();
}
