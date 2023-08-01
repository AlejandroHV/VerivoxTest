using System.Text.Json.Serialization;

namespace VerivoxTest.Domain.Models.Entities
{
    public class Product : Entity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("assembly_type")]
        public required string AssemblyType { get; set; }

        [JsonPropertyName("assembly")]
        public required string Assembly { get; set; }

        [JsonPropertyName("product_type")]
        public required int ProdutType { get; set; }

    }
}
