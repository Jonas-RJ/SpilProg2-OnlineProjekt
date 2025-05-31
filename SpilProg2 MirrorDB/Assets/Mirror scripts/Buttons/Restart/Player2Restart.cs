using UnityEngine;
using UnityEngine.UI;

public class Player2Restart : MonoBehaviour
{
    public HealthManager HM;
    public Button Restart2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HM = GameObject.Find("HealthController").GetComponent<HealthManager>();
        Button btn = Restart2.GetComponent<Button>();
        btn.onClick.AddListener(HM.Player2RestartGame);
        btn.onClick.AddListener(HM.RestartGame);
    }
}
