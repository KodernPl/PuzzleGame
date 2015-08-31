using System.Collections.Generic;
using System.Data.SQLite;
using PuzzleGame;

namespace Databases
{
    public abstract class Database
    {
        /// <summary>
        /// Create DB if not exists
        /// Create Default tables
        /// </summary>
        public static void DatabaseCreateTables()
        {
            // We use these three SQLite objects:
            SQLiteConnection sqliteConn;
            SQLiteCommand sqliteCmd;

            // create a new database connection:
            sqliteConn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;Password=" + GameConstans.DB_PASSWORD + ";");
            sqliteConn.SetPassword(GameConstans.DB_PASSWORD);

            // open the connection:
            sqliteConn.Open();

            // create a new SQL command:
            sqliteCmd = sqliteConn.CreateCommand();

            sqliteCmd.CommandText = "SELECT * FROM sqlite_master";
            var name = sqliteCmd.ExecuteScalar();
             
            // check account table exist or not 
            // if exist do nothing 
            if (name == null)
            {
                for (int row = 4; row < 8; row++)
                {
                    for (int col = 4; col < 8; col++)
                    {
                        // Tables not exist, create tables
                        sqliteCmd.CommandText = "CREATE TABLE '" + row + col + "' (rowID INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE  DEFAULT 1, playerName VARCHAR(20), moves INT, time INT, score INT)";
                        sqliteCmd.ExecuteNonQuery();
                    }
                }
            }
            // We are ready, now lets cleanup and close our connection:
            sqliteConn.Close();  
        }

        /// <summary>
        /// Insert score data into db
        /// </summary>
        /// <param name="gameName"></param>
        /// <param name="playerName"></param>
        /// <param name="moves"></param>
        /// <param name="time"></param>
        public static void DatabaseInsertData(string gameName, string playerName, int moves, int time )
        {
            int score = moves * time;
            // We use these three SQLite objects:
            SQLiteConnection sqliteConn;
            SQLiteCommand sqliteCmd;

            // create a new database connection:
            sqliteConn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;Password=" + GameConstans.DB_PASSWORD + ";");

            // open the connection:
            sqliteConn.Open();

            // create a new SQL command:
            sqliteCmd = sqliteConn.CreateCommand();

            sqliteCmd.CommandText = "INSERT INTO '" + gameName + "' (playerName, moves, time, score) VALUES ('"+ playerName + "', '" + moves + "', '" + time + "', '" + score +"')";
            sqliteCmd.ExecuteNonQuery();

            // We are ready, now lets cleanup and close our connection:
            sqliteConn.Close();
        }

        /// <summary>
        /// Gets List of scores of choosen game from DB
        /// </summary>
        /// <param name="gameName"></param>
        /// <returns></returns>
        public static List<Score> DatabaseReturnData(string gameName)
        {

            // We use these three SQLite objects:
            SQLiteConnection sqliteConn;
            SQLiteCommand sqliteCmd;
            List<Score> scores = new List<Score>();

            // create a new database connection:
            sqliteConn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;Password=" + GameConstans.DB_PASSWORD + ";");

            // open the connection:
            sqliteConn.Open();

            // create a new SQL command:
            sqliteCmd = sqliteConn.CreateCommand();

            // First lets build a SQL-Query again:
            sqliteCmd.CommandText = "SELECT * FROM '" + gameName + "' ORDER BY score ASC LIMIT 5";
            
            //// Now the SQLiteCommand object can give us a DataReader-Object:
            using (SQLiteDataReader sqliteDatareader = sqliteCmd.ExecuteReader())
            {
                //// The SQLiteDataReader allows us to run through the result lines:
                while (sqliteDatareader.Read()) // Read() returns true if there is still a result line to read
                {
                    Score score = new Score(sqliteDatareader["playerName"].ToString(), sqliteDatareader["moves"].ToString(), sqliteDatareader["time"].ToString(), sqliteDatareader["score"].ToString(), gameName);
                    scores.Add(score);
                }
            }
           
            //Delete rows with score greater than 5 score
            if (scores.Count > 4)
            {
                sqliteCmd.CommandText = "DELETE FROM '" + gameName + "' WHERE score>'" + scores[scores.Count-1].ScoreGET + "'";
                sqliteCmd.ExecuteNonQuery();
            }
           
            // We are ready, now lets cleanup and close our connection:
            sqliteConn.Close();
            return scores;
        }
    }
  
}
