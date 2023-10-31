using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarExercise.Models
{
    public class Bill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        private Guid _ID;
        private List<Order> _orders;
        private double _price;

        public Bill(double price)
        {   
            _ID = Guid.NewGuid();
            _orders = new List<Order>();
            _price = price;

        }
    }
}
