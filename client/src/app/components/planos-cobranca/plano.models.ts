export interface ListagemPlanosCobrancaApiResponse {
  registros: ListagemPlanoCobrancaModel[];
}
export interface ListagemPlanoCobrancaModel {
  grupoVeiculo: string;
  id: string;
  nome: string;
  valorDiaria: number;
  valorKm: number;
}
export interface ListagemGrupoVeiculoModel {
  id: string;
  nome: string;
}
