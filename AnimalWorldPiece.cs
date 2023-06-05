using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game
{
    public class AnimalWorldPiece
    {
        private Canvas _canvas;
        private double _heigth;
        private double _width;
        private Sprite _sprite;
        private bool _containsFood;

        public AnimalWorldPiece(Canvas canvas, double height, double width, int y, int x)
        {
            // ToDo don't forget to set the X and Y property
            X = x;
            Y = y;
            _width = width;
            _heigth = height;
            _canvas = new Canvas
            {
                Background = new SolidColorBrush(Colors.Green),
                Height = height,
                Width = width,
                Margin = new Thickness(x * width, y * height, 0, 0)
            };
            CreateBorder();
            canvas.Children.Add(_canvas);
        }

        // ToDo make the properties X, Y, ContainsFood, YouWereHere
        public int X { get; set; }
        public int Y { get; set; }

        public bool ContainsFood { get; set; }

        public bool YouWereHere { get; set; }


        // ToDo make the property Sprite
        
        public Sprite Sprite{
            get { return _sprite; }
            set {_sprite = value;
                _sprite.AdjustSize(_heigth, _width);
                
               ContainsFood = CheckForFood();
                _canvas.Children.Add(_sprite.Image);
                // if (!ContainsFood && !YouWereHere)
                // {
                //     _canvas.Children.Add(Sprite.Image);
                // }

            }
        }

        private bool CheckForFood()
        {
            if (_sprite is Food)
            {
                return true;

            }
            return false;
        }

        //      Don't forget to put the image on the Canvas, to adjust the size of the Sprite, to check if it is food




        public void RemoveFromAnimalWorldPiece()
        {
            // ToDo remove the Sprite(= the image of the sprite) from the Canvas and give the Sprite the value null
            if (_sprite is Animal)
            {
                YouWereHere = true;
                _canvas.Background = new SolidColorBrush(Colors.Red);
            }
            _canvas.Children.Remove(_sprite.Image);
            _sprite = null;
            // ToDo if the Sprite is an Animal you have to give the _canvas the color red (Don't forget the property YouWereHere)
            
            
        }

        private void CreateBorder()
        {
            Rectangle rectangle = new Rectangle
            {
                Width = _canvas.Width,
                Height = _canvas.Height,
                Stroke = new SolidColorBrush(Colors.White)
            };
            _canvas.Children.Add(rectangle);
        }
    }
}
