// These are the necessary namespaces we need

using System.Collections.Generic; // To use List<>
using UnityEngine; // Basic Unity functionality
using Mono.Data.Sqlite; // The SQLite library for Unity
using System.Data; // General database types (like IDbConnection)
using System.IO; // To work with files (checking if the DB file exists)

public class HighscoreDBManager : MonoBehaviour
{
    private string GetDBPath()
    {
        //Setting the .db file path for the actual database file
        string folderPath = Path.Combine(Application.dataPath, "Database");
        
        //Create this folder if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        
        string fullPath = Path.Combine(folderPath, "Highscores.db");
        
        return $"URI=file:{fullPath}";

        // Always return a fresh connection string
    }

    private void Awake()
    {
        // Set up the path where the database file will be stored.
        // Application.persistentDataPath gives a folder that Unity keeps safe between sessions.
        //dbName = $"URI=file:{Application.persistentDataPath}/highscores.db";

        // Try to create the database if it doesn't exist
        DatabaseCreator();
    }

    /// <summary>
    /// Creates the database file and table, if they don't already exist
    /// </summary>
    private void DatabaseCreator()
    {
        // // Check if the file actually exists yet
        // if (!File.Exists($"{Application.persistentDataPath}/highscores.db"))
        // {
        //     Debug.Log("NO database exists! Creating new database...");
        // }

        // Create and open a connection to the database
        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();

            // Create a new command to send SQL to the database
            using (var command = connection.CreateCommand())
            {
                // This SQL command creates a new table for highscores if it doesn't exist yet
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Highscores (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PlayerName TEXT NOT NULL,
                        Score INTEGER NOT NULL
                    );";

                // Actually run the SQL command
                command.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// Adds a new highscore to the database
    /// </summary>
    public void HighscoreAdd(string playerName, int score)
    {
        // Open a connection to the database
        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();

            // Create a SQL command to insert a new highscore
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Highscores (PlayerName, Score) VALUES (@name, @score);";

                // Add parameters to prevent SQL Injection
                command.Parameters.Add(new SqliteParameter("@name", playerName));
                command.Parameters.Add(new SqliteParameter("@score", score));

                // Execute the insert command
                command.ExecuteNonQuery();
            }
        }

        Debug.Log($"Saved highscore: {playerName} - {score}");
    }

    /// <summary>
    /// Retrieves a list of top highscores from the database
    /// </summary>
    public List<(string name, int score)> GetHighscores(int limit = 10)
    {
        List<(string, int)> highscores = new(); // Create an empty list to store results

        // Open a connection to the database
        using (var connection = new SqliteConnection(GetDBPath()))
        {
            connection.Open();

            // Create a command to select top highscores
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT PlayerName, Score FROM Highscores ORDER BY Score DESC LIMIT {limit};";

                // Execute the command and get a "reader" to go through the results
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // Keep reading rows
                    {
                        string name = reader.GetString(0); // First column = name
                        int score = reader.GetInt32(1); // Second column = score

                        highscores.Add((name, score)); // Add the tuple to our list
                    }
                }
            }
        }

        return highscores; // Return the list
    }
}