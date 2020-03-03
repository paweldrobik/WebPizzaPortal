using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace WebPizzaPortal.Model
{
    public class PizzaModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string PizzaName { get; set; }

        public decimal Price { get; set; }

        public string Spicy { get; set; }

        public string Ing1 { get; set; }
        
        public string Ing2 { get; set; }
        
        public string Ing3 { get; set; }

        

        public PizzaModel(string id, string pizzaName, decimal price, string spicy,
            string ing1, string ing2, string ing3)
        {
            Id = id;
            PizzaName = pizzaName;
            Price = price;
            Spicy = spicy;
            Ing1 = ing1;
            Ing2 = ing2;
            Ing3 = ing3;
        }
        
    }
}