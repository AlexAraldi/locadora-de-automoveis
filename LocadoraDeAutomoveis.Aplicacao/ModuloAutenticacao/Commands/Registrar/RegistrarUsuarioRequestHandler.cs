using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Validators;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloAutenticacao.Repositories;
using BC = BCrypt.Net.BCrypt;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Registrar
{
    public class RegistrarUsuarioRequestHandler
    {
        private readonly UsuarioRepository _repository;
        private readonly RegistrarUsuarioValidator _validator;

        public RegistrarUsuarioRequestHandler(
            UsuarioRepository repository,
            RegistrarUsuarioValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<object> Handle(RegistrarUsuarioRequest request)
        {
            var validation = _validator.Validate(request);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage);

            // Já existe usuário com este e-mail?
            var existente = await _repository.BuscarPorEmail(request.Email);
            if (existente != null)
                return AutenticacaoErrorResults.EmailJaRegistrado;

            // Criação do usuário
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                SenhaHash = BC.HashPassword(request.Senha),
                Role = RoleUsuario.Funcionario 
            };


            await _repository.Adicionar(usuario);

            return new
            {
                Mensagem = "Usuário registrado com sucesso.",
                UsuarioId = usuario.Id
            };
        }
    }
}
