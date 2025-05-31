using UnityEngine;
using UnityEngine.UI;

public class Buttonassigner : MonoBehaviour
{


    public HealthManager HM;
    public Button LaunchDice;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HM = GameObject.Find("HealthController").GetComponent<HealthManager>();
        Button btn = LaunchDice.GetComponent<Button>();
        btn.onClick.AddListener(HM.CallingPlayer1Ready);
        // implement funktion der gør, at hvis begge er klar, så kør healthupdate
    }

  
}
