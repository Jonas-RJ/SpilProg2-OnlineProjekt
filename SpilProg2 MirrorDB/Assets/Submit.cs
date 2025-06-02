using UnityEngine;

public class Submit : MonoBehaviour
{

    public EndOfGameUIManager EOG;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EOG = GameObject.Find("DiceRollerController").GetComponent<EndOfGameUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
