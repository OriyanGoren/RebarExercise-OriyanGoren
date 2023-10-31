
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

        /*private void ShowMenu()
        {

        }

        private void AddShakeToMenu(ShakeMenu shakeMenu)
        {
            if(_shakesMenu.Contains(shakeMenu))
            {
                throw new Exception("Shake already exists in menu");
            }
            if(shakeMenu == null)
            {
                throw new Exception("Shake cannot be null");
            }
            _shakesMenu.Add(shakeMenu);
        }*/
    }
}
