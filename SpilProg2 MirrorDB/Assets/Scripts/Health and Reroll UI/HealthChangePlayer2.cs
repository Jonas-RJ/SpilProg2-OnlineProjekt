using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthChangePlayer2 : MonoBehaviour
{
    //References, variables and array

    public LensFlareComponentSRP child2;
    [SerializeField] private Image[] health;
    public HealthManager hr;
    [SerializeField] int change;
     [SerializeField] int pool2;

    Image point;
    [SerializeField] Sprite green;
    [SerializeField] Sprite red;

    [SerializeField] GameObject winners2;
    [SerializeField] GameObject restart2;
    [SerializeField] GameObject loser2;

    void Start()
    {
        child2 = GameObject.Find("HealthController").GetComponent<LensFlareComponentSRP>();
        hr = GameObject.Find("HealthController").GetComponent<HealthManager>();
        child2.enabled = true;
    }
    public void Change2()
    {
        //Sets a new variable to the dice damage
        change = hr.diceDamage;
        //Pool of lost health total
        pool2 = pool2 + change;

        if(pool2 > 10)
        {
            pool2 = 10;
        }

        //For loop where the individual health sprite equal to the pool is set to the red/damaged sprite
        for (int i = 0; i < pool2; i++)
        {
            point = health[i];
            point.sprite = red;
        }
    }
    

    public void HealthUIReset()
    {
        foreach (var p in health)
        {
            p.sprite = green;
        }
    }

    public void ActivateWinners2()
    {
        winners2.SetActive(true);
    }

    public void ActivateRestart2()
    {
        restart2.SetActive(true);
    }

    public void ActivateLoser2()
    {
        loser2.SetActive(true);
    }

}
