using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndOfGameUIManager : MonoBehaviour
{
    public HighscoreDBManager dbManager;

    public GameObject winnerPromptPanel;
    public TMP_InputField playerNameInput;
    public GameObject loserMessage;
    public TextMeshProUGUI highscoreText;

    public GameObject highscorePanel;


    public void OnGameOver(bool playerWon)
    {
        highscorePanel.SetActive(true);

        if (playerWon)
        {
            winnerPromptPanel.SetActive(true);
            loserMessage.SetActive(false);
        }
        else
        {
            winnerPromptPanel.SetActive(false);
            loserMessage.SetActive(true);
        }

        ShowHighscores();
    }

    public void OnSubmitName()
    {
        string name = playerNameInput.text;

        if (!string.IsNullOrEmpty(name))
        {
            name = name.ToUpper();

            dbManager.AddOrUpdateWinner(name);
            winnerPromptPanel.SetActive(false);
            ShowHighscores();
        }
    }


    public void ShowHighscores()
    {
        var highscores = dbManager.RetrieveHighscores();

        highscoreText.text = "Name        Wins     Score\n";
        highscoreText.text += "-----------------------------\n";

        foreach (var entry in highscores)
        {
            string formatted = $"{entry.name,-10} {entry.wins,5} {entry.score,9}";
            highscoreText.text += formatted + "\n";
        }

        FindObjectOfType<ScoreDisplayManager>()?.ShowScoreboard();
    }
}