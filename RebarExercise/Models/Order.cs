using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarExercise.Models
{
    public class Order
    {
        public Guid _ID;
        public String _customerName { get; set; }
        public DateTime _date { get; set; }
        public double _price { get; set; }
        public List<ShakeOrder> ShakesOrder { get; set; }
        public List<Discounts> _discounts { get; set; }

        public Order()
        {
            _ID = Guid.NewGuid();
            _price = CalculatePrice();
            ShakesOrder = new List<ShakeOrder>();
            _discounts = new List<Discounts>();
        }

        private double CalculatePrice()
        {
            double price = 0;
            foreach (ShakeOrder shake in ShakesOrder)
            {
                price += shake.Price;
            }
            
            return price;
        }

       
    }
}
