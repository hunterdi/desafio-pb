using Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Node: BaseDomain
    {
        public int Value { get; set; }
        public Guid? LeftID { get; set; }
        [BsonIgnore]
        public virtual Node Left { get; set; }
        public Guid? RightID { get; set; }
        [BsonIgnore]
        public virtual Node Right { get; set; }

        public Node(int value)
        {
            this.Value = value;
        }
    }
}
