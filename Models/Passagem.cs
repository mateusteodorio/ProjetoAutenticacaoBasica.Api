namespace ProjetoAutenticacaoBasica.Api.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public int VooID { get; set; }
        public int PassageiroID { get; set; }
        public int Assento { get; set; }

        public Voo? Voo { get; set; }
        public Passageiro? Passageiro { get; set; }
    }
}
