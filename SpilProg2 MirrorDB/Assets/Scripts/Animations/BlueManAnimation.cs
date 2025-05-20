using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BlueManAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RunAnim();
        }
    }

    private void RunAnim()
    {
        GetComponent<Animator>().Play("BlueManAnim");
    }
}
