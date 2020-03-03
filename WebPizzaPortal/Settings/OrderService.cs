using System.Collections.Generic;
using MongoDB.Driver;
using WebPizzaPortal.Model;

namespace WebPizzaPortal.Settings
{
    public class OrderService
    {
        private readonly IMongoCollection<OrderModel> _orderModel;

        public OrderService(IWebPizzaPortalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _orderModel = database.GetCollection<OrderModel>(settings.OrderCollectionName);
        }

        public List<OrderModel> Get() =>
            _orderModel.Find(orderModel => true).ToList();
        
        public OrderModel Get(string id) =>
            _orderModel.Find<OrderModel>(orderModel => orderModel.Id == id).FirstOrDefault();

        public OrderModel Create(OrderModel orderModel)
        {
            _orderModel.InsertOne(orderModel);
            return orderModel;
        }
        public void Remove(string id) => 
            _orderModel.DeleteOne(orderModel => orderModel.Id == id);
    }
}