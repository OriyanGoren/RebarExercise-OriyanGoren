namespace RebarExercise.Models
{
    public class Bill
    {
        private List<Order> _orders;
        private double _price;

        public Bill(double price)
        {   
            _orders = new List<Order>();
            _price = price;

        }
    }
}
