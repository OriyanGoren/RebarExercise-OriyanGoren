namespace RebarExercise.Models
{
    public class Order
    {
        private Guid _ID;
        private String _customerName;
        private DateTime _date;
        private double _price;
        private List<ShakeMenu> _shakesOrder;
        private List<Discounts> _discounts;

        public Order() 
        {
            _ID = Guid.NewGuid();

        }

    }
}
