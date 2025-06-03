using UnityEngine;

public class GameSimulator : MonoBehaviour
{
    public EndOfGameUIManager uiManager;

    void Start()
    {
        // Simulate a win
        //uiManager.OnGameOver(true);

        // Simulate a loss:
        // uiManager.OnGameOver(false);
    }
}