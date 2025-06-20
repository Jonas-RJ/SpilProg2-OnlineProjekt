using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class HighscoreDBManager : MonoBehaviour
{

    public class HighscoreEntry
    {
        public string name;
        public int score;
        public int wins;

        public HighscoreEntry(string name, int score, int wins)
        {
            this.name = name;
            this.score = score;
            this.wins = wins;
        }
    }


    private void Awake()
    {
        DatabaseCreator();
    }

    //Method to ensure file paths/folders are set, before creating the DB 
    private string GetDBPath()
    {
        //Setting the .db file path in Unity project folder
        string folderPath = Path.Combine(Application.dataPath, "Database");

        //Creates a "Database" folder in /Assets, if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        //Creates the actual highscore db file, names it "Highscores"
        string fullPath = Path.Combine(folderPath, "Highscores.db");
        return $"URI=file:{fullPath}";
    }

    //Initializes the highscore DB (creates the DB if it doesn't exist)
    private void DatabaseCreator()
    {
        //Create and open a connection to the database
        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();

            //Create an SQL command, to send SQL to the database
            using (var command = connection.CreateCommand())
            {
                //This SQL command creates a new table for highscores if it doesn't exist yet
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Highscores (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PlayerName TEXT NOT NULL UNIQUE,
                        Score INTEGER NOT NULL,
                        Wins INTEGER NOT NULL
                    );";

                //Executes the above SQL command
                command.ExecuteNonQuery();
            }
        }
    }

    //Allows the winner to add his name to the highscore list
    public void AddOrUpdateWinner(string playerName)
    {
        playerName = playerName.ToUpper();

        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                //Checks if the winning player already exists in the DB - if yes the entry gets updated
                command.CommandText = "SELECT Score, Wins FROM Highscores WHERE PlayerName = @name;";
                command.Parameters.Add(new SqliteParameter("@name", playerName));

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int currentScore = reader.GetInt32(0);
                        int currentWins = reader.GetInt32(1);
                        reader.Close();

                        command.CommandText =
                            "Update Highscores SET Score = @score, Wins = @wins WHERE PlayerName = @name;";
                        command.Parameters.Add(new SqliteParameter("@score", currentScore + 100));
                        command.Parameters.Add(new SqliteParameter("@Wins", currentWins + 1));
                        command.ExecuteNonQuery();
                    }
                    //If winning player IS NOT in the DB - add a new entry with name, no. of wins and a score 
                    else
                    {
                        reader.Close();
                        command.CommandText =
                            "INSERT INTO Highscores (PlayerName, Score, Wins) VALUES (@name, 100, 1);";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    public List<HighscoreEntry> RetrieveHighscores()
    {
        List<HighscoreEntry> highscores = new List<HighscoreEntry>();

        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT PlayerName, Score, Wins FROM Highscores ORDER BY Wins DESC;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0).ToUpper();
                        int score = reader.GetInt32(1);
                        int wins = reader.GetInt32(2);

                        highscores.Add(new HighscoreEntry(name, score, wins));
                    }
                }
            }
        }
        return highscores;
    }
}