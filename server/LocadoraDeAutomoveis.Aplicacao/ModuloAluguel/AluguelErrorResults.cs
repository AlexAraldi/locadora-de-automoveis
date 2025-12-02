namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel;

public static class AluguelErrorResults
{
    public static string ClienteNaoEncontrado => "Cliente não encontrado.";
    public static string CondutorNaoEncontrado => "Condutor não encontrado.";
    public static string VeiculoNaoEncontrado => "Veículo não encontrado.";
    public static string PlanoNaoEncontrado => "Plano de cobrança não encontrado.";
    public static string GrupoNaoEncontrado => "Grupo de automóvel não encontrado.";
    public static string VeiculoIndisponivel => "O veículo já está alugado.";
    public static string AluguelNaoEncontrado => "Aluguel não encontrado.";
    public static string DatasInvalidas => "A data prevista deve ser maior que a data de início.";
}
