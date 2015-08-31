using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPFPageSwitch;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for TopScoresTable.xaml
    /// </summary>
    public partial class TopScoresTable : UserControl, ISwitchable
    {
        #region private Fields
        //------------------------------------------------------
        //
        //  private Fields
        //
        //------------------------------------------------------
        
        List<Score> scores;

        #endregion private Fields

        #region Constructor
        //------------------------------------------------------
        //
        //  Constructor
        //
        //------------------------------------------------------
        public TopScoresTable(int height, int width)
        {
            int rank = 1;
            string playerName = "";
            string moves = "";
            string time = "";
            string scoree = "";
            string rankString = "";
            string gameName = "";

            InitializeComponent();
            Databases.Database.DatabaseCreateTables();

            //gameName
            scores = Databases.Database.DatabaseReturnData(height.ToString() + width.ToString());

            foreach (Score score in scores)
            {
                rankString += rank.ToString() + Environment.NewLine;
                playerName += score.PlayerName + Environment.NewLine;
                gameName += score.GameName + Environment.NewLine;
                moves += score.Moves + Environment.NewLine;
                time += score.Time + Environment.NewLine;
                scoree += score.ScoreGET + Environment.NewLine;
                rank += 1;
            }
            labelRank.Content = rankString;
            labelPlayerName.Content = playerName;
            labelGameName.Content = gameName;
            labelMoves.Content = moves;
            labelTime.Content = time;
            labelScore.Content = scoree;
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

        #endregion private Methods

    }
}
