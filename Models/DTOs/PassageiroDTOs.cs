namespace ProjetoAutenticacaoBasica.Api.Models.DTOs
{
    public class PassageiroDTO
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
    }

    public class PassageiroInfoDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
    }
}
