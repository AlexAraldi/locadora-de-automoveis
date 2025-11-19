using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Excluir
{
    public class ExcluirFuncionarioRequestHandler
    {
        private readonly IFuncionarioRepository _repository;

        public ExcluirFuncionarioRequestHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(ExcluirFuncionarioRequest request)
        {
            var funcionario = await _repository.BuscarPorId(request.Id);
            if (funcionario == null)
                return FuncionarioErrorResults.FuncionarioNaoEncontrado;

            await _repository.Excluir(funcionario);

            return new
            {
                Mensagem = "Funcionário excluído com sucesso."
            };
        }
    }
}
