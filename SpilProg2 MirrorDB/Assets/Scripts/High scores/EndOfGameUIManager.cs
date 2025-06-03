using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndOfGameUIManager : MonoBehaviour
{
    public HighscoreDBManager dbManager;
    public HealthManager HM;

    public GameObject winnerPromptPanel1;
    public GameObject winnerPromptPanel2;
    public TMP_InputField playerNameInput1;
    public TMP_InputField playerNameInput2;// Use InputField if not using TMP
    //public TextMeshProUGUI highscoreText;   // Use Text if not using TMP

    // Called at game end — pass in true if the player won
    /*public void OnGameOver(bool playerWon)
    {
        ShowHighscores(); // update the list after match
    }*/

    public void Update()
    {
        if (HM.child1.isActiveAndEnabled)
        {
            winnerPromptPanel1 = GameObject.FindGameObjectWithTag("PromptPanel1");
            playerNameInput1 = GameObject.FindGameObjectWithTag("Input1").GetComponent<TMP_InputField>();
        }
        if (HM.child2.isActiveAndEnabled)
        {
            winnerPromptPanel2 = GameObject.FindGameObjectWithTag("PromtPanel2");
            playerNameInput2 = GameObject.FindGameObjectWithTag("Input2").GetComponent<TMP_InputField>();
        }
    }

    // Called when winner submits name
    public void OnSubmitName1()
    {
        string name = playerNameInput1.text;

        if (!string.IsNullOrEmpty(name))
        {
            name = name.ToUpper();
            
            dbManager.AddOrUpdateWinner(name);
            winnerPromptPanel1.SetActive(false); 
        }
    }

    public void OnSubmitName2()
    {
        string name = playerNameInput2.text;

        if (!string.IsNullOrEmpty(name))
        {
            name = name.ToUpper();

            dbManager.AddOrUpdateWinner(name);
            winnerPromptPanel2.SetActive(false);
        }
    }

    // This displays the highscore list
    /*public void ShowHighscores()
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
    }*/
}