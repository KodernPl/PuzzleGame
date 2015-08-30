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

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl, ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = (Window)this.Parent;
            parentWindow.Close();
        }
        #region New game clicks

        private void btnNewGame_4x4_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(4,4));
        }

        private void btnNewGame_4x5_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(4, 5));
        }

        private void btnNewGame_4x6_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(4, 6));
        }

        private void btnNewGame_4x7_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(4, 7));
        }

        private void btnNewGame_5x4_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(5, 4));
        }

        private void btnNewGame_5x5_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(5, 5));
        }

        private void btnNewGame_5x6_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(5, 6));
        }

        private void btnNewGame_5x7_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(5, 7));
        }

        private void btnNewGame_6x4_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(6, 4));
        }

        private void btnNewGame_6x5_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(6, 5));
        }

        private void btnNewGame_6x6_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(6, 6));
        }

        private void btnNewGame_6x7_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(6, 7));
        }

        private void btnNewGame_7x4_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(7, 4));
        }

        private void btnNewGame_7x5_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(7, 5));
        }

        private void btnNewGame_7x6_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(7, 6));
        }

        private void btnNewGame_7x7_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay(7, 7));
        }
        
        #endregion new game clicks 


        private void btnTopScores_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScores());
        }
    }
}
