namespace RebarExercise.Models
{
    public class ShakeOrder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public Discounts Discount { get; set; }

        public ShakeOrder() 
        {
            Id = Guid.NewGuid();
        }
    }
}
