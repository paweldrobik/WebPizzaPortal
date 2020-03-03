using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace WebPizzaPortal.Model
{
    public class OrderModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string  Id { get; set; }
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string  Status { get; set; }

        public OrderModel( string id, string name, int quantity, string status)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Status = status;
        }
    }
    
}