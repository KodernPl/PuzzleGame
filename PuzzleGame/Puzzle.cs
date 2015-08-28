using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleGame
{
    /// <summary>
    /// Class representation for the Fifteen puzzle
    /// </summary>
    public class Puzzle
    {
        #region private Fields
        //------------------------------------------------------
        //
        //  private Fields
        //
        //------------------------------------------------------
        int height;
        int width;
        private int[,] grid;
        #endregion private Fields

        #region public Properties

        //------------------------------------------------------
        //
        //  public Properties
        //
        //------------------------------------------------------

        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }
        #endregion public Properties

        #region Constructors

        //------------------------------------------------------
        //
        //  Constructors
        //
        //------------------------------------------------------
        /// <summary>
        /// Initialize puzzle with default height and width
        /// </summary>
        /// <param name="puzzleHeight"></param>
        /// <param name="puzzleWidth"></param>
        /// <param name="initialGrid"></param>
        public Puzzle(int puzzleHeight, int puzzleWidth, int[,] initialGrid = null)
        {
            this.height = puzzleHeight;
            this.width = puzzleWidth;
            this.grid = new int[puzzleHeight, puzzleWidth];

            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    this.grid[row, col] = col + row * this.width;
                }
            }

            //Custom tiles
            if (initialGrid != null)
            {
                for (int row = 0; row < puzzleHeight; row++)
                {
                    for (int col = 0; col < puzzleWidth; col++)
                    {
                        this.grid[row, col] = initialGrid[row, col];
                    }
                }
            }
            else
            {
                //Randomize tiles
                this.Randomize();
            }
        }
        #endregion Constructors

        #region public Methods

        //------------------------------------------------------
        //
        //  public Methods
        //
        //------------------------------------------------------

        /// <summary>
        /// Getter for the number at tile position pos
        ///        Returns an integer
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int GetNumber(int row, int col)
        {
            return this.grid[row, col];
        }

        /// <summary>
        /// Setter for the number at tile position pos
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public void SetNumber(int row, int col, int value)
        {
            this.grid[row, col] = value;
        }

        /// <summary>
        /// Make a copy of the puzzle to update during solving
        /// </summary>
        /// <returns></returns>
        public Puzzle Clone()
        {
            Puzzle newPuzzle = new Puzzle(this.height, this.width, this.grid);
            return newPuzzle;
        }

        /// <summary>
        ///  Updates the puzzle state based on the provided move string
        /// </summary>
        /// <param name="moveString"></param>
        public void UpdatePuzzle(string moveString)
        {
            int zeroRow = CurrentPosition(0, 0)[0];
            int zeroCol = CurrentPosition(0, 0)[1];

            foreach (char direction in moveString)
            {
                if (direction.ToString() == "l")
                {
                    if (!(zeroCol <= 0))
                    {//throw new Exception("Move off grid: " + direction);

                        this.grid[zeroRow, zeroCol] = this.grid[zeroRow, zeroCol - 1];
                        this.grid[zeroRow, zeroCol - 1] = 0;
                        zeroCol -= 1;
                    }
                }
                else if (direction.ToString() == "r")
                {
                    if (!(zeroCol >= (this.width - 1)))
                    {// throw new Exception("Move off grid: " + direction);

                        this.grid[zeroRow, zeroCol] = this.grid[zeroRow, zeroCol + 1];
                        this.grid[zeroRow, zeroCol + 1] = 0;
                        zeroCol += 1;
                    }
                }
                else if (direction.ToString() == "u")
                {
                    if (!(zeroRow <= 0))
                    { //throw new Exception("Move off grid: " + direction);

                        this.grid[zeroRow, zeroCol] = this.grid[zeroRow - 1, zeroCol];
                        this.grid[zeroRow - 1, zeroCol] = 0;
                        zeroRow -= 1;
                    }
                }
                else if (direction.ToString() == "d")
                {
                    if (!(zeroRow >= (this.height - 1)))
                    {
                        //throw new Exception("Move off grid: " + direction);

                        this.grid[zeroRow, zeroCol] = this.grid[zeroRow + 1, zeroCol];
                        this.grid[zeroRow + 1, zeroCol] = 0;
                        zeroRow += 1;
                    }
                }
                else
                {
                    throw new Exception("Invalid move: " + direction);
                }
            }
        }

        /// <summary>
        /// Checks if puzzle is solved
        ///  Returns a boolean.
        /// </summary>
        /// <returns></returns>
        public bool CheckSolvedAll()
        {
            int[,] tiles = new int[this.height, this.width];
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    tiles[row, col] = col + row * this.width;
                }
            }
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    if (tiles[row, col] != this.grid[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        /// <summary>
        /// Checks whether any of the tiles in this and following rows are solved.
        ///  Uses adjust_col to shift the column of the tiles to check.
        ///  Returns a boolean.
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="targetCol"></param>
        /// <param name="adjustCol"></param>
        /// <returns></returns>
        public bool CheckSolved(int targetRow, int targetCol, int adjustCol = 1)
        {
            //Generate the default tiles
            int[,] tiles = new int[this.height, this.width];
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    tiles[row, col] = col + row * this.width;
                }
            }
            
            for (int row = targetRow; row < this.height; row++)
            {
                for (int col = targetCol + adjustCol; col < this.width; col++)
                {
                    int numberDefault = tiles[row, col];
                    int numberThis = this.grid[row, col];
                    if (numberDefault != numberThis)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Solve the tile in row zero at the specified column
        ///  Updates puzzle and returns a move string
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public string SolveRow0Tile(int targetCol)
        {
            string move = "";
            if (!this.Row0Invariant(targetCol))
            {
                //throw new Exception("Row 0 Invariant exception");    
            }
            //Do a cheeky left-down to see if this has solved the tile
            this.UpdatePuzzle("ld");

            //Get the current position of the tile to be solved
            int currentRow = this.CurrentPosition(0, targetCol)[0];
            int currentCol = this.CurrentPosition(0, targetCol)[1];

            //If the tile isn't solved yet we keep swimming
            if (currentRow != 0 && currentCol != targetCol)
            {
                //Solve the tile at (1, target_col - 1)
                move = this.PositionTile(1, targetCol - 1, currentRow, currentCol);
                //...and add move string 
                move += "urdlurrdluldrruld";
            }

            this.UpdatePuzzle(move);
            
            if (!this.Row1Invariant(targetCol - 1))
            {
                //throw new Exception("Row 1 Invariant exception");  
            }

            //Add the "ld" we did at the beginning
            return "ld" + move;
        }

        /// <summary>
        /// Solve the tile in row one at the specified column
        /// Updates puzzle and returns a move string
        /// </summary>
        /// <param name="targetCol"></param>
        /// <returns></returns>
        public string SolveRow1Tile(int targetCol)
        {
            //Get the current position of the tile to be solved
            int currentRow = this.CurrentPosition(1, targetCol)[0];
            int currentCol = this.CurrentPosition(1, targetCol)[1];

            //Generate the move string from the current to the target position
            string move = this.PositionTile(1, targetCol, currentRow, currentCol);

            //Also move tile zero up and right
            move += "ur";
            this.UpdatePuzzle(move);

            return move;
        }

        /// <summary>
        /// Generate a solution string for a puzzle
        /// Updates the puzzle and returns a move string
        /// </summary>
        /// <returns></returns>
        public string SolvePuzzle()
        {
            string move = "";
            //Check if this puzzle is already solved
            if (this.CheckSolved(0, 0))
            {
                return "";
            }

            int rows = this.Height - 1;
            int cols = this.Width - 1;

            //# Get the puzzle's dimensions
            if (this.GetNumber(rows, cols) != 0) /////?????????
            {
                int currentRow = this.CurrentPosition(0, 0)[0];
                int currentCol = this.CurrentPosition(0, 0)[1];
                int deltaRow = this.Delta(rows, cols, currentRow, currentCol)[0];
                int deltaCol = this.Delta(rows, cols, currentRow, currentCol)[1];
                move += string.Concat(Enumerable.Repeat("d", deltaRow)) + string.Concat(Enumerable.Repeat("r", deltaCol));
                this.UpdatePuzzle(move);
            }

            //Iterate over the bottom rows in reverse order, i.e. bottom right corner first
            for (int row = rows; row > 1; row--)
            {
                for (int col = cols; col > 0; col--)
                {
                    move += this.SolveInteriorTile(row, col);
                }
                move += this.SolveCol0Tile(row);
            }
            //Iterate over outermost colums in the top two rows in reverse order
            for (int col = cols; col > 1; col--)
            {
                move += this.SolveRow1Tile(col);

                move += this.SolveRow0Tile(col);
            }

            //Add the move string from solve_2x2()
            move += this.Solve2x2();
            
            return move;
        }

        /// <summary>
        /// Solve tile in column zero on specified row (> 1)
        ///  Updates puzzle and returns a move string
        /// </summary>
        /// <param name="targetRow"></param>
        /// <returns></returns>
        public string SolveCol0Tile(int targetRow)
        {
            string moveStr;

            if (!this.LowerRowInvariant(targetRow, 0)) 
            {
                //throw new Exception("Lower Row invariant Exception");
            }
            moveStr = "";

            //Do a cheeky up-right to see if this has solved the tile
            this.UpdatePuzzle("ur");

            //Get the current position of the tile to be solved
            int currentRow = this.CurrentPosition(targetRow, 0)[0];
            int currentCol = this.CurrentPosition(targetRow, 0)[1];

            //If the tile isn't solved yet we keep swimming
            if (currentRow != targetRow && currentCol != 0)
            {
                //Solve the tile at (target_row - 1, 1)...
                moveStr = this.PositionTile(targetRow - 1, 1, currentRow, currentCol);
                //and add move string 
                moveStr += "ruldrdlurdluurddlur";
            }

            // Shift tile 0 to the right
            moveStr += string.Concat(Enumerable.Repeat("r", this.Width - 2));
            this.UpdatePuzzle(moveStr);
            if (!this.LowerRowInvariant(targetRow - 1, this.Width - 1))
            {
                //throw new Exception("Lower Row invariant Exception");       
            }
            // Add the "ur" we did at the beginning
            return "ur" + moveStr;
        }

        /// <summary>
        /// Solve the upper left 2x2 part of the puzzle
        ///  Updates the puzzle and returns a move string
        /// </summary>
        /// <returns></returns>
        public string Solve2x2()
        {
            string moveStr = "";
            if (this.CurrentPosition(0, 0)[0] != 0 && this.CurrentPosition(0, 0)[1] != 0)
            {
                moveStr += "ul";
                this.UpdatePuzzle("ul");
            }
            if (!this.Row0Invariant(0))
            {
                string moveUpdate = "";
                if (this.CurrentPosition(1, 1)[0] != 0 && this.CurrentPosition(1, 1)[1] != 1)
                {
                    moveUpdate = "drul";
                }
                else  
                {
                    moveUpdate = "rdlu";
                }
                moveStr += moveUpdate;
                this.UpdatePuzzle(moveUpdate);
            }
            return moveStr;
        }

        /// <summary>
        /// Place correct tile at target position
        /// Updates puzzle and returns a move string
        /// </summary>
        /// <param name="targeRow"></param>
        /// <param name="targetCol"></param>
        /// <returns></returns>
        public string SolveInteriorTile(int targetRow, int targetCol)
        {
            if (!this.LowerRowInvariant(targetRow, targetCol))
            {
                //throw new Exception("lower wariant exc in SolveInverior");
            }

            int[] targetPos = CurrentPosition(targetRow, targetCol);
            string moveStr = "";
            int rowDiff = Math.Abs(targetRow - targetPos[0]);
            int colDiff = Math.Abs(targetCol - targetPos[1]);

            if (targetPos[0] == targetRow)
            {
                string a, b;
                if (colDiff > 0)
                {
                    a = string.Concat(Enumerable.Repeat("l", colDiff));
                }
                else
                {
                    a = "";
                }
                if (colDiff > 1)
                {
                    b = string.Concat(Enumerable.Repeat("urrdl", colDiff - 1));
                }
                else
                {
                    b = "";
                }
                moveStr += a + b;
            }
            else
            {
                moveStr += string.Concat(Enumerable.Repeat("u", rowDiff));
                if (colDiff == 0)
                {
                    moveStr += string.Concat(Enumerable.Repeat("lddru", rowDiff - 1)) + "ld";
                }
                else
                {
                    if (targetPos[0] == 0)
                    {
                        if (targetPos[1] > targetCol)
                        {
                            moveStr += string.Concat(Enumerable.Repeat("r", colDiff));
                            moveStr += string.Concat(Enumerable.Repeat("dllur", (colDiff - 1))) + "dl";
                        }
                        else
                        {
                            moveStr += string.Concat(Enumerable.Repeat("l", colDiff));
                            moveStr += string.Concat(Enumerable.Repeat("drrul", (colDiff - 1))) + "dr";
                        }
                    }
                    else
                    {
                        if (targetPos[1] > targetCol)
                        {
                            moveStr += string.Concat(Enumerable.Repeat("r", colDiff));
                            moveStr += string.Concat(Enumerable.Repeat("ulldr", (colDiff - 1))) + "ullddr";
                        }
                        else
                        {
                            moveStr += string.Concat(Enumerable.Repeat("l", colDiff));
                            moveStr += string.Concat(Enumerable.Repeat("urrdl", (colDiff - 1))) + "dr";
                        }
                    }
                    moveStr += string.Concat(Enumerable.Repeat("ulddr", (rowDiff - 1))) + "uld";

                }
            }
            this.UpdatePuzzle(moveStr);
            return moveStr;
         
        }

        /// <summary>
        ///       Check whether the puzzle satisfies the specified invariant
        ///        at the given position in the bottom rows of the puzzle (target_row > 1)
        ///        Returns a boolean
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="targetCol"></param>
        /// <returns></returns>
        public bool LowerRowInvariant(int targetRow, int targetCol, bool rowInvariant = false)
        {
            bool invariant;
            int col;
            if (rowInvariant != false)
            {
                invariant = true;
                col = targetCol;
            }
            else
            {
                col = targetCol + 1;
                invariant = (this.GetNumber(targetRow, targetCol) == 0);
            }
            for (int row = targetRow; row < this.Height; row++)
            {
                while (col < this.Width && invariant)
                {
                    invariant = invariant && this.CurrentPosition(row, col)[0] == row && this.CurrentPosition(row, col)[1] == col;
                    col += 1;
                }
                col = 0;
                if (!invariant)
                {
                    break;
                }
            }
            return invariant;
        }

        /// <summary>
        /// Check whether the puzzle satisfies the row zero invariant
        ///  at the given column (col > 1)
        ///  Returns a boolean
        /// </summary>
        /// <param name="targetCol"></param>
        /// <returns></returns>
        public bool Row0Invariant(int targetCol)
        {
            bool invariant = this.LowerRowInvariant(1, targetCol, true) && this.CurrentPosition(0, 0)[0] == 0 && this.CurrentPosition(0, 0)[1] == targetCol;
            int col = targetCol + 1;
            while (col < this.Height && invariant)
            {
                invariant = invariant && this.CurrentPosition(0, col)[0] == 0 && this.CurrentPosition(0, col)[1] == col && this.CurrentPosition(1, col)[0] == 1 && this.CurrentPosition(1, col)[1] == col;
                col += 1;
            }
            return invariant;
        }

        /// <summary>
        /// Check whether the puzzle satisfies the row one invariant
        /// at the given column (col > 1)
        ///  Returns a boolean
        /// </summary>
        /// <param name="targetCol"></param>
        /// <returns></returns>
        public bool Row1Invariant(int targetCol)
        {
            bool invariant = this.LowerRowInvariant(1, targetCol);
            int col = targetCol + 1;
            while (col < this.Height && invariant)
            {
                invariant = invariant && this.CurrentPosition(0, col)[0] == 0 && this.CurrentPosition(0, col)[1] == col;
                col += 1;
            }
            return invariant;
        }
        #endregion public Methods

        #region private Methods

        //------------------------------------------------------
        //
        //  private Methods
        //
        //------------------------------------------------------
        /// <summary>
        /// Randomize solveable puzzle
        /// </summary>
        private void Randomize()
        {
            Random rnd = new Random();

            for (int idx = 0; idx < 15; idx++)
            {
                List<string> directions = new List<string>();
                int[] rpuzPos = this.CurrentPosition(0, 0);
                //if (rpuzPos[0] != 0)
                //{
                //    directions.Add("u");  //if not on the top row
                //}
                if (rpuzPos[0] != this.Height - 1)
                {
                    directions.Add("d");  //if not on the bottom row
                }
                if (rpuzPos[1] != 0)
                {
                    directions.Add("l");  //if not in the right column
                }
                if (rpuzPos[1] != this.Width - 1)
                {
                    directions.Add("r");  //if not in the right column
                }
                int r = rnd.Next(directions.Count);
                this.UpdatePuzzle(directions[r]);
            }
        }

        /// <summary>
        /// Locate the current position of the tile that will be at
        /// position (solved_row, solved_col) when the puzzle is solved
        ///  Returns a tuple of two integers
        /// </summary>
        /// <param name="solvedRow"></param>
        /// <param name="solverCol"></param>
        private int[] CurrentPosition(int solvedRow, int solvedCol)
        {
            int solvedValue = (solvedCol + this.width * solvedRow);

            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    if (this.grid[row, col] == solvedValue)
                    {
                        return new int[] { row, col };
                    }
                }
            }
            throw new Exception("Value " + solvedValue + " not found");
        }

        /// <summary>
        /// Checks if the string has unnecessary cyclic strings such as 'ud' or 'lr'
        /// </summary>
        /// <param name="stringa"></param>
        /// <returns></returns>
        private bool StringInvariant(string stringa)
        {
            int index = 0;
            List<string> lista = new List<string>();
            lista.Add("lr");
            lista.Add("rl");
            lista.Add("ud");
            lista.Add("du");
            while (index < stringa.Length - 1)
            {
                if (lista.Contains((stringa[index] + stringa[index + 1]).ToString()))
                {
                    return false;
                }
                else
                {
                    index += 1;
                }
            }
            return true;
        }

        /// <summary>
        ///   This doc string is dedicated to Prof Rixner.
        ///        Returns a tuple.
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="targetCol"></param>
        /// <param name="currentRow"></param>
        /// <param name="currentCol"></param>
        /// <returns></returns>
        private int[] Delta(int targetRow, int targetCol, int currentRow, int currentCol)
        {
            int delta_row = Math.Abs(targetRow - currentRow);
            int delta_col = Math.Abs(targetCol - currentCol);

            return new int[] { delta_row, delta_col };
        }

        /// <summary>
        ///  Takes the current and target positions of a tile and calculates the moves.
        ///   Returns a string.
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="targetCol"></param>
        /// <param name="currentRow"></param>
        /// <param name="currentCol"></param>
        /// <returns></returns>
        private string PositionTile(int targetRow, int targetCol, int currentRow, int currentCol)
        {
            string move = "";

            // Get the row and column deltas
            int deltaRow = this.Delta(targetRow, targetCol, currentRow, currentCol)[0];
            int deltaCol = this.Delta(targetRow, targetCol, currentRow, currentCol)[1];

            // Move 0 tile to the same row as target tile
            move += string.Concat(Enumerable.Repeat("u", deltaRow));

            // Target tile is to left of the 0 tile
            if (currentCol < targetCol)
            {
                // Position 0 tile to the left of target tile
                move += string.Concat(Enumerable.Repeat("l", deltaCol));
                // Move the target tile until we're in the target column
                // If we're in the top row circle underneath...
                if (currentRow == 0)
                {
                    move += string.Concat(Enumerable.Repeat("drrul", deltaCol - 1));
                }
                // otherwise circle above
                else
                {
                    move += string.Concat(Enumerable.Repeat("urrdl", deltaCol - 1));
                }
                // Move the target tile down until we're in the target row
                move += string.Concat(Enumerable.Repeat("druld", deltaRow));
                // Target tile is to the right of the 0 tile
            }

            else if (currentCol > targetCol)
            {
                // Position 0 tile to the left of target tile
                move += string.Concat(Enumerable.Repeat("r", deltaCol - 1));
                // Move the target tile until we're in the target column
                // If we're in the top row circle underneath...
                if (currentRow == 0)
                {
                    move += string.Concat(Enumerable.Repeat("rdllu", deltaCol));
                }
                // ...otherwise circle above
                else
                {
                    move += string.Concat(Enumerable.Repeat("rulld", deltaCol));
                }
                // Move the target tile down until we're in the target row
                move += string.Concat(Enumerable.Repeat("druld", deltaRow));
                // Target tile is in the same column
            }

            else
            {
                // Position 0 tile to the left of target tile
                move += "ld";
                // Move the target tile down until we're in the target row
                if (deltaRow - 1 > 0)
                {
                    move += string.Concat(Enumerable.Repeat("druld", deltaRow - 1));
                }
            }
            return move;
        }

        #endregion private Methods

    }
}

