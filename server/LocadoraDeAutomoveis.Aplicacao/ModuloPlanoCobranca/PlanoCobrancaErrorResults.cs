namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca;

public static class PlanoCobrancaErrorResults
{
    public static string GrupoNaoEncontrado => "O grupo de automóvel informado não existe.";
    public static string PlanoDuplicado => "Já existe um plano deste tipo para este grupo.";
    public static string PlanoNaoEncontrado => "Plano de cobrança não encontrado.";
}
