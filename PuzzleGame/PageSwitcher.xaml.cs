using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageSwitcher : Window
    {
        Game game;
        string solution = "";
        
        int INITIAL_GRID = 4;
        int[] CANVAS_SIZE = new int[] {250, 250};
        int tileSize;

        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        System.Windows.Threading.DispatcherTimer timererek;

        public PageSwitcher()
        {
            InitializeComponent();
            game = new Game(INITIAL_GRID, INITIAL_GRID);

            tileSize = CANVAS_SIZE[0] / INITIAL_GRID;
            canvas.Width = CANVAS_SIZE[0];
            canvas.Height = CANVAS_SIZE[1];
            DrawPuzzle();

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            dispatcherTimer.Start();

            timererek = new System.Windows.Threading.DispatcherTimer();
            timererek.Tick += new EventHandler(timerek_Tick);
            timererek.Interval = new TimeSpan(0, 0, 1);
            timererek.Start();
        }

        /// <summary>
        /// Draws Puzzle
        /// </summary>
        public void DrawPuzzle()
        {
            labelMoves.Content = "Moves: " + game.Moves;
            labelTime.Content = "Time: " + game.Time;
            canvas.Children.Clear();
            SolidColorBrush background;
            for (int row = 0; row < game.Puzzle.Height; row++)
            {
                for (int col = 0; col < game.Puzzle.Width; col++)
                {
                    int tileNum = game.Puzzle.GetNumber(row, col);
                    if (tileNum == 0)
                    {
                        background = new SolidColorBrush(Color.FromRgb(128, 128, 255));
                    }
                    else
                    {
                        background = new SolidColorBrush(Colors.Blue);
                    }
                    PointCollection myPointCollection = new PointCollection();
                    myPointCollection.Add(new Point(col * tileSize, row * tileSize));
                    myPointCollection.Add(new Point((col + 1) * tileSize, row * tileSize));
                    myPointCollection.Add(new Point((col + 1) * tileSize, (row + 1) * tileSize));
                    myPointCollection.Add(new Point(col * tileSize, (row + 1) * tileSize));

                    Polygon myPolygon = new Polygon();
                    myPolygon.Points = myPointCollection;
                    myPolygon.Fill = background;
                    myPolygon.Stroke = Brushes.White;
                    myPolygon.StrokeThickness = 1;

                    canvas.Children.Add(myPolygon);

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = tileNum.ToString();
                    textBlock.Foreground = Brushes.White;
                    textBlock.FontSize = tileSize * 0.66;
                    Canvas.SetLeft(textBlock, (col +0.1) * tileSize);
                    Canvas.SetTop(textBlock, row * tileSize);

                    canvas.Children.Add(textBlock);
                }
            }

        }

        /// <summary>
        /// Keydown handler that allows updates of puzzle using arrow keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Stop autocomplete
            solution = "";

            if (e.Key == Key.Left)
            {
                game.MakeMove("l");
            }
            else if (e.Key == Key.Right)
            {
                game.MakeMove("r");

            }
            else if (e.Key == Key.Up)
            {
                game.MakeMove("u");

            }
            else if (e.Key == Key.Down)
            {
                game.MakeMove("d");

            }
            DrawPuzzle();
        }

        /// <summary>
        /// Timer for incrementally displaying computed solution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (solution == "") return;
            string direction = solution[0].ToString();
            solution = solution.Substring(1);
            try
            {
                game.UpdatePuzzle(direction);
                game.Moves++;
                DrawPuzzle();
            }
            catch (Exception ex)
            {
               // labelInfo.Content = "invalid move:" + direction;
            }

        }

        /// <summary>
        /// Update the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerek_Tick(object sender, EventArgs e)
        {
            game.Time += 1;
            labelTime.Content = "Time: " + game.Time;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            solution = game.MakeSolution();
        }

        private void buttonNewPuzzle_Click(object sender, RoutedEventArgs e)
        {
            solution = "";
            game = new Game(INITIAL_GRID, INITIAL_GRID);
            DrawPuzzle();
        }
       

    }
}

