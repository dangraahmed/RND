﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDataAccess
{

    [BsonIgnoreExtraElements]
    public class TTaxSlab : TaxSlab
    {
        [BsonIgnore]
        public ObjectId _id { get; set; }
    }


    public class MongoDBContext
    {
        private IMongoDatabase _database { get; }

        public MongoDBContext(string ConnectionString, string DatabaseName, bool IsSSL)
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }

        public IMongoCollection<TTaxSlab> TaxSlab
        {
            get
            {
                return _database.GetCollection<TTaxSlab>("tax_slab");
            }
        }
    }
}
