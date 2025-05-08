using UnityEngine;

public class GameSimulator : MonoBehaviour
{
    public GameOverUIManager uiManager;

    void Start()
    {
        // Simulate a win
        uiManager.OnGameOver(true);

        // Simulate a loss:
        // uiManager.OnGameOver(false);
    }
}