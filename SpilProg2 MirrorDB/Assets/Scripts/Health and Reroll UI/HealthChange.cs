using UnityEngine;
using UnityEngine.UI;

public class HealthChange : MonoBehaviour
{
    //References, variables and array
    [SerializeField] private Image[] health;
    public HealthManager hr;
    [SerializeField] int change;
    [SerializeField] int pool;
    Image point;
    [SerializeField] Sprite green;
    [SerializeField] Sprite red;


    void Start()
    {
        GameObject.Find("HealthController").GetComponent<HealthManager>();
    }
    public void Change()
    {
        //Sets a new variable to the dice damage
        change = hr.diceDamage;
        //Pool of lost health total
        pool = pool + change;

        //For loop where the individual health sprite equal to the pool is set to the red/damaged sprite
        for (int i = 0; i < pool; i++)
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
}
