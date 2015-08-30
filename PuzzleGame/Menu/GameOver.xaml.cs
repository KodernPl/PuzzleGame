using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFPageSwitch;
using WpfTutorialSamples.Dialogs;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : UserControl, ISwitchable
    {
        public GameOver(int moves, int time)
        {
            InitializeComponent();
            labelMoves.Content = "Moves: " + moves.ToString();
            labelTime.Content = "Time: " + time.ToString() + "s";

            InputDialogSample inputDialog = new InputDialogSample("Top Score!\nPlease enter your name:", "Anonymous");
            if (inputDialog.ShowDialog() == true)
                labelName.Content = inputDialog.Answer;


        }
        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
    }
}
