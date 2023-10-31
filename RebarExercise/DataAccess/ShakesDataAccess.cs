using RebarExercise.Models;
using MongoDB.Driver;

namespace RebarExercise.DataAccess
{
    public class ShakesDataAccess
    {
        private const string ConnectingString = "mongodb://127.0.0.1:27017";
        private const string DataBaseName = "Rebar";
        private const string CollectionName = "Menu";
        private readonly IMongoCollection<ShakeMenu> _shakesFromMenuCollection;

        public ShakesDataAccess()
        {
            _shakesFromMenuCollection = ConnectToMongo<ShakeMenu>(CollectionName);
        }

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectingString);
            var database = client.GetDatabase(DataBaseName);
            return database.GetCollection<T>(collection);
        }

        //GET
        public async Task<List<ShakeMenu>> GetShakesFromMenu()
        {
            var result = await _shakesFromMenuCollection.FindAsync(_ => true);
            return result.ToList();
        }

        //POST
        public async Task CreateShakeToMenu(ShakeMenu shake)
        {
            await _shakesFromMenuCollection.InsertOneAsync(shake);
        }



        public ShakeMenu GetShakeFromMenu(string name)
        {
            var result = _shakesFromMenuCollection.Find(shake => shake.Name == name);
            return result.FirstOrDefault();
        }

    }
}
