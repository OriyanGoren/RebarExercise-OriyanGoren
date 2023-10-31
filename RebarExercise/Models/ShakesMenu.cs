using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarExercise.Models
{
    public class ShakesMenu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        private Guid _ID;
        private List<ShakeMenu> _shakesMenu;

        public ShakesMenu()
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
