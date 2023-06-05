using System.Windows;
using System.Windows.Controls;

namespace Game
{
    public partial class StartWindow : Window
    {
        private int _countRows;
        private int _countColumns;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void AnimalListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // ToDo open the GameWindow. Make sure you give the right arguments in your constructor
            int selectedAnimal = animalListBox.SelectedIndex;
            GameWindow gameWindow = new GameWindow(_countRows,_countColumns,nameTextBox.Text,selectedAnimal);
            gameWindow.Show();


        }
        private void GameRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // ToDo give _countRows and _countColumns the right value.
            if (smallGameRadioButton.IsChecked == true)
            {
                _countRows = 8;
                _countColumns = 10;
            }
            if (gameRadioButton.IsChecked == true)
            {
                _countRows = 12;
                _countColumns = 12;
            }
            if (largeRadioButton.IsChecked == true)
            {
                _countRows = 14;
                _countColumns = 16;
            }

            animalListBox.IsEnabled = true;
        }

        private void Reset()
        {
            smallGameRadioButton.IsChecked = false;
            gameRadioButton.IsChecked = false;
            largeRadioButton.IsChecked = false;
            nameTextBox.Text = "";
            animalListBox.SelectedIndex = -1;
        }
    }
}
