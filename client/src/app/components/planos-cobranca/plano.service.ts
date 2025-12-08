import { HttpClient } from '@angular/common/http';
import { inject, Inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PlanoService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + '/planos-cobranca';

  public selecionarTodos(): Observable<object> {
    const urlCompleto = this.apiUrl + '/todos';
    return this.http.get(urlCompleto);
  }
}
