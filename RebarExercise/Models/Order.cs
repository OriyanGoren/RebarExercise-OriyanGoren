namespace RebarExercise.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public List<ShakeOrder> ShakesOrder { get; set; }
        //public List<Discounts> _discounts { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
       
    }
}
