using UnityEngine;

public class RedEnemyAnimation : MonoBehaviour
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

    public void RunAnim()
    {
        GetComponent<Animator>().Play("RedEnemyAnim");
    }
}
