import { Component, inject } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { AsyncPipe } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrl: './shell.component.scss',
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    AsyncPipe,
    RouterLink,
    RouterOutlet,
  ],
})
export class ShellComponent {
  private breakpointObserver = inject(BreakpointObserver);

  public isHandset$: Observable<boolean> = this.breakpointObserver
    .observe([Breakpoints.XSmall, Breakpoints.Small, Breakpoints.Handset])
    .pipe(
      map((result) => result.matches),
      shareReplay(),
    );

  itensNavBar = [
    { titulo: 'Início', icone: 'home', link: '/inicio' },
    { titulo: 'Aluguel', icone: 'car_rental', link: '/aluguel' },
    { titulo: 'Cliente', icone: 'person_add', link: '/cliente' },
    { titulo: 'Condutor', icone: 'contact_mail', link: '/condutor' },
    { titulo: 'Combustível', icone: 'local_gas_station', link: '/configuracao' },
    { titulo: 'Devolução', icone: 'keyboard_double_arrow_left', link: '/devolucao' },
    { titulo: 'Funcionário', icone: 'badge', link: '/funcionario' },
    { titulo: 'Grupo Automóvel', icone: 'garage', link: '/grupo-automovel' },
    { titulo: 'Plano Cobrança', icone: 'payments', link: '/plano-cobranca' },
    { titulo: 'Taxa Serviço', icone: 'receipt_long', link: '/taxa-servico' },
    { titulo: 'Veículo', icone: 'directions_car', link: '/veiculo' },
  ];
}
