export interface ListagemFuncionarioApiResponse {
  registros: ListagemFuncionarioModel[];
}
export interface ListagemFuncionarioModel {
  id: number;
  nome: string;
  cpf: string;
  telefone: string;
  email: string;
  cargo: string;
}
