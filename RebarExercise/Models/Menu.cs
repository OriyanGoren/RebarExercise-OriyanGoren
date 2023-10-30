namespace RebarExercise.Models
{
    public class Menu
    {
        private List<ShakeMenu> _shakesMenu;


        private void ShowMenu()
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
        }

        public Menu() 
        {
            _shakesMenu = new List<ShakeMenu>();
        }
    }
}
