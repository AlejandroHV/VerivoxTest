using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using VerivoxTest.Application.Configurations;
using VerivoxTest.Application.Data.Context;
using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Infrastructure.FileDataSource
{
    public static class FileContextConfig
    {
        

        public static void Initialize(IServiceCollection services)
        {
            services.AddSingleton<IContext, FileContext>();

            
            

        }
    }
}
