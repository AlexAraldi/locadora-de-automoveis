import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { ListagemFuncionarioModel } from './funcionario.models';

@Injectable({
  providedIn: 'root',
})
export class FuncionarioService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + '/funcionarios';

  public selecionarTodos(): Observable<ListagemFuncionarioModel[]> {
    return this.http.get<ListagemFuncionarioModel[]>(this.apiUrl + '/todos');
  }
}
