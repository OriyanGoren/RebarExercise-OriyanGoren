
namespace RebarExercise.Models
{
    public class ShakeOrder
    {
        public Guid Id;
        public string NameShake { get; set; }

        public string NameCustomer { get; set; }
        public double Size { get; set; }


        public ShakeOrder() 
        {
            Id = Guid.NewGuid();
        }

    }
}
