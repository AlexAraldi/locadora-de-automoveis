import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-listar-clientes',
  imports: [MatButtonModule, MatIconModule, RouterLink, AsyncPipe],
  templateUrl: './listar-clientes.html',
})
export class ListarClientes {
  protected readonly clienteService = inject(ClienteService);
  protected readonly clientes$ = this.clienteService.selecionarTodos();
}
