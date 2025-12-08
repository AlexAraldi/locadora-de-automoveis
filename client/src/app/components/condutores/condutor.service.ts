import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CondutorService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + 'api/condutores';

  public selecionarTodos(): Observable<object> {
    const urlCompleto = this.apiUrl + '/todos';
    return this.http.get(urlCompleto);
  }
}
