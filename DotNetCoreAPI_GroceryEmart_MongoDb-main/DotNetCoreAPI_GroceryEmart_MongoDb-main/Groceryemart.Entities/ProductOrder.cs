using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroceryEmart.Entities
{
    public class ProductOrder
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
