namespace DragonFlyERP.DTO
{
    public class UsuarioDTO
    {
        public long Codigo { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public bool IsAdm { get; set; }

        //public long CodigoCadastro { get; set; }

    }
}