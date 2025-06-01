using UnityEngine;
using UnityEngine.UI;

public class Player1RerollButtonAssign : MonoBehaviour
{
 
    public RerollText ReText;
    public DiceReroll DRE;
    public Button RerollP1;
         public DiceAnim DA;
    public ChangeDie CD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DRE = GameObject.Find("RerollerController").GetComponent<DiceReroll>();
        Button btn = RerollP1.GetComponent<Button>();
        btn.onClick.AddListener(DRE.OnReroll);
                 btn.onClick.AddListener(DA.DiceRoll);
        btn.onClick.AddListener(CD.ChangeImageSprite1);
    }
}
