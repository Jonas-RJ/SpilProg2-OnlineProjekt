using UnityEngine;

public class TestingDB : MonoBehaviour
{

    private HighscoreDBManager dbManager;
    private void Start()
    {
        dbManager = FindObjectOfType<HighscoreDBManager>();
    }

    //This function can be connected to the Button
    public void AddTestHighscore()
    {
        if (dbManager != null)
        {
            string randomPlayerName = "Player" + Random.Range(1, 1000);
            int randomScore = Random.Range(0, 10000);

            dbManager.HighscoreAdd(randomPlayerName, randomScore);

            Debug.Log($"Added highscore: {randomPlayerName} - {randomScore}");
        }
        else
        {
            Debug.LogError("DatabaseManager not found!");
        }
    }
}