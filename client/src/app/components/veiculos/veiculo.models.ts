export interface ListagemVeiculoApiResponse {
  registros: ListagemVeiculoModel[];
}

export interface ListagemVeiculoModel {
  id: number;
  foto: string;
  modelo: string;
  marca: string;
  ano: number;
  placa: string;
  quilometragem: number;
  combustivel: string;
  disponivel: boolean;
  grupoVeiculo: ListagemGrupoVeiculoModel;
}
export interface ListagemGrupoVeiculoModel {
  id: string;
  nome: string;
}
