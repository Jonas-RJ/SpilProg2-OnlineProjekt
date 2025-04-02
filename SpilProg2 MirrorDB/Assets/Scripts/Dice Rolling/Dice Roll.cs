using System;
using UnityEngine;


public class DiceRoll : MonoBehaviour
{


    public int diceRollNumber;
    public int diceRollNumber2;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int diceRoll() 
    {
        diceRollNumber = UnityEngine.Random.Range(1, 6);
        print("player 1 rolled " + diceRollNumber);
        return diceRollNumber;
    }

     public int diceRoll2()
    {
        diceRollNumber2 = UnityEngine.Random.Range(1, 6);
        print("player 2 rolled " + diceRollNumber2);
        return diceRollNumber2;
    }

}
