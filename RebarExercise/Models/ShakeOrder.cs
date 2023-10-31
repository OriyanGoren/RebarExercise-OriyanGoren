
using RebarExercise.DataAccess;

namespace RebarExercise.Models
{
    public class ShakeOrder
    {
        public Guid Id;
        public string Name { get; set; }
        public String Size { get; set; }
        public double Price { get; set; }


        public ShakeOrder() 
        {
            Id = Guid.NewGuid();
            //Price = CalculatePrice();
        }

        /*private double CalculatePrice()
        {
          
        }*/
    }
}
