using Mirror;
using UnityEngine;

public class MirrorDiceReroll : NetworkBehaviour
{

    public DiceRoll DR;
    public RerollText rt;
  

  // reroll int for each player, for how many rerolls they have
    [SerializeField] private int Rerolls1;
    [SerializeField] private int Rerolls2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    public void OnReroll()
    {
        if(Rerolls1 > 0)
        {
            Rerolls1 --;
            rt.RerollTextUpdate();
            DR.diceRoll();
        }

        else
        {
            Debug.Log("No rerolls left for Player 1, womp womp");
        }
    }
    
    public void OnReroll2()
    {
        if(Rerolls2 > 0)
        {
            Rerolls2--;
            DR.diceRoll2();
        }

        else
        {
            Debug.Log("No rerolls left for Player 2, womp womp");
        }
    }
}
