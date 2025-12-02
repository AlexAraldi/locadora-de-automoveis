namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.DTOs
{
    public class TokenResponse
    {
        public string AccessToken { get; set; } = "";
        public int ExpiresIn { get; set; }
    }
}
