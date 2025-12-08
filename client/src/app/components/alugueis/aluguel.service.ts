import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AluguelService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + 'api/alugueis';

  public selecionarTodos(): Observable<object> {
    const urlCompleto = this.apiUrl + '/todos';
    return this.http.get(urlCompleto);
  }
}
