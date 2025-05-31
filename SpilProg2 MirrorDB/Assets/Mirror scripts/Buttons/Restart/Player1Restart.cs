using UnityEngine;
using UnityEngine.UI;

public class Player1Restart : MonoBehaviour
{
    public HealthManager HM;
    public Button Restart1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HM = GameObject.Find("HealthController").GetComponent<HealthManager>();
        Button btn = Restart1.GetComponent<Button>();
        btn.onClick.AddListener(HM.Player1RestartGame);
        btn.onClick.AddListener(HM.RestartGame);
    }
}
