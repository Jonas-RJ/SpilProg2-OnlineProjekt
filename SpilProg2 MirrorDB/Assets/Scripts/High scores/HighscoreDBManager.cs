using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class HighscoreDBManager : MonoBehaviour
{
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
                //This SQL command creates a new table for highscores if it doesn't exist yet //TODO perhaps rename Wins to Victories?
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

    public void AddOrUpdateWinner(string playerName)
    {
        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
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

    
    //-----------------------------//
    /*TODO OLD VERSION OF HIGHSCORE ADDING - PERHAPS DELETE THIS*/
    /*TODO INVOKE FOLLOWING METHOD "HighscoreAdd" WHEN WE HAVE DECIDED HOW AND WHEN A PLAYER CAN ADD THEIR NAME/SCORE TO THE HIGHSCORE LIST#1#*/
    /*
    //Adds a new highscore to the database
    public void HighscoreAdd(string playerName, int score)
    {
        //Open a connection to the database
        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();

            //Create an SQL command, to insert a new highscore
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Highscores (PlayerName, Score) VALUES (@name, @score);";

                //Add parameters to prevent SQL Injection
                command.Parameters.Add(new SqliteParameter("@name", playerName));
                command.Parameters.Add(new SqliteParameter("@score", score));

                //Executes the insert command
                command.ExecuteNonQuery();
            }
        }
        //Debug.Log($"Saved highscore: {playerName} - {score}");
    }
    //-----------------------------//


    /*TODO: INVOKE FOLLOWING METHOD "GetHighscores" WHEN WE HAVE DECIDED HOW AND WHERE TO SHOW THE HIGHSCORE LIST*/
    //Retrieves a list of top highscores from the database, sorted by "highest score first"
    public List<(string name, int score, int wins)> GetHighscores(int limit = 10)
    {
        //Create an empty list to store results
        List<(string, int, int)> highscores = new();

        //Open a connection to the database
        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();

            //Creates SQL command to select top highscores
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT PlayerName, Score, Wins FROM Highscores ORDER BY Score DESC LIMIT @limit;";
                command.Parameters.Add(new SqliteParameter("@limit", limit));
                
                //Execute the command and get a "reader" to go through the results
                using (IDataReader reader = command.ExecuteReader())
                {
                    //Keep reading the rows
                    while (reader.Read())
                    {
                        //First column = winning player name
                        string name = reader.GetString(0);
                        //Second column = total score
                        int score = reader.GetInt32(1);
                        //third column = number of wins
                        int wins = reader.GetInt32(2);

                        //Adds the read info to our highscore leaders list, to be shown
                        highscores.Add((name, score, wins));
                    }
                }
            }
        }
        //Return the highscore list to method invocator
        return highscores;
    }
}