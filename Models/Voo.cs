using System.Text.Json.Serialization;

namespace ProjetoAutenticacaoBasica.Api.Models
{
    public class Voo
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }

        [JsonIgnore]

        public ICollection<Passagem>? Passagens = new List<Passagem>();
    }
}
