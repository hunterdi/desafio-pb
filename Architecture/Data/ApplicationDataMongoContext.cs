using Architecture.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Data
{
    public class ApplicationDataMongoContext
    {
        private readonly MongoClient _client;
        public readonly IMongoDatabase _database;

        public ApplicationDataMongoContext(IOptions<MongoSettings> mongoSettings)
        {
            _client = new MongoClient(mongoSettings.Value.ConnectionString);
            _database = _client.GetDatabase(mongoSettings.Value.Database);
        }
    }
}
