using System.Windows.Controls;

namespace Game
{
    public class AnimalWorld
    {
        private AnimalWorldPiece[,] _world;
        public int FoodCount { get; set; }

        public AnimalWorld(Canvas canvas, int rows, int columns)
        {
            _world = new AnimalWorldPiece[rows, columns];
            double width = canvas.Width / columns;
            double height = canvas.Height / rows;
            CreateAnimalWorldPieces(canvas, width, height);
        }

        private void CreateAnimalWorldPieces(Canvas canvas, double width, double height)
        {
            for (int i = 0; i < _world.GetLength(0); i++)
            {
                for (int j = 0; j < _world.GetLength(1); j++)
                {
                    _world[i, j] = new AnimalWorldPiece(canvas, height, width, i, j);
                }
            }
        }

        public void AddSpriteToWorld(Sprite sprite, int columnNumber, int rowNumber)
        {// ToDo set the property Sprite of the right element of _world
            _world[rowNumber,columnNumber].Sprite = sprite;
            // ToDo set the X and Y property of the Sprite
            _world[rowNumber, columnNumber].Sprite.X = rowNumber;
            _world[rowNumber, columnNumber].Sprite.Y = columnNumber;

        }

        public void Move(Sprite sprite, int dX, int dY) // dX stepSize in x direction, dY stepSize in y direction
        {
            int leftBorder = 0;
            int rightBorder = _world.GetLength(1);
            int upperborder = 0;
            int lowerborder = _world.GetLength(0);
           
                if(sprite.X + dX >= upperborder && sprite.X +dX <= lowerborder && sprite.Y + dY >= leftBorder && sprite.Y +dY <= rightBorder)
                {
                    if (_world[sprite.X + dX, sprite.Y + dY].ContainsFood)
                    {
                        _world[sprite.X + dX, sprite.Y + dY].RemoveFromAnimalWorldPiece();
                        _world[sprite.X + dX, sprite.Y + dY].Sprite = sprite;
                    }
                    else if (_world[sprite.X + dX, sprite.Y + dY].YouWereHere)
                    {
                        throw new MoveException("You have allready been here");
                    }
                    else
                    {
                        
                        _world[sprite.X, sprite.Y].RemoveFromAnimalWorldPiece();
                        AddSpriteToWorld(sprite,sprite.Y+dY,sprite.X+dX);
                    }
                    
                }
                else
                {
                    throw new MoveException("Illegal move(beyond borders)");
                }

            
     
            // ToDo check if the move is possible. If not => throw a MoveException
            // ToDo check if the player has been on this location. If yes => throw a MoveException
            // ToDo if the move is possible: check if there is food on the new position.
            //      Remove the food from this position and change the value of the FoodCount property

            // ToDo Don't forget to remove the worldobject from the old position and place it on the new position

        }
    }
}
