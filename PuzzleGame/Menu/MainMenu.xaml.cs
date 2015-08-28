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

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay());
        }
    }
}
