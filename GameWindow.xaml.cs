using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Game
{
    public partial class GameWindow : Window
    {
        private Animal _currentAnimal;  // the choosen animal

        private List<int> _choosenList = new List<int>();// used to generate a Location
        private Random _random = new Random(); // used to generate a location
        private int _countColumns; // number of columns of the AnimalWorld
        private int _countRows; // number of rows of the AnimalWorld
        private AnimalWorld _animalWorld;
        private string _name; // the name of the player
        private int _amountOfFood; // the right amount of food
        private TimeSpan _time; // the time the player has left to play the game
        private DispatcherTimer _timer = new DispatcherTimer();


        //ToDo change the signature of the constructor
        public GameWindow(int rows, int cols, string name, int animalIndex)
        {
            InitializeComponent();
            _countColumns = cols;
            _countRows = rows;
            this.Title = $"speler {name.ToUpper()}";
            // ToDo choose the right animal from the array _allAnimals and remove the comment in R30
            Animal[] _allAnimals = { new Squirrel(), new HedgeHog(), new Rabbit() };
            _currentAnimal = _allAnimals[animalIndex];
            // ToDo calculate the right amount of food
            _amountOfFood = (int)((rows * cols)*0.10);
            CreateWorld(); // implement this method
            // ToDo set the Title of the window 

            // ToDo calculate the total time the player has, to play the game
            _time = TimeSpan.FromSeconds(_amountOfFood*2);
            _timer.Interval = TimeSpan.FromSeconds(1);
            timeTextBox.Text = $"{_time.Seconds} seconden";
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _time = _time.Subtract(TimeSpan.FromSeconds(1));
            timeTextBox.Text = $"{_time.Seconds} seconden";
            if (_time.Seconds <= 0)
            {
                MessageBox.Show("You lose");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // ToDo according to the button you clicked on => one step to the right, to the left, one step up, one step down
           Button button = sender as Button;
            try
            {
                if (button == upButton)
                {
                    _animalWorld.Move(_currentAnimal, 0, -1);
                }
                else if (button == downButton)
                {
                    _animalWorld.Move(_currentAnimal, 0, 1);
                }
                else if (button == leftButton)
                {
                    _animalWorld.Move(_currentAnimal, -1, 0);
                }
                else
                {
                    _animalWorld.Move(_currentAnimal, 1, 0);
                }

            }
            catch (MoveException ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            if (_animalWorld.FoodCount == 0)
            {
                MessageBox.Show("you win, all food is eaten");
            }
            // ToDo check after you moved your player if there remains food => if not player wins and game is over
        }

        private int GenerateLocation()
        {
            int number = _random.Next(_countRows * _countColumns);
            while (_choosenList.Contains(number))
            {
                number = _random.Next(_countRows * _countColumns);
            }
            _choosenList.Add(number);
            return number;
        }
        
        private void PlaceFoodOnBoard()
        {
            for (int i = 0; i < _amountOfFood; i++)
            {
                int number = GenerateLocation();
                Food food = new Food(_currentAnimal.Species);
                _animalWorld.AddSpriteToWorld(food, number % _countColumns, number / _countColumns);
            }
        }

        private void CreateWorld()
        {
            //ToDo Make an AnimalWorld. Don't forget to give the property FoodCount the correct value.
            _animalWorld = new AnimalWorld(gameCanvas,_countRows, _countColumns);
            _animalWorld.FoodCount = _amountOfFood;

          

            PlaceAnimalOnBoard(); // ToDo uncomment the instructions in comment in this method
            PlaceFoodOnBoard();// ToDo uncomment the instructions in comment in this method
        }

        private void EnableButtons()
        {
            leftButton.IsEnabled = true;
            rightButton.IsEnabled = true;
            upButton.IsEnabled = true;
            downButton.IsEnabled = true;
        }

        private void PlaceAnimalOnBoard()
        {
             int number = GenerateLocation();
           _animalWorld.AddSpriteToWorld(_currentAnimal, number % _countColumns, number / _countColumns);

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            EnableButtons();
        }
    }
}
