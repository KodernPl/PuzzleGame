using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPFPageSwitch;
using WpfTutorialSamples.Dialogs;
using Databases;
namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : UserControl, ISwitchable
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
        /// <summary>
        /// Constructor for GameOver Page
        /// </summary>
        /// <param name="movesFrom"></param>
        /// <param name="timeFrom"></param>
        /// <param name="gameNameFrom"></param>
        public GameOver(int movesFrom, int timeFrom, string gameNameFrom)
        {
            InitializeComponent();
            string playerNameFrom = DialogPlayerNameInput();
            Database.DatabaseInsertData(gameNameFrom, playerNameFrom, movesFrom, timeFrom);

            int rank = 1;
            string playerName = "";
            string moves = "";
            string time = "";
            string scoree = "";
            string rankString = "";
            string gameName = "";

            InitializeComponent();
            Databases.Database.DatabaseCreateTables();

            scores = Databases.Database.DatabaseReturnData(gameNameFrom);

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

            playerName += Environment.NewLine + "Your Score";
            gameName += Environment.NewLine ;
            moves += Environment.NewLine ;
            time += Environment.NewLine ;
            scoree += Environment.NewLine ;

            playerName += Environment.NewLine + playerNameFrom + Environment.NewLine;
            gameName += Environment.NewLine + gameNameFrom[0]+"x"+gameNameFrom[1] + Environment.NewLine;
            moves += Environment.NewLine + movesFrom + Environment.NewLine;
            time += Environment.NewLine + timeFrom + Environment.NewLine;
            scoree += Environment.NewLine + (movesFrom*timeFrom).ToString() + Environment.NewLine;

            labelRank.Content = rankString;
            labelPlayerName.Content = playerName;
            labelGameName.Content = gameName;
            labelMoves.Content = moves;
            labelTime.Content = time;
            labelScore.Content = scoree;
        }

        #endregion

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
        
        /// <summary>
        /// Back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        /// <summary>
        /// Get playerName from user input
        /// </summary>
        /// <returns></returns>
        private string DialogPlayerNameInput()
        {
            string playerName = "";

            try
            {
                playerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                playerName = playerName.Substring(playerName.LastIndexOf("\\") + 1);
            }
            catch
            {
                playerName = "Anonymous";
            }

            InputDialogSample inputDialog = new InputDialogSample("Great Score!\nPlease enter your name:", playerName);
            if (inputDialog.ShowDialog() == true)
            {
                if (inputDialog.Answer.Length > 10)
                {
                    playerName = inputDialog.Answer.Substring(0, 10);
                }
                else if (inputDialog.Answer.Length == 0)
                {
                    return playerName;
                }
                else
                {
                    playerName = inputDialog.Answer;
                }
            }
            return playerName;
        }

        #endregion private Methods

    }
}
