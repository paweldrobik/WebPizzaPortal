using System.Collections.Generic;
using MongoDB.Driver;
using WebPizzaPortal.Model;

namespace WebPizzaPortal.Settings
{
    public class PizzaService
    {
        private readonly IMongoCollection<PizzaModel> _pizzaModel;

        public PizzaService(IWebPizzaPortalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pizzaModel = database.GetCollection<PizzaModel>(settings.PizzaCollectionName);
        }

        public List<PizzaModel> Get() =>
            _pizzaModel.Find(pizzaModel => true).ToList();

        public PizzaModel Get(string id) =>
            _pizzaModel.Find<PizzaModel>(pizzaModel => pizzaModel.Id == id).FirstOrDefault();

        public PizzaModel Create(PizzaModel pizzaModel)
        {
            _pizzaModel.InsertOne(pizzaModel);
            return pizzaModel;
        }

        public void Update(string id, PizzaModel pizzaModelIn) =>
            _pizzaModel.ReplaceOne(pizzaModel => pizzaModel.Id == id, pizzaModelIn);

        public void Remove(PizzaModel pizzaModelIn) =>
            _pizzaModel.DeleteOne(pizzaModel => pizzaModel.Id == pizzaModelIn.Id);

        public void Remove(string id) => 
            _pizzaModel.DeleteOne(pizzaModel => pizzaModel.Id == id);
    }
}