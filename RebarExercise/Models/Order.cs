using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarExercise.Models
{
    public class Order
    {
        private Guid _ID;
        private String _customerName;
        private DateTime _date;
        private double _price;
        private List<ShakeMenu> _shakesOrder;
        private List<Discounts> _discounts;

        public Order(DateTime date) 
        {
            _ID = Guid.NewGuid();
            _customerName = "customerName";
            _date = date;
            _price = 200;
            _shakesOrder = new List<ShakeMenu>();
            _discounts = new List<Discounts>();
        }

    }
}
