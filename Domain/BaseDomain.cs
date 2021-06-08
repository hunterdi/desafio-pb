using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace Domain
{
    public abstract class BaseDomain : BaseDomain<Guid>
    {
    }

    public abstract class BaseDomain<TPK>
    {
        [BsonId(IdGenerator=typeof(CombGuidGenerator))]
        public virtual TPK ID { get; set; }
    }
}
