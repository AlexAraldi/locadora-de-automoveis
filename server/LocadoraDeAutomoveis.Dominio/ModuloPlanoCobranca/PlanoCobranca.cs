using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

public class PlanoCobranca : EntidadeBase<PlanoCobranca>
{

    public Guid GrupoAutomovelId { get; private set; }

    public TipoPlano TipoPlano { get; private set; }

    public decimal ValorDiaria { get; private set; }
    public decimal? ValorPorKm { get; private set; }       // Usado no diário
    public int? KmLivre { get; private set; }              // Usado no km livre
    public int? KmControladoLimite { get; private set; }   // Usado no km controlado
    public decimal? ValorExcedenteKm { get; private set; } // Excedente do km controlado

    public PlanoCobranca() { }

    public PlanoCobranca(
        Guid grupoAutomovelId,
        TipoPlano tipoPlano,
        decimal valorDiaria,
        decimal? valorPorKm,
        int? kmLivre,
        int? kmControladoLimite,
        decimal? valorExcedenteKm)
    {
        Id = Guid.NewGuid();
        GrupoAutomovelId = grupoAutomovelId;
        TipoPlano = tipoPlano;
        ValorDiaria = valorDiaria;
        ValorPorKm = valorPorKm;
        KmLivre = kmLivre;
        KmControladoLimite = kmControladoLimite;
        ValorExcedenteKm = valorExcedenteKm;
    }

    public void Editar(
        Guid grupoAutomovelId,
        TipoPlano tipoPlano,
        decimal valorDiaria,
        decimal? valorPorKm,
        int? kmLivre,
        int? kmControladoLimite,
        decimal? valorExcedenteKm)
    {
        GrupoAutomovelId = grupoAutomovelId;
        TipoPlano = tipoPlano;
        ValorDiaria = valorDiaria;
        ValorPorKm = valorPorKm;
        KmLivre = kmLivre;
        KmControladoLimite = kmControladoLimite;
        ValorExcedenteKm = valorExcedenteKm;
    }
}
