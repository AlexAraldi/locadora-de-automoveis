import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TaxaService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + '/TaxaServico';

  public selecionarTodos(): Observable<object> {
    const urlCompleto = this.apiUrl + '/todos';
    return this.http.get(urlCompleto);
  }
}
