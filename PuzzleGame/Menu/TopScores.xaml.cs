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
    /// Interaction logic for TopScores.xaml
    /// </summary>
    public partial class TopScores : UserControl, ISwitchable
    {
        public TopScores()
        {
            InitializeComponent();
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

        #region score click button event

        private void btnTopScore_4x4_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnTopScore_4x5_click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnTopScore_4x6_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnTopScore_4x7_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnTopScore_5x4_click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnTopScore_5x5_click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnTopScore_5x6_click(object sender, RoutedEventArgs e)
        {
         
        }

        private void btnTopScore_5x7_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnTopScore_6x4_click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnTopScore_6x5_click(object sender, RoutedEventArgs e)
        {
         
        }

        private void btnTopScore_6x6_click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnTopScore_6x7_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnTopScore_7x4_click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnTopScore_7x5_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnTopScore_7x6_click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnTopScore_7x7_click(object sender, RoutedEventArgs e)
        {
           
        }
        
        #endregion new game clicks 

    }
}
