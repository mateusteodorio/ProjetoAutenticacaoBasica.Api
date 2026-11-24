namespace ProjetoAutenticacaoBasica.Api.Models.DTOs
{


    public class PassagemDTO
    {
        public int VooID { get; set; }
        public int PassageiroID { get; set; }
        public int Assento { get; set; }
    }

    public class PassagemDetalhesDTO
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Trajeto { get; set; }
        public string NomePassageiro { get; set; }
        public int Assento { get; set; }
    }
}
