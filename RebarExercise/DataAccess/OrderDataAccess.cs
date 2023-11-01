﻿using RebarExercise.Models;
using MongoDB.Driver;

namespace RebarExercise.DataAccess
{
    public class OrderDataAccess
    {
        private const string ConnectingString = "mongodb://127.0.0.1:27017";
        private const string DataBaseName = "Rebar";
        private const string CollectionName = "Orders";
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrderDataAccess()
        {
            _ordersCollection = ConnectToMongo<Order>(CollectionName);
        }

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectingString);
            var database = client.GetDatabase(DataBaseName);
            return database.GetCollection<T>(collection);
        }

        //GET
        public async Task<List<Order>> GetOrders()
        {
            var result = await _ordersCollection.FindAsync(_ => true);
            return result.ToList();
        }

        //POST
        public async Task CreateOrder(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            var filter = Builders<Order>.Filter.Eq(o => o.Id, orderId);
            var result = await _ordersCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public List<Order> GetOrdersByDate(DateTime date)
        {
            var allOrders = _ordersCollection.Find(_ => true).ToList();
            var ordersByDate = allOrders.Where(order => order.Date.Date == date.Date).ToList();
            
            return ordersByDate;
        }
    }
}
