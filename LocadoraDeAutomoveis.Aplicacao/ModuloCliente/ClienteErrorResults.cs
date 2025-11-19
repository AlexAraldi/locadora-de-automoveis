namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente
{
    public static class ClienteErrorResults
    {
        public static string ClienteNaoEncontrado = "Cliente não encontrado.";
        public static string CpfJaRegistrado = "Já existe um cliente cadastrado com este CPF.";
        public static string CnpjJaRegistrado = "Já existe um cliente cadastrado com este CNPJ.";
        public static string DadosInvalidos = "Dados inválidos para criação/atualização do cliente.";
    }
}
