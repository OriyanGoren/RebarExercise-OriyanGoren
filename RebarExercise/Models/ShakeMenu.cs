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

        public ShakeMenu(String name, String description) 
        {
            _ID = Guid.NewGuid();
            _name = name;
            _description = description;
            _priceSizeS = 20;
            _priceSizeM = 25;
            _priceSizeL = 30;

        }

    }
}
