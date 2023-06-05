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
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri($"images/{ImageName}", UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();

            Image image = new Image();
            image.Source = bitmapImage;
            Image = image;
        }
        public Image Image { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void AdjustSize(double width, double height);
        public abstract string ImageName { get; }
    }
}
