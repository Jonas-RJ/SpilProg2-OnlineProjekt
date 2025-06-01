using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RerollText : MonoBehaviour
{
    public TMP_Text reroll;
    public DiceReroll dr;


    void Start()
    {
        dr = GameObject.Find("RerollerController").GetComponent<DiceReroll>();
    }
    public void RerollTextUpdate()
    {
        reroll.SetText("Rerolls left: " + dr.Rerolls1);
    }
     public void RerollTextUpdate2()
    {
        reroll.SetText("Rerolls left: " + dr.Rerolls2);
    }
    
    public void RerollUIReset()
    {
        reroll.SetText("Rerolls left: 2");
    }
}
