using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreListPopulator : MonoBehaviour
{
    public HighscoreDBManager dbManager; // Reference to your database manager
    public Transform scoreContainer; // ScoreOverview object (the parent)
    public GameObject scoreEntryPrefab; // ScoresIndividual prefab

    void Start()
    {
        PopulateHighscoreList();
    }

    void PopulateHighscoreList()
    {
        // Clear previous entries
        foreach (Transform child in scoreContainer)
        {
            Destroy(child.gameObject);
        }

        // Fetch highscores from database
        List<HighscoreDBManager.HighscoreEntry> highscores = dbManager.RetrieveHighscores();

        // Instantiate and populate each entry
        foreach (var entry in highscores)
        {
            GameObject newEntry = Instantiate(scoreEntryPrefab, scoreContainer);

            // Find text fields in the prefab and set the values
            TextMeshProUGUI nameText = newEntry.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI scoreText = newEntry.transform.Find("Score").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI winsText = newEntry.transform.Find("Wins").GetComponent<TextMeshProUGUI>();

            nameText.text = entry.name;
            scoreText.text = entry.score.ToString();
            winsText.text = entry.wins.ToString();
        }
    }
}