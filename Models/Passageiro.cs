using System.Text.Json.Serialization;

namespace ProjetoAutenticacaoBasica.Api.Models
{
    public class Passageiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        [JsonIgnore]

        public ICollection<Passagem>? Passageiros = new List<Passagem>();
    }
}
