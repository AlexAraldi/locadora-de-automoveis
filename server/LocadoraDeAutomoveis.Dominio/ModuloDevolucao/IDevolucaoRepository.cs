using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloDevolucao
{
    public interface IDevolucaoRepository
    {
        Task AdicionarAsync(Devolucao devolucao);
        Task<Devolucao?> SelecionarPorIdAsync(Guid id);
        Task<List<Devolucao>> SelecionarTodosAsync();
    }
}
