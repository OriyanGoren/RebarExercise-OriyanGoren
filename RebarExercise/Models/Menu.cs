
namespace RebarExercise.Models
{
    public class Menu
    {
        private Guid _ID;
        private List<ShakeMenu> _shakesMenu;

        public Menu()
        {
            _ID = Guid.NewGuid();
            _shakesMenu = new List<ShakeMenu>();
        }
    }
}
