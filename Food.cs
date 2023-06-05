using System.Windows;
using System.Windows.Controls;

namespace Game
{
    public class Food : Sprite
    {
        //ToDo Make a read only property Species 
        public KindOfSpecies Species { get; }

        // ToDo Make a constructor with KindOfSpecies as a parameter

        public Food(KindOfSpecies species)
        {
            Species = species;
        }

        //      Make sure that property Source of the image is correct.
        public override string ImageName => Species.ToString().ToLower() + ".png";

        public override void AdjustSize(double width, double height)
        {
            Image.Width = width / 3;
            Image.Height = height / 3;
            //todo grootte van afbeelding 1/3 meegegeven hoogte en breedte
        }
    }
}
