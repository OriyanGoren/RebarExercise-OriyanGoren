namespace RebarExercise.Models
{
    public class ShakeOrder
    {
        private Guid _ID;
        private String _name;
        private String _description;
        private double _price;
        private String _size;

        public ShakeOrder(String name, String description, double price, String size) 
        {
            _ID = Guid.NewGuid();
            _name = name;
            _description = description;
            _price = price;
            _size = size;
        }

    }
}
