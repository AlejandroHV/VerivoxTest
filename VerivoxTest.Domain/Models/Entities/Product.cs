using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VerivoxTest.Domain.Models.Entities
{
    public class Product : Entity
    {
        [JsonPropertyName("name")]
        public string Name {get; set;}

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("assembly_type")]
        public string AssemblyType { get; set; }

        [JsonPropertyName("assembly")]
        public string Assembly { get; set; }


    }
}
