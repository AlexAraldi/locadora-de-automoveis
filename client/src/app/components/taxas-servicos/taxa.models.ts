export interface ListagemTaxasServicosApiResponse {
  registros: ListagemTaxaServicoModel[];
}
export interface ListagemTaxaServicoModel {
  id: string;
  nome: string;
  valor: number;
  tipoCalculo: string;
}
