using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarExercise.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        private Guid _ID;
        private String _customerName;
        private DateTime _date;
        private double _price;
        private List<ShakeMenu> _shakesOrder;
        private List<Discounts> _discounts;

        public Order(String customerName, DateTime date, double price) 
        {
            _ID = Guid.NewGuid();
            _customerName = customerName;
            _date = date;
            _price = price;
            _shakesOrder = new List<ShakeMenu>();
            _discounts = new List<Discounts>();
        }

    }
}
