using UnityEngine;
using UnityEngine.UI;

public class Player2RollDiceButton : MonoBehaviour
{

    public DiceRoll DR;
    public Button RollPlayer2;
    public DiceAnim DA;
    public ChangeDie CD;

    public GameObject reRollButton2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reRollButton2.SetActive(false);
        DR = GameObject.Find("DiceRollerController").GetComponent<DiceRoll>();
        Button btn = RollPlayer2.GetComponent<Button>();
        btn.onClick.AddListener(DR.diceRoll2);
       // btn.onClick.AddListener(DR.EnableReRollButton2);
        btn.onClick.AddListener(DA.DiceRoll);
        btn.onClick.AddListener(CD.ChangeImageSprite2);
    }
    

    public void EnableReRollButton2()
    {
         reRollButton2.SetActive(true);
    }
}
