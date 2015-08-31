using System;
using System.Windows;
using System.Windows.Controls;
using WPFPageSwitch;
using Databases;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl, ISwitchable
    {
        #region Constructor
        //------------------------------------------------------
        //
        //  Constructor
        //
        //------------------------------------------------------
        public MainMenu()
        {
            InitializeComponent();
            Database.DatabaseCreateTables();

            //create sample data
            //Database.DatabaseInsertData("44", "ano", 20, 22);
            //Database.DatabaseInsertData("44", "anol", 80, 122);
            //Database.DatabaseInsertData("44", "anoll", 10, 24);
            //Database.DatabaseInsertData("44", "anoff", 40, 32);
            //Database.DatabaseInsertData("44", "anofd", 50, 82);
            //Database.DatabaseInsertData("44", "anoss", 110, 2);
            //Database.DatabaseInsertData("44", "anosd", 14, 232);
        }

        #endregion Constructor

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private Methods
        //------------------------------------------------------
        //
        //  Private Methods
        //
        //------------------------------------------------------

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

        #endregion Private Methods
    }
}
