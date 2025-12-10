import { HttpClient } from '@angular/common/http';
import { inject, Inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { ListagemPlanoCobrancaModel } from './plano.models';

@Injectable({
  providedIn: 'root',
})
export class PlanoService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + '/planos-cobranca';

  public selecionarTodos(): Observable<ListagemPlanoCobrancaModel[]> {
    return this.http.get<ListagemPlanoCobrancaModel[]>(this.apiUrl + '/todos');
  }
}
