using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class Player1RollButton : MonoBehaviour
{


    public DiceRoll DR;
    public Button RollPlayer1;
    public DiceAnim DA;
    public ChangeDie CD;

   [SerializeField] public GameObject reRollButton1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reRollButton1.SetActive(false);
        DR = GameObject.Find("DiceRollerController").GetComponent<DiceRoll>();
        Button btn = RollPlayer1.GetComponent<Button>();
        btn.onClick.AddListener(DR.diceRoll);
        //btn.onClick.AddListener(DR.EnableReRollButton);
        btn.onClick.AddListener(DA.DiceRoll);
        btn.onClick.AddListener(CD.ChangeImageSprite1);

    }

    public void EnableReRollButton()
    {
        reRollButton1.SetActive(true);
    }
}
