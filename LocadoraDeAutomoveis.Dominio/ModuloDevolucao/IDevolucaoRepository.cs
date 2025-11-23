using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloDevolucao
{
    public interface IDevolucaoRepository
    {
        Task Adicionar(Devolucao devolucao);
        Task<Devolucao?> SelecionarPorId(Guid id);
        Task<List<Devolucao>> SelecionarTodos();
    }
}
