
namespace PuzzleGame
{
    public class Score
    {
        #region private Fields
        //------------------------------------------------------
        //
        //  private Fields
        //
        //------------------------------------------------------

        string playerName;
        string moves;
        string score;
        string time;
        string gameName;

        #endregion private Fields

        #region public Properties

        //------------------------------------------------------
        //
        //  public Properties
        //
        //------------------------------------------------------

        public string GameName
        {
            get { return gameName[0] + "x" + gameName[1]; }
        }

        public string PlayerName
        {
            get { return playerName; }
        }

        public string Moves
        {
            get { return moves; }
        }
       
        public string Time
        {
            get { return time; }
        }
       
        public string ScoreGET
        {
            get { return score; }
        }

        #endregion public Properties

        #region Constructor
        //------------------------------------------------------
        //
        //  Constructor
        //
        //------------------------------------------------------
        public Score(string playerName, string moves, string time, string score, string gameName)
        {
            this.playerName = playerName;
            this.moves = moves;
            this.time = time;
            this.score = score;
            this.gameName = gameName;
        }

        #endregion Constructor

    }
}
