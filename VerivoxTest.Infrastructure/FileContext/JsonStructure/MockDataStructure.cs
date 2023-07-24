using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Infrastructure.FileContext.JsonStructure
{
    public class MockDataStructure
    {
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}
