using UnityEngine;

public class Submit : MonoBehaviour
{

    public EndOfGameUIManager EOG;
    public ScoreDisplayManager SDM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EOG = GameObject.Find("EndOfGame UI Manager").GetComponent<EndOfGameUIManager>();
        SDM = GameObject.Find("ScoreDisplay Manager").GetComponent<ScoreDisplayManager>();
    }

    public void Submit1()
    {
        EOG.OnSubmitName1();
        SDM.ShowScoreboard();
    }

    public void Submit2()
    {
        EOG.OnSubmitName2();
        SDM.ShowScoreboard2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
