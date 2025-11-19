namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public static class FuncionarioException
    {
        public static string EmailJaRegistrado => "Já existe um funcionário com este e-mail.";
        public static string NaoEncontrado => "Funcionário não encontrado.";
    }
}
