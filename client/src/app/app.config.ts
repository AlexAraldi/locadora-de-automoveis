import { DEFAULT_RESIZE_TIME } from '@angular/cdk/scrolling';
import {
  ApplicationConfig,
  LOCALE_ID,
  provideBrowserGlobalErrorListeners,
  provideZonelessChangeDetection,
} from '@angular/core';
import { provideRouter, Routes } from '@angular/router';
import { provideNotifications } from './components/shared/notificacao-provider';
import { provideHttpClient } from '@angular/common/http';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'inicio',
    pathMatch: 'full',
  },
  {
    path: 'inicio',
    loadComponent: () => import('./components/inicio/inicio').then((m) => m.Inicio),
  },
  {
    path: 'grupo-automovel',
    loadChildren: () =>
      import('./components/grupo-automovel/grupo.routes').then((m) => m.grupoRoutes),
  },
  {
    path: 'aluguel',
    loadChildren: () => import('./components/alugueis/aluguel.routes').then((m) => m.aluguelRoutes),
  },
  {
    path: 'cliente',
    loadChildren: () => import('./components/clientes/cliente.routes').then((m) => m.clienteRoutes),
  },
  {
    path: 'condutor',
    loadChildren: () =>
      import('./components/condutores/condutor.routes').then((m) => m.condutorRoutes),
  },
  {
    path: 'configuracao',
    loadChildren: () =>
      import('./components/configuracoes/configuracao.routes').then((m) => m.configuracaoRoutes),
  },
  {
    path: 'devolucao',
    loadChildren: () =>
      import('./components/devolucoes/devolucao.routes').then((m) => m.devolucaoRoutes),
  },
  {
    path: 'funcionario',
    loadChildren: () =>
      import('./components/funcionarios/funcionario.routes').then((m) => m.funcionarioRoutes),
  },
  {
    path: 'plano-cobranca',
    loadChildren: () =>
      import('./components/planos-cobranca/plano.routes').then((m) => m.planoRoutes),
  },
  {
    path: 'taxa-servico',
    loadChildren: () => import('./components/taxas-servicos/taxa.routes').then((m) => m.taxaRoutes),
  },
  {
    path: 'veiculo',
    loadChildren: () => import('./components/veiculos/veiculo.routes').then((m) => m.veiculoRoutes),
  },
];

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection(),
    provideRouter(routes),
    provideHttpClient(),

    { provide: LOCALE_ID, useValue: 'pt-BR' },
    { provide: DEFAULT_RESIZE_TIME, useValue: 'BRL' },

    provideNotifications(),
  ],
};
