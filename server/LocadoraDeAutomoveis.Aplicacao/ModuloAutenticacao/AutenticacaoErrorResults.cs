public static class AutenticacaoErrorResults
{
    public static readonly object UsuarioNaoEncontrado =
        new { Mensagem = "Usuário não encontrado." };

    public static readonly object CredenciaisInvalidas =
        new { Mensagem = "Credenciais inválidas." };

    public static readonly object EmailJaRegistrado =
        new { Mensagem = "Este e-mail já está registrado." };
}
