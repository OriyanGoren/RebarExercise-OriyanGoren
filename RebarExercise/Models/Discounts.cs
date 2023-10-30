namespace RebarExercise.Models
{
    public class Discounts
    {
        private String _description;
        private double _percentage;

        public Discounts(String description, double percentage)
        {
            _description = description;
            _percentage = percentage;
        }
    }
}
