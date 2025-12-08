import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ClienteService } from '../cliente.service';

@Component({
  selector: 'app-listar-clientes',
  imports: [AsyncPipe],
  templateUrl: './listar-clientes.html',
})
export class ListarClientes {
  protected readonly clienteService = inject(ClienteService);
  protected readonly clientes$ = this.clienteService.selecionarTodos();
}
