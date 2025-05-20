using UnityEngine;
using UnityEngine.UI;

public class ChangeDie : MonoBehaviour
{
    private Image image;
    [SerializeField] Sprite[] sprites;

    public void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ChangeImageSprite()
    {
        int dice = Random.Range(0, sprites.Length);
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
