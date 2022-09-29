using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace user.infra.data
{
    public class AppConfiguration
    {

        private readonly string _sqlConnection;

        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _sqlConnection = root.GetSection("ConnectionStrings:Conexion").Value;

        }

        public string SqlDataConnection
        {
            get => _sqlConnection;
        }

    }
}
