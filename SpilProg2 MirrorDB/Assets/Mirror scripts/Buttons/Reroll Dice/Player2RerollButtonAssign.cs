using UnityEngine;
using UnityEngine.UI;

public class Player2RerollButtonAssign : MonoBehaviour
{


    public RerollText ReText;
    public DiceReroll DRE;
    public Button RerollP2;
     public DiceAnim DA;
    public ChangeDie CD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DRE = GameObject.Find("RerollerController").GetComponent<DiceReroll>();
        Button btn = RerollP2.GetComponent<Button>();
        btn.onClick.AddListener(DRE.OnReroll2);
          btn.onClick.AddListener(DA.DiceRoll);
        btn.onClick.AddListener(CD.ChangeImageSprite1);
    }

}
