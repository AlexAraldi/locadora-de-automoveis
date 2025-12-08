import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ConfiguracaoService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + 'api/configuracoes';

  public selecionarTodos(): Observable<object> {
    const urlCompleto = this.apiUrl + '/todos';
    return this.http.get(urlCompleto);
  }
}
