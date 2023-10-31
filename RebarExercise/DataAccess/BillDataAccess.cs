using RebarExercise.Models;
using MongoDB.Driver;

namespace RebarExercise.DataAccess
{
    public class BillDataAccess
    {
        private const string ConnectingString = "mongodb://127.0.0.1:27017";
        private const string DataBaseName = "Rebar";
        private const string CollectionName = "Bills";


        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectingString);
            var database = client.GetDatabase(DataBaseName);
            return database.GetCollection<T>(collection);
        }

        //GET
        public async Task<List<Bill>> GetBills()
        {
            var billsCollection = ConnectToMongo<Bill>(CollectionName);
            var result = await billsCollection.FindAsync(_ => true);
            return result.ToList();
        }

        //POST
        public async Task CreateBill(Bill bill)
        {
            var billsCollection = ConnectToMongo<Bill>(CollectionName);
            await billsCollection.InsertOneAsync(bill);
        }
    }
}
