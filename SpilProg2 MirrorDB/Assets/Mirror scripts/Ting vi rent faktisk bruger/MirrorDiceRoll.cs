using Mirror;
using UnityEngine;

public class MirrorDiceRoll : NetworkBehaviour
{
public HealthManager healthmanager;

[SyncVar]
public int diceRollP1;
[SyncVar]
public int diceRollP2;


 public GameObject reRollButton1;
 public GameObject reRollButton2;



 public void EnableReRollButton()
    {
        reRollButton1.SetActive(true);
        
    }
    void Start()
    {
        reRollButton1.SetActive(false);
        reRollButton2.SetActive(false);
    }

[Command]
public void Dicerolling()
{
            UpdateDice();
}

[ClientRpc]
public void UpdateDice()
{

diceRollP1 = UnityEngine.Random.Range(1, 6);
healthmanager.diceRoll1 = diceRollP1;

}

[Command]
public void DiceRolling2()
{
    diceRollP2 = UnityEngine.Random.Range(1,6);
    healthmanager.diceRoll2 = diceRollP2;
}

[Client]
public void enableRerollButton()
{
    reRollButton1.SetActive(true);
}

[Client]
public void enableRerollButton2()
{
    reRollButton2.SetActive(true);
}

public void ExitGame()
{
    Application.Quit();
}

}
