using UnityEngine;
using System;


public class HealthManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] public int player1Health;
    [SerializeField] public int player2Health;
    public int diceRoll;
    public DiceRoll DR;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Health <= 0)
        {
            // player 1 loss
            print("player 1 loses");

        }
        if (player2Health <= 0)
        {
            // player 2 loss
            print("player 2 loses");
        }
    }

    public int healthUpdatePlayer()
    {
        if (DR.diceRollNumber > DR.diceRollNumber2)
        { 
            diceRoll = DR.diceRollNumber - DR.diceRollNumber2;
            player2Health -= diceRoll;
        }

        if (DR.diceRollNumber < DR.diceRollNumber2)
        {
            diceRoll = DR.diceRollNumber2 - DR.diceRollNumber;
            player1Health -= diceRoll;
        }

        if(DR.diceRollNumber == DR.diceRollNumber2) { diceRoll = 0; }
        return diceRoll;
    }
}
