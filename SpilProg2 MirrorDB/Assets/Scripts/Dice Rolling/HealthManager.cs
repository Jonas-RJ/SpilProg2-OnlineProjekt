using UnityEngine;
using System;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
[SerializeField]private GameObject RestartButton;
[SerializeField]private GameObject buttons;
[SerializeField]private GameObject Winners;
[SerializeField]private TMP_Text WinningText;
// playerhealth variabler. Brugt til at udregne liv (duh)
    [SerializeField] public int player1Health;
    [SerializeField] public int player2Health;


    // værdi som indeholder hvad man har rullet fra det andet script. 
    public int diceRoll1;  
    public int diceRoll2;



// samlet værdi for hvor meget man tager i skade. Udregnes ved at kigge på foreskellen mellem hvad man ruller, og bruger så foreskellen som damage. 
    public int diceDamage;

    // YEEEHOOOO, REFERENCER!!
    public DiceRoll DR;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    //hvis du har 0 liv eller derunder, taber du. MANGLER LOSS CONDITION / LOSS SCREEN.
        if (player1Health <= 0)
        {
            buttons.SetActive(false);
            Winners.SetActive(true);
            WinningText.SetText("Player 2 Wins, Player 1 Loses");
            // player 1 loss
            print("player 1 loses");
                    RestartButton.SetActive(true);

        }
        if (player2Health <= 0)
        {
            buttons.SetActive(false);
            Winners.SetActive(true);
            WinningText.SetText("Player 1 Wins,  Player 2 loses");
            // player 2 loss
            print("player 2 loses");
                    RestartButton.SetActive(true);
        }
    }

    public void healthUpdatePlayer()
    {

        //checker hvem der ruller højst. 
        if (diceRoll1 > diceRoll2)
        { 

            // Dicedamage, udregnes ved at tage forskellen imellem det højeste og laveste rul, og bruge den forskel som værdien af damage man tager. Sikrer at der altid er mindst to runder.
            diceDamage = DR.diceRollNumber - DR.diceRollNumber2;
            //trækker skaden fra ens healthpool. 
            player2Health -= diceDamage;
            Debug.Log("player 2 took: " + diceDamage + " damage");
        }

        if (diceRoll1 < diceRoll2)
        {
            diceDamage = DR.diceRollNumber2 - DR.diceRollNumber;
            player1Health -= diceDamage;
            Debug.Log("player 1 took: " + diceDamage + " damage");
        }

        if (diceRoll1 == diceRoll2)
        { 
            diceDamage = 0;
            Debug.Log("Tied");
        }

    }


    public void RestartGame()
    {
        RestartButton.SetActive(false);
        buttons.SetActive(true);
        Winners.SetActive(false);
        ResetValues();

    }


    private void ResetValues(){
        player1Health = 10;
        player2Health = 10;
        diceRoll1 = 0;
        diceRoll2 = 0;

    }
}
