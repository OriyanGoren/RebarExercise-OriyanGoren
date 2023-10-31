using RebarExercise.Models;
using RebarExercise.DataAccess;
using MongoDB.Driver;

namespace RebarExercise.DataAccess
{
    public class ShakesMenuDataAccess
    {
        private const string ConnectingString = "mongodb://127.0.0.1:27017";
        private const string DataBaseName = "Rebar";
        private const string CollectionName = "Menu";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectingString);
            var database = client.GetDatabase(DataBaseName);
            return database.GetCollection<T>(collection);
        }

        //GET
        public async Task<List<ShakesMenu>> GetShakesFromMenu()
        {
            var shakesFromMenuCollection = ConnectToMongo<ShakesMenu>(CollectionName);
            var result = await shakesFromMenuCollection.FindAsync(_ => true);
            return result.ToList();
        }

        //POST
        public async Task CreateShakeToMenu(ShakesMenu shakeToMenu)
        {
            var shakesFromMenuCollection = ConnectToMongo<ShakesMenu>(CollectionName);
            await shakesFromMenuCollection.InsertOneAsync(shakeToMenu);
        }
        
    }
}
