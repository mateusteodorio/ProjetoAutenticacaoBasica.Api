namespace ProjetoAutenticacaoBasica.Api.Models.DTOs
{
    public class VooDTO
    {
        public int Codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }

    public class ResumoVooDTO
    {
        public int ID { get; set; }
        public int Codigo { get; set; }
        public string Trajeto { get; set; }

    }

    public class PassageiroNoVooDTO
    {
        public string Nome { get; set; }
        public int Assento { get; set; }
    }

    public class VooManifestoDTO
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Trajeto {get; set; }
        public List<PassageiroNoVooDTO> Passageiro { get; set; }
    }
}
