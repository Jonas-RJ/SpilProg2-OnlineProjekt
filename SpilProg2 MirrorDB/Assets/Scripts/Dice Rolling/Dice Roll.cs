using System;
using UnityEngine;


public class DiceRoll : MonoBehaviour
{


// en dice roll nummer til hver spiller, bruges til at udregne hvem der vinder. Skal ændres ift. Mirror. 
    public int diceRollNumber;
    public int diceRollNumber2;

    public HealthManager HealthManager;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// en diceroll per person, 
    public void diceRoll() 
    {
    // siger at hver persons roll værdi er en værdi mellem 1 og 6. Printer derefter hvad man ruller. 
    // Sætter værdi fra andet script, brugt til at udregne hvor meget hp man mister, til at være lig med det man har rullet, for at bære værdier over til andet script. 
        diceRollNumber = UnityEngine.Random.Range(1, 6);
        print("player 1 rolled " + diceRollNumber);
        HealthManager.diceRoll1 = diceRollNumber;
    }

     public void diceRoll2()
    {
    // siger at hver persons roll værdi er en værdi mellem 1 og 6. Printer derefter hvad man ruller. 
    // Sætter værdi fra andet script, brugt til at udregne hvor meget hp man mister, til at være lig med det man har rullet, for at bære værdier over til andet script. 
        diceRollNumber2 = UnityEngine.Random.Range(1, 6);
        print("player 2 rolled " + diceRollNumber2);
        HealthManager.diceRoll2 = diceRollNumber2;

    }

}
