using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloVeiculo;

public class Veiculo : EntidadeBase<Veiculo>
{
    public string Modelo { get; private set; } = string.Empty;
    public string Marca { get; private set; } = string.Empty;
    public int Ano { get; private set; }
    public string Placa { get; private set; } = string.Empty;
    public decimal Quilometragem { get; private set; }
    public TipoCombustivel Combustivel { get; private set; }
    public bool Ativo { get; private set; } = true;
    public int KmInicial { get; set; }

    public Veiculo() { }

    public Veiculo(
        string modelo,
        string marca,
        int ano,
        string placa,
        decimal quilometragem,
        TipoCombustivel combustivel)
    {
        Id = Guid.NewGuid();
        Modelo = modelo;
        Marca = marca;
        Ano = ano;
        Placa = placa;
        Quilometragem = quilometragem;
        Combustivel = combustivel;
        Ativo = true;
    }

    public void Editar(
        string modelo,
        string marca,
        int ano,
        string placa,
        decimal quilometragem,
        TipoCombustivel combustivel)
    {
        Modelo = modelo;
        Marca = marca;
        Ano = ano;
        Placa = placa;
        Quilometragem = quilometragem;
        Combustivel = combustivel;
    }

    public void Desativar()
    {
        Ativo = false;
    }
}
