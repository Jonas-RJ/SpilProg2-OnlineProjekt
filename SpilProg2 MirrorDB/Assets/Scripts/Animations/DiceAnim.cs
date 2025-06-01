using UnityEngine;
using UnityEngine.UI;

public class DiceAnim : MonoBehaviour
{
    public ChangeDie cd;
    [SerializeField] Image image;


    public void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DiceRoll();
        }
    }

    public void DiceRoll()
    {
        SetOpacity(1.0f);
        cd.SetOpacity(0f);
        GetComponent<Animator>().Play("DiceAnim");
    }

    public void ChangeUI1()
    {
        cd.ChangeImageSprite1();
    }
    public void ChangeUI2()
    {
        cd.ChangeImageSprite1();
    }
    public void OpacityZero()
    {
        cd.SetOpacity(1.0f);
        SetOpacity(0f);
    }

    public void SetOpacity(float opa)
    {
        Color color = image.color;
        color.a = opa;
        image.color = color;
    }

}
