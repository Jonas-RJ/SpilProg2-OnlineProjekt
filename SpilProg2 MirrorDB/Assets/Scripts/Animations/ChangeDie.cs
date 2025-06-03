using UnityEngine;
using UnityEngine.UI;

public class ChangeDie : MonoBehaviour
{
    private Image image;
    public DiceRoll DR;
    [SerializeField] Sprite[] sprites;

    public void Awake()
    {
        DR = GameObject.Find("DiceRollerController").GetComponent<DiceRoll>();
        image = GetComponent<Image>();
    }

    public void ChangeImageSprite1()
    {
        int dice = DR.diceRollNumber - 1;
        image.sprite = sprites[dice];

        Debug.Log("Changed sprite to index: " + dice);
    }
    public void ChangeImageSprite2()
    {
        int dice = DR.diceRollNumber2 - 1;
        image.sprite = sprites[dice];

        Debug.Log("Changed sprite to index: " + dice);
    }

    public void SetOpacity(float opa)
    {
        Color color = image.color;
        color.a = opa;
        image.color = color;
    }
}
