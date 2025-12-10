import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ListagemDevolucaoApiResponse, ListagemDevolucaoModel } from './devolucao.models';

@Injectable({
  providedIn: 'root',
})
export class DevolucaoService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + '/devolucoes';

  public selecionarTodos(): Observable<ListagemDevolucaoModel[]> {
    return this.http.get<ListagemDevolucaoModel[]>(this.apiUrl + '/todos');
  }
}
