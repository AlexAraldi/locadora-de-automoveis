import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListagemTaxaServicoModel } from './taxa.models';

@Injectable({
  providedIn: 'root',
})
export class TaxaService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + '/taxas-servico';

  public selecionarTodos(): Observable<ListagemTaxaServicoModel[]> {
    return this.http.get<ListagemTaxaServicoModel[]>(this.apiUrl + '/todos');
  }
}
