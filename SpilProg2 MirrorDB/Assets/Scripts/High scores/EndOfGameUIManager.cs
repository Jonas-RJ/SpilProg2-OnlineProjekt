using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndOfGameUIManager : MonoBehaviour
{
    public HighscoreDBManager dbManager;

    public GameObject winnerPromptPanel;
    public TMP_InputField playerNameInput;  // Use InputField if not using TMP
    public GameObject loserMessage;
    public TextMeshProUGUI highscoreText;   // Use Text if not using TMP

    public GameObject highscorePanel; // This shows highscores on game end or menu

    // Called at game end — pass in true if the player won
    public void OnGameOver(bool playerWon)
    {
        highscorePanel.SetActive(true); // always show highscore list

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

        ShowHighscores(); // update the list after match
    }

    // Called when winner submits name
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

    // This displays the highscore list
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