using UnityEngine;

public class BlueEnemyAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            RunAnim();
        }
    }

    private void RunAnim()
    {
        GetComponent<Animator>().Play("BlueEnemyAnim");
    }
}
