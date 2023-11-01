namespace RebarExercise.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public int NumberOfOrders { get; set;}
        public double Price { get; set; }

        public Bill()
        {
            Id = Guid.NewGuid();
        }
    }
}
