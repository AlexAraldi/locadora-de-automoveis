namespace LocadoraDeAutomoveis.Dominio.Compartilhado
{
    public abstract class EntidadeBase <T>
    {
        public Guid EmpresaId { get; set; }
        public Guid Id { get; set; }
    }
}
