import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ListagemVeiculoModel } from './veiculo.models';

@Injectable({
  providedIn: 'root',
})
export class VeiculoService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl + '/veiculos';

  public selecionarTodos(): Observable<ListagemVeiculoModel[]> {
    return this.http.get<ListagemVeiculoModel[]>(this.apiUrl + '/todos');
  }
}
