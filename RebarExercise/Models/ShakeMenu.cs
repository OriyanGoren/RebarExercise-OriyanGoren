using System.Drawing;

namespace RebarExercise.Models
{
    public class ShakeMenu
    {
        private Guid _ID;
        private String _name;
        private String _description;
        private double _priceSizeS;
        private double _priceSizeM;
        private double _priceSizeL;

        public ShakeMenu() 
        {
            _ID = Guid.NewGuid();

        }

    }
}
