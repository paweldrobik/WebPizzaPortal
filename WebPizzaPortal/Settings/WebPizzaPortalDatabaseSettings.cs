namespace WebPizzaPortal.Settings
{
    public class WebPizzaPortalDatabaseSettings : IWebPizzaPortalDatabaseSettings
    {
        public string OrderCollectionName { get; set; }
        public string PizzaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IWebPizzaPortalDatabaseSettings
    {
        string OrderCollectionName { get; set; }
        string PizzaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}