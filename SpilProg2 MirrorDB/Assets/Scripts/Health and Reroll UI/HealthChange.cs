using UnityEngine;
using UnityEngine.UI;

public class HealthChange : MonoBehaviour
{

    public Light child1;
    //References, variables and array
    [SerializeField] private Image[] health;
    public HealthManager hr;
    [SerializeField] int change;
    [SerializeField] int pool1;

    Image point;
    [SerializeField] Sprite green;
    [SerializeField] Sprite red;

    [SerializeField] GameObject winners1;
    [SerializeField] GameObject restart1;
    [SerializeField] GameObject loser1;


    void Start()
    {
       child1 = GameObject.Find("HealthController").GetComponent<Light>();
       hr = GameObject.Find("HealthController").GetComponent<HealthManager>();
        child1.enabled = true;
    }
    public void Change1()
    {
        //Sets a new variable to the dice damage
        change = hr.diceDamage;
        //Pool of lost health total
        pool1 = pool1 + change;

        if (pool1 > 10)
        {
            pool1 = 10;
        }

        //For loop where the individual health sprite equal to the pool is set to the red/damaged sprite
        for (int i = 0; i < pool1; i++)
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

    public void ActivateWinners1()
    {
        winners1.SetActive(true);
    }

    public void ActivateRestart1()
    {
        restart1.SetActive(true);
    }

    public void ActivateLoser1()
    {
        loser1.SetActive(true);
    }

}
