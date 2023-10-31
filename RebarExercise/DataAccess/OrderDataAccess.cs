using RebarExercise.Models;
using MongoDB.Driver;

namespace RebarExercise.DataAccess
{
    public class OrderDataAccess
    {
        private const string ConnectingString = "mongodb://127.0.0.1:27017";
        private const string DataBaseName = "Rebar";
        private const string CollectionName = "Orders";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectingString);
            var database = client.GetDatabase(DataBaseName);
            return database.GetCollection<T>(collection);
        }

        //GET
        public async Task<List<Order>> GetOrders()
        {
            var ordersCollection = ConnectToMongo<Order>(CollectionName);
            var result = await ordersCollection.FindAsync(_ => true);
            return result.ToList();
        }

        //POST
        public async Task CreateOrder(Order order)
        {
            var ordersCollection = ConnectToMongo<Order>(CollectionName);
            await ordersCollection.InsertOneAsync(order);
        }
    }
}
