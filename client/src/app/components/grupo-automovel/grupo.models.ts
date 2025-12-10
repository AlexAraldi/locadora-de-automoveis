export interface ListagemGrupoAutomovelApiResponse {
  registros: ListagemGrupoAutomovelModel[];
}

export interface ListagemGrupoAutomovelModel {
  id: string;
  nome: string;
}
