
namespace RebarExercise.Models
{
    public class Discounts
    {
        private String _description;
        public double _percentage { get; set; }

        public Discounts(String description, double percentage)
        {
            _description = description;
            _percentage = percentage;
        }
    }
}
