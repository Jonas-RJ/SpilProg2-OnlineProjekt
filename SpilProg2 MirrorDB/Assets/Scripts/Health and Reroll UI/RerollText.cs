using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RerollText : MonoBehaviour
{
    public TMP_Text reroll;
    public DiceReroll dr;

    public void RerollTextUpdate()
    {
        reroll.SetText("Rerolls left: " + dr.Rerolls1);
    }
    
    public void RerollUIReset()
    {
        reroll.SetText("Rerolls left: 2");
    }
}
