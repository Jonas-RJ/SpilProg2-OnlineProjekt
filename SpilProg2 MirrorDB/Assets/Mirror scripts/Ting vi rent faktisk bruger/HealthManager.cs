using UnityEngine;
using System;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using Mirror;


public class HealthManager : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header ("Object References")]
    // YEEEHOOOO, REFERENCER!!
    public DiceRoll DR;
    [SerializeField]private GameObject RestartButton;
    [SerializeField]private GameObject buttons;
    [SerializeField]private GameObject Winners;
    [SerializeField]private TMP_Text WinningText;

    public HealthChange hc;

    [Header ("Health and damage calculation")]

    // playerhealth variabler. Brugt til at udregne liv (duh)

    [SyncVar (hook = nameof(updateHealth))]
    [SerializeField] public int player1Health;
    [SyncVar (hook = nameof(updateHealth2))]
    [SerializeField] public int player2Health;
    [SyncVar] public bool player1Restart = false;
    [SyncVar]   public bool player2Restart = false;
[SyncVar]   public bool player1Ready = false;
[SyncVar]   public bool player2Ready = false;
    //(hook = nameof(MakePlayer1Ready))
    //(hook = nameof(MakePlayer2Ready))
    public Button player1ReadyButton;
    public Button player2ReadyButton;


    // værdi som indeholder hvad man har rullet fra det andet script. 
    [SyncVar]public int diceRoll1;  
    [SyncVar]public int diceRoll2;
    // samlet værdi for hvor meget man tager i skade. Udregnes ved at kigge på foreskellen mellem hvad man ruller, og bruger så foreskellen som damage. 
    public int diceDamage;

    [Header ("Win counter variables")]

    // selve værdier for wins / losses, brugt i selve teksten. 
    public int winCounter1;
    public int winCounter2;

    public int LossCounter1;
    public int LossCounter2;


    // bool der sikrer at vi ikke bliver ved med at tælle hver sekund i update, men kun en gang når man restarter.
    private bool player1wins;
    private bool player2wins;

    [SerializeField]private TMP_Text Player1Counter;
    [SerializeField]private TMP_Text Player2Counter;


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
            player2wins = true; // sætter bool til true for at increase win counter
        }
        if (player2Health <= 0)
        {
            buttons.SetActive(false);
            Winners.SetActive(true);
            WinningText.SetText("Player 1 Wins,  Player 2 loses");
            // player 2 loss
            print("player 2 loses");
            RestartButton.SetActive(true);
            player1wins = true;// sætter bool til true for at increase win counter
        }


        RollDice();
    }


[ClientRpc]
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
        hc.Change();
    }

public void updateHealth(int OldValue, int NewValue){
player1Health = NewValue;

}

    public void updateHealth2(int OldValue, int NewValue)
    {
    player2Health = NewValue;
    }


    public void RollDice()
    {
        if (player1Ready && player2Ready)
        {
            healthUpdatePlayer();
            player1Ready = false;
            player2Ready = false;
        }
    }


/*
    public void MakePlayer1Ready(bool OldValue, bool NewValue)
    {
        NewValue = player1Ready;
        NewValue = true;
    }
    
    public void MakePlayer2Ready(bool OldValue, bool NewValue)
    {
        NewValue = player2Ready;
        NewValue = true;
    }*/
    

[Command(requiresAuthority = false)]
    public void RestartGame()
    {

        if (player1Restart && player2Restart)
        {
            RestartButton.SetActive(false);
            buttons.SetActive(true);
            Winners.SetActive(false);
            ResetValues();


            // to if statements, for at vurdere hvem der har vundet, og hvilken counter der skal modificeres, og hvordan
            if (player1wins)
            {
                winCounter1 += 1;
                LossCounter2 += 1;
            }
            if (player2wins)
            {
                winCounter2 += 1;
                LossCounter1 += 1;
            }

            // modificerer teksten, ved at konvertere wincounters / losscounters til string.
            Player1Counter.SetText("Player 1:\nWins:" + winCounter1.ToString() + ".\n" + ("Losses: ") + LossCounter1.ToString());
            Player2Counter.SetText("Player 2:\nWins:" + winCounter2.ToString() + ".\n" + ("Losses: ") + LossCounter2.ToString());
            // sætter begge bools til false, så at der ikke i næste runde bliver ændret ved begge counters, i tilfælde af at andet resultat ift. vinder / taber.
            player2wins = false;
            player1wins = false;
        }
    }


[Command (requiresAuthority = false)]
    public void CallingPlayer1Ready()
    {
        player1Ready = true;
        print(player1Ready);
    }
[Command (requiresAuthority = false)]
    public void CallingPlayer2Ready()
    {
        player2Ready = true;
        print(player2Ready);
    }
    [Command(requiresAuthority = false)]
    public void Player1RestartGame()
    {
        player1Restart = true;
    }
    [Command(requiresAuthority = false)]
    public void Player2RestartGame()
    {
        player2Restart = false;
    }


    [ClientRpc]
    private void ResetValues(){
        player1Health = 10;
        player2Health = 10;
        diceRoll1 = 0;
        diceRoll2 = 0;
        player1Ready = false;
        player2Ready = false;
    }
}
