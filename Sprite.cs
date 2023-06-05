using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game
{
    public abstract class Sprite
    {
        //ToDo Make a default constructor and set the property Source of the Image. 
        //     The images are in the directory images. 
        //     Make use of the property ImageName.

        public Sprite()
        {
            Image = new Image();
            string imagePath = $"images/{ImageName}";
            Image.Source = new BitmapImage(new Uri(imagePath,UriKind.RelativeOrAbsolute));
        }
        public Image Image { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void AdjustSize(double width, double height);
        public abstract string ImageName { get; }
    }
}
