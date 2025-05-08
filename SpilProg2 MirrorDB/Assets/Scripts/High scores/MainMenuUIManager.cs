using UnityEngine;
using TMPro;

public class MainMenuHighscoreDisplay : MonoBehaviour
{
    public HighscoreDBManager dbManager;
    public TextMeshProUGUI highscoreText;

    void Start()
    {
        ShowHighscores();
    }

    void ShowHighscores()
    {
        var highscores = dbManager.RetrieveHighscores();

        highscoreText.text = "Name        Wins     Score\n";
        highscoreText.text += "-----------------------------\n";

        foreach (var entry in highscores)
        {
            string formatted = $"{entry.name,-10} {entry.wins,5} {entry.score,9}";
            highscoreText.text += formatted + "\n";
        }
    }
}