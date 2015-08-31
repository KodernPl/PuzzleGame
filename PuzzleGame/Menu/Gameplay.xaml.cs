using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPFPageSwitch;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : UserControl, ISwitchable
    {
        #region private Fields
        //------------------------------------------------------
        //
        //  private Fields
        //
        //------------------------------------------------------

        Game game;
        string solution = "";
        int initialHeight;
        int initialWidth;
        int[] CANVAS_SIZE = new int[] { 300, 300 };
        int tileSizeWidth;
        int tileSizeHeight;

        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        System.Windows.Threading.DispatcherTimer timererek;

        #endregion private Fields

        #region Constructor
        //------------------------------------------------------
        //
        //  Constructor
        //
        //------------------------------------------------------
        public Gameplay(int initialHeight, int initialWidth)
        {
            InitializeComponent();
            this.initialHeight = initialHeight;
            this.initialWidth = initialWidth;
            tileSizeWidth = CANVAS_SIZE[0] / initialWidth;
            tileSizeHeight = CANVAS_SIZE[1] / initialHeight;
            canvas.Width = CANVAS_SIZE[0];
            canvas.Height = CANVAS_SIZE[1];

            //focus on button to enable keyhanling
            buttonNewPuzzle.Focus();
            
            //new game
            buttonNewPuzzle_Click(null, null);
            
            //speed of autosolver
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            dispatcherTimer.Start();
            
            //clock timer
            timererek = new System.Windows.Threading.DispatcherTimer();
            timererek.Tick += new EventHandler(timerek_Tick);
            timererek.Interval = new TimeSpan(0, 0, 1);
            timererek.Start();
        }

        #endregion Constructor

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Public Methods
        //------------------------------------------------------
        //
        //  Public Methods
        //
        //------------------------------------------------------

        /// <summary>
        /// Draws Puzzle
        /// </summary>
        public void DrawPuzzle()
        {
            canvas.Children.Clear();
            SolidColorBrush background;
            for (int row = 0; row < game.Puzzle.Height; row++)
            {
                for (int col = 0; col < game.Puzzle.Width; col++)
                {
                    int tileNum = game.Puzzle.GetNumber(row, col);
                    if (tileNum == 0)
                    {
                        background = new SolidColorBrush(Color.FromRgb(255, 128, 255));
                    }
                    else
                    {
                        background = new SolidColorBrush(Color.FromRgb(255, 0, 255));
                    }
                    background.Opacity = 0.4;
                    PointCollection myPointCollection = new PointCollection();
                    myPointCollection.Add(new Point(col * tileSizeWidth, row * tileSizeHeight));
                    myPointCollection.Add(new Point((col + 1) * tileSizeWidth, row * tileSizeHeight));
                    myPointCollection.Add(new Point((col + 1) * tileSizeWidth, (row + 1) * tileSizeHeight));
                    myPointCollection.Add(new Point(col * tileSizeWidth, (row + 1) * tileSizeHeight));

                    Polygon myPolygon = new Polygon();
                    myPolygon.Points = myPointCollection;
                    myPolygon.Fill = background;
                    myPolygon.Stroke = Brushes.White;
                    myPolygon.StrokeThickness = 2;

                    canvas.Children.Add(myPolygon);

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = tileNum.ToString();
                    textBlock.Foreground = Brushes.Black;
                    textBlock.FontSize = ((tileSizeHeight+tileSizeWidth) /2.3) * 0.66;
                    Canvas.SetLeft(textBlock, (col + 0.1) * tileSizeWidth);
                    Canvas.SetTop(textBlock, row * tileSizeHeight);

                    canvas.Children.Add(textBlock);
                }
            }

        }

        #endregion Public Methods

        #region private Methods
        //------------------------------------------------------
        //
        //  Private Methods
        //
        //------------------------------------------------------

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
            if (!game.IsSolved)
            {
                if (game.Puzzle.CheckSolvedAll())
                {
                    dispatcherTimer.Stop();
                    timererek.Stop();
                    Switcher.Switch(new GameOver(game.Moves, game.Time, game.GameName));
                }
            }
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
        }

        /// <summary>
        /// Make Solution Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            solution = game.MakeSolution();
        }

        /// <summary>
        /// New Game Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewPuzzle_Click(object sender, RoutedEventArgs e)
        {
            solution = "";
            game = new Game(initialHeight, initialWidth);
            DrawPuzzle();
        }

        /// <summary>
        /// Stop Game and go to Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            timererek.Stop();
            Switcher.Switch(new MainMenu());
        }

        #endregion Private Methods
    }
}
