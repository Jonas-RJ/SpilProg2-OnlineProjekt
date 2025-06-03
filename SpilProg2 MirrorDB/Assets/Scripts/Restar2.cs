using UnityEngine;
using UnityEngine.UI;

public class Restart2 : MonoBehaviour
{

    public Button restart2;
    public HealthManager HM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HM = GameObject.Find("HealthController").GetComponent<HealthManager>();
        Button btn = restart2.GetComponent<Button>();
        btn.onClick.AddListener(HM.Player2RestartGame);
        btn.onClick.AddListener(HM.RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
