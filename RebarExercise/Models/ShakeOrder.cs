namespace RebarExercise.Models
{
    public class ShakeOrder
    {
        private Guid _ID;
        private String _name;
        private String _description;
        private double _price;
        private String _size;

        public ShakeOrder() 
        {
            _ID = Guid.NewGuid();

        }

    }
}
