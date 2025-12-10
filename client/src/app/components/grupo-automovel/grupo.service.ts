import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ListagemGrupoAutomovelModel } from './grupo.models';

@Injectable({
  providedIn: 'root',
})
export class GrupoService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + '/grupos';

  public selecionarTodos(): Observable<ListagemGrupoAutomovelModel[]> {
    return this.http.get<ListagemGrupoAutomovelModel[]>(this.apiUrl + '/todos');
  }
}
