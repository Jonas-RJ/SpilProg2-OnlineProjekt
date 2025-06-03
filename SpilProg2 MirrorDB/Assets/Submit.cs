using UnityEngine;

public class Submit : MonoBehaviour
{

    public EndOfGameUIManager EOG;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EOG = GameObject.Find("EndOfGame UI Manager").GetComponent<EndOfGameUIManager>();
    }

    public void Submit1()
    {
        EOG.OnSubmitName1();
    }

    public void Submit2()
    {
        EOG.OnSubmitName2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
