using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VerivoxTest.Application.Configurations;
using VerivoxTest.Application.Data.Context;
using VerivoxTest.Application.Data.Repository;
using VerivoxTest.Domain.Models.Entities;
using VerivoxTest.Infrastructure.FileContext.JsonStructure;

namespace VerivoxTest.Infrastructure.FileDataSource
{
    public class FileContext : IContext
    {

        public List<Product> Products { get; set; } = null;

        public FileContext()
        {
            PopulateData();
        }

        public void PopulateData()
        {
            var mockFilePath = AppSettings.MockDataFilePath;
            var fileData = string.Empty;

            if (mockFilePath == null)
                throw new Exception("Invalid file path. Could not Initialize the data source");


            using (FileStream fileStream = File.Open(mockFilePath, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                fileData = Encoding.UTF8.GetString(buffer);

            }

            if (fileData == null)
                throw new Exception("Could not Initialize the data source");

            var mockData = JsonSerializer.Deserialize<MockDataStructure>(fileData);

            if (mockData.Products == null)
                throw new Exception("Could not Initialize the data source");

            Products = mockData.Products;
        }
    }
}
