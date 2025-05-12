using UnityEngine;
using UnityEngine.UI;

public class DiceAnim : MonoBehaviour
{
    [SerializeField] Sprite three;
    [SerializeField] Image dice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().Play("DiceAnim");            
        }
    }

    public void ChangeSprite()
    {
        dice.sprite = three;
    }

}
