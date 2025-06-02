using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreListPopulator : MonoBehaviour
{
    public HighscoreDBManager dbManager;
    public Transform scoreContainer;
    public GameObject scoreEntryPrefab;

    void Start()
    {
        PopulateHighscoreList();
    }

    void PopulateHighscoreList()
    {
     
        foreach (Transform child in scoreContainer)
        {
            Destroy(child.gameObject);
        }

     
        List<HighscoreDBManager.HighscoreEntry> highscores = dbManager.RetrieveHighscores();

      
        foreach (var entry in highscores)
        {
            GameObject newEntry = Instantiate(scoreEntryPrefab, scoreContainer);

    
            TextMeshProUGUI nameText = newEntry.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI scoreText = newEntry.transform.Find("Score").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI winsText = newEntry.transform.Find("Wins").GetComponent<TextMeshProUGUI>();

            nameText.text = entry.name;
            scoreText.text = entry.score.ToString();
            winsText.text = entry.wins.ToString();
        }
    }
}