using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreDisplayManager : MonoBehaviour
{
    public HighscoreDBManager dbManager;
    public RectTransform scoreContainer;
    public GameObject scoreEntryPrefab;

    void OnEnable()
    {
        ShowScoreboard();
    }

    public void ShowScoreboard()
    {
        //Clear the old entries first
        foreach (Transform child in scoreContainer)
        {
            Destroy(child.gameObject);
        }

        List<HighscoreDBManager.HighscoreEntry> highscores = dbManager.RetrieveHighscores();

        foreach (var entry in highscores)
        {
            GameObject entryGO = Instantiate(scoreEntryPrefab, scoreContainer);


            entryGO.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text = entry.name;
            entryGO.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = entry.score.ToString();
            entryGO.transform.Find("Wins").GetComponent<TextMeshProUGUI>().text = entry.wins.ToString();
        }
    }
}