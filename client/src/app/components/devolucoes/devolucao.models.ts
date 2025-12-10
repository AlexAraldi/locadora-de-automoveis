export interface ListagemDevolucaoApiResponse {
  registros: ListagemDevolucaoModel[];
}

export interface ListagemDevolucaoModel {
  aluguelId: string;
  dataDevolucao: string;
  quilometragem: number;
  valorCobrado: number;
  nivelTaque: string;
  idLocacao: number;
}
