using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Country { get; set; }
        public string ControlPoint { get; set; }
        public string SetNumber { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }


    }
}
