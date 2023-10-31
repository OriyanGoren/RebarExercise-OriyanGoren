
namespace RebarExercise.Models
{
    public class ShakeMenu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PriceSizeS { get; set; }
        public double PriceSizeM { get; set; }
        public double PriceSizeL { get; set; }

        public ShakeMenu()
        {
            Id = Guid.NewGuid();
        }

        public ShakeMenu(String name = "Relax", String description = "Tropical flavored drink", double priceSizeS = 20, double priceSizeM = 25, double priceSizeL = 30)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            PriceSizeS = priceSizeS;
            PriceSizeM = priceSizeM;
            PriceSizeL = priceSizeL;
        }

    }
}