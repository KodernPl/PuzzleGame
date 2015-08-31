using System;
using System.Windows;
using System.Windows.Controls;
using WPFPageSwitch;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for TopScores.xaml
    /// </summary>
    public partial class TopScores : UserControl, ISwitchable
    {
        #region Constructor
        //------------------------------------------------------
        //
        //  Constructor
        //
        //------------------------------------------------------
        public TopScores()
        {
            InitializeComponent();
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        #region score click button event

        private void btnTopScore_4x4_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(4,4));
        }

        private void btnTopScore_4x5_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(4, 5));
        }

        private void btnTopScore_4x6_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(4, 6));
        }

        private void btnTopScore_4x7_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(4, 7));
        }

        private void btnTopScore_5x4_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(5, 4));
        }

        private void btnTopScore_5x5_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(5, 5));
        }

        private void btnTopScore_5x6_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(5, 6));
        }

        private void btnTopScore_5x7_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(5, 7));
        }

        private void btnTopScore_6x4_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(6, 4));
        }

        private void btnTopScore_6x5_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(6, 5));
        }

        private void btnTopScore_6x6_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(6, 6));
        }

        private void btnTopScore_6x7_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(6, 7));
        }

        private void btnTopScore_7x4_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(7, 4));
        }

        private void btnTopScore_7x5_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(7, 5));
        }

        private void btnTopScore_7x6_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(7, 6));
        }

        private void btnTopScore_7x7_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new TopScoresTable(7, 7));
        }
        
        #endregion new game clicks 

        #endregion private Methods

    }
}
