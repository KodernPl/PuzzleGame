using System.Windows.Controls;
using PuzzleGame;

namespace WPFPageSwitch
{
  	public static class Switcher
  	{
    	public static PageSwitcher pageSwitcher;

    	public static void Switch(UserControl newPage)
    	{
      		pageSwitcher.Navigate(newPage);
    	}

    	public static void Switch(UserControl newPage, object state)
    	{
      		pageSwitcher.Navigate(newPage, state);
    	}
  	}
}
