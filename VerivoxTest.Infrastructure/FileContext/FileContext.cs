﻿using System;
using System.Collections.Generic;
using System.IO;using System.Text;
using System.Text.Json;using VerivoxTest.Application.Configurations;
using VerivoxTest.Application.Especifications.Context;
using VerivoxTest.Domain.Models.Entities;
using VerivoxTest.Infrastructure.FileContext.JsonStructure;

namespace VerivoxTest.Infrastructure.FileContext
{
    public class FileContext : IContext
    {

        public List<Product> Products { get; set; } = null;

        public FileContext()
        {
            PopulateData();
        }

        /// <summary>
        /// This method acts like a seed on a database but instead the data is being obtained from a file.
        /// TO DO: Move reading files from disc to a separate utility class. 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void PopulateData()
        {
            var mockFilePath = AppSettingsBinding.MockDataFilePath;
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
                throw new Exception("Could not read the data source");

            var mockData = JsonSerializer.Deserialize<MockDataStructure>(fileData);

            if (mockData.Products == null)
                throw new Exception("Could not initialize the data source");

            Products = mockData.Products;
        }
    }
}
