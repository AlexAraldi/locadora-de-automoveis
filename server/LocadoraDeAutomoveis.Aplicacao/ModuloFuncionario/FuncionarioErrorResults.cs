namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario
{
    public static class FuncionarioErrorResults
    {
        public static object NomeObrigatorio => new { Mensagem = "O nome do funcionário é obrigatório." };
        public static object EmailObrigatorio => new { Mensagem = "O e-mail do funcionário é obrigatório." };
        public static object CargoObrigatorio => new { Mensagem = "O cargo é obrigatório." };
        public static object FuncionarioNaoEncontrado => new { Mensagem = "Funcionário não encontrado." };
        public static object EmailJaCadastrado => new { Mensagem = "Já existe um funcionário registrado com este e-mail." };
    }
}
