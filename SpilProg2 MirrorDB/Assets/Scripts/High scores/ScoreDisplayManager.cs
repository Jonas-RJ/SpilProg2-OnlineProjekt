using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreDisplayManager : MonoBehaviour
{


    public HealthManager hm;
    public HighscoreDBManager dbManager;
    public GameObject ScoreCon1;
    public GameObject ScoreCon2;
    public RectTransform scoreContainer;      // The parent object (like ScoreOverview)
    public RectTransform scoreContainer2;      // The parent object (like ScoreOverview)

    public GameObject scoreEntryPrefab;       // ScoresIndividual prefab with TMPs

    void OnEnable()
    {
        ShowScoreboard();
        ShowScoreboard2();
    }


    void Update()
    {
        if (hm.child1.isActiveAndEnabled)
        {
            ScoreCon1 = GameObject.FindGameObjectWithTag("ScoreOverview1");
            scoreContainer = ScoreCon1.GetComponent<RectTransform>();
        }
        if (hm.child2.isActiveAndEnabled)
        {
            ScoreCon2 = GameObject.FindGameObjectWithTag("ScoreOverview2");
            scoreContainer2 = ScoreCon2.GetComponent<RectTransform>();
        }
    }
    public void ShowScoreboard()
    {
        // Clear old entries first
        foreach (Transform child in scoreContainer)
        {
            Destroy(child.gameObject);
        }

        List<HighscoreDBManager.HighscoreEntry> highscores = dbManager.RetrieveHighscores();

        foreach (var entry in highscores)
        {
            GameObject entryGO = Instantiate(scoreEntryPrefab, scoreContainer);

            // Assuming children are named exactly like in the Hierarchy: PlayerName, Score, Wins
            entryGO.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text = entry.name;
            entryGO.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = entry.score.ToString();
            entryGO.transform.Find("Wins").GetComponent<TextMeshProUGUI>().text = entry.wins.ToString();
        }
    }
    public void ShowScoreboard2()
    {
        // Clear old entries first
        foreach (Transform child in scoreContainer2)
        {
            Destroy(child.gameObject);
        }

        List<HighscoreDBManager.HighscoreEntry> highscores = dbManager.RetrieveHighscores();

        foreach (var entry in highscores)
        {
            GameObject entryGO = Instantiate(scoreEntryPrefab, scoreContainer2);

            // Assuming children are named exactly like in the Hierarchy: PlayerName, Score, Wins
            entryGO.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text = entry.name;
            entryGO.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = entry.score.ToString();
            entryGO.transform.Find("Wins").GetComponent<TextMeshProUGUI>().text = entry.wins.ToString();
        }
    }
}